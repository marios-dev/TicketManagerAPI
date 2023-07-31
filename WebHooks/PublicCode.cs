using Microsoft.AspNetCore.Mvc;
using WebHooks.API.Models.TeamworkTicket;
using WebHooks.API.Models;
using System.Net.Http.Headers;
using System.Text;
using WebHooks.API.Models.TeamHood;
using System.Runtime.CompilerServices;

namespace WebHooks.API
{
    //factory class accessible from everywhere
    public static class PublicCode
    {
        public static string TaskName { get; set; }
        public static string TicketURL { get; set; }
        public static string GetDeskTypeEvent(IHeaderDictionary headers)
        {
            return headers["x-desk-event"].ToString();
        }
        public static IHeaderDictionary GetHeaders(HttpContext context)
        {
            return context.Request.Headers;
        }

        public static List<Models.CustomField> GetCustomFieldList(TicketDTO ticket)
        {
            Models.CustomField customFieldPriority = new Models.CustomField();
            Models.CustomField customFieldSubStatus = new Models.CustomField();
            Models.CustomField customFieldCustomer = new Models.CustomField();
            Models.CustomField customFieldTicketURL = new Models.CustomField();
            var ticketURL = $"{Resource.TeamhoodCompanyEndPoint}/desk/tickets/{ticket.Ticket.Id}/messages";

            customFieldPriority.Name = "Priority";
            customFieldPriority.Value = "P1";
            customFieldSubStatus.Name = "Sub Status";
            customFieldSubStatus.Value = "To be planned";
            customFieldCustomer.Name = "Customer";
            customFieldTicketURL.Name = "Ticket";
            customFieldTicketURL.Value = ticketURL;

            if (ticket.Included.Tags.Any())
            {
                customFieldCustomer.Value = ticket.Included.Tags[0].Name;
            }
            var customFieldList = new List<Models.CustomField>() { customFieldPriority, customFieldSubStatus, customFieldCustomer, customFieldTicketURL };
            return customFieldList;
        }

        public static TaskDTO GetTaskDTO(TicketDTO ticketDto)
        {
            var taskDTO = new Models.TaskDTO()
            {
                BoardId = Guid.ParseExact(Resource.BoardID, "D"),
                RowId = Guid.ParseExact(Resource.RowID, "D"),
                StatusId = Guid.ParseExact(Resource.StatusID, "D"),
                WorkspaceId = Guid.ParseExact(Resource.WorkspaceID, "D"),
                Title = ticketDto.Ticket.Subject,
                Description = ticketDto.Ticket.PreviewText,
                IsSuspended = false,
                Milestone = false,
                Completed = false,
                CustomFields = GetCustomFieldList(ticketDto),
                Tags = new List<string>(),
                Progress = 0,
                Color = 1
            };
            return taskDTO;
        }
        public static async Task<ObjectResult> RedirectToDeserialize(string eventName, string json)
        {
            //Redirect depending to the event
            var result = new ObjectResult(null);
            switch (eventName)
            {
                case "ticket.status":
                    result = await TicketStatusChanged(eventName, json);
                    break;
                //Implementation of other events firing the webhook
                default:
                    break;
            }
            return result;
        }

        public static Models.TicketEventObjects.TicketStatus DeserializeToTicketStatus(string json)
        {
            //var webHookTicketStatus = JsonConvert.DeserializeObject<Models.TicketEventObjects.TicketStatus>(json);
            //return webHookTicketStatus;
            var webHookTicketStatus = new Models.TicketEventObjects.TicketStatus().Deserialize(json);
            return webHookTicketStatus;
        }

        public static bool ObjectIsNotNull(Object obj)
        {
            return obj != null;
        }

        public static bool IsObjectForTeamHood(Models.TicketEventObjects.TicketStatus ticketStatusObject)
        {
            return ticketStatusObject.Status.Id == Convert.ToInt64(Resource.teamHoodStatusID);
        }

        public static async Task<ObjectResult> GetResponseTaskResult(string json)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
                    var uri = new Uri(Resource.postItemURI);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(uri, content);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        //return new OkObjectResult(JsonConvert.DeserializeObject<ResponseTask>(responseContent));
                        return new OkObjectResult(new ResponseTask().Deserialize(responseContent));
                    }
                    else
                    {
                        //return new BadRequestObjectResult(responseTask);
                        return new BadRequestObjectResult(responseContent);
                    }
                }
            }
            catch (Exception)
            {
                return new BadRequestObjectResult($"{MessagesResource.TaskCreationFailed}");
            }
        }

        public static async Task<ObjectResult> CloseTeamWorkTicket(long id)
        {
            //ObjectResult result;
            //string endpoint = Resource.TeamWorkCloseTicketEndpoint + $"{id}.json";
            //string json = GetCloseTicketObject();
            //string responseContent;
            //var client = new HttpClient();
            //try
            //{
            //    var request = new HttpRequestMessage
            //    {
            //        Method = HttpMethod.Patch,
            //        RequestUri = new Uri(endpoint),
            //        Content = new StringContent(json, Encoding.UTF8, "application/json")
            //    };
            //    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamWorkAccessToken);
            //    using (var response = await client.SendAsync(request))
            //    {
            //        responseContent = await response.Content.ReadAsStringAsync();
            //        response.EnsureSuccessStatusCode();
            //        if (response.IsSuccessStatusCode)
            //        {
            //            //var body = await response.Content.ReadAsStringAsync();
            //            result = new OkObjectResult(JsonConvert.DeserializeObject<TicketDTO>(responseContent));
            //        }
            //        else
            //        {
            //            result = new BadRequestObjectResult(responseContent);
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    result = new BadRequestObjectResult(e.Message);
            //}
            //return result;

            string endpoint = Resource.TeamWorkTicketsEndpoint + $"/{id}.json";
            string json = GetSerializedCloseTicketObject();

            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Patch, new Uri(endpoint))
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamWorkAccessToken);

                    using (var response = await client.SendAsync(request))
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            //return new OkObjectResult(JsonConvert.DeserializeObject<TicketDTO>(responseContent));
                            return new OkObjectResult(new TicketDTO().Deserialize(responseContent));
                        }
                        else
                        {
                            return new BadRequestObjectResult(responseContent);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        public static async Task<ObjectResult> TicketStatusChanged(string eventName, string json)
        {
            //IActionResult createTaskActionResult;
            //ObjectResult result = null;
            //ObjectResult statusChangingResult;
            //TicketDTO deserializedTicket;
            //Models.TicketEventObjects.TicketStatus ticketStatusObject = DeserializeToTicketStatus(json);

            //if (ObjectIsNotNull(ticketStatusObject))
            //{
            //    if (IsObjectForTeamHood(ticketStatusObject))
            //    {
            //        deserializedTicket = await new WebhookController().GetAPITicket(ticketStatusObject.Id);
            //        if (deserializedTicket is not null)
            //        {
            //            if (await TaskExistsInCompleted(deserializedTicket) is OkObjectResult okObjectResult)
            //            {
            //                statusChangingResult = await ChangeTaskStatus((ItemElement)okObjectResult.Value);
            //                if (statusChangingResult is OkObjectResult okStatusChangedResult)
            //                {
            //                    await CloseTeamWorkTicket(ticketStatusObject.Id);
            //                    result = okStatusChangedResult;
            //                }
            //                else
            //                {
            //                    return new BadRequestObjectResult($"Changing of the status of the task in TeamHood failed, TeamHood internal error or deserialization failed");
            //                }
            //            }
            //            else
            //            {
            //                createTaskActionResult = await new WebhookController().CreateTask(deserializedTicket);
            //                if (createTaskActionResult is OkResult)
            //                {
            //                    result = await CloseTeamWorkTicket(ticketStatusObject.Id);
            //                }
            //                else
            //                {
            //                    return new BadRequestObjectResult($"Creation of the task for ticket with id {ticketStatusObject.Id} failed, TeamHood internal error");
            //                }
            //            }
            //        }
            //        else
            //        {
            //            return new BadRequestObjectResult($"Ticket with ID {ticketStatusObject.Id} returned null. TeamWork internal error");
            //        }
            //    }
            //    else
            //    {
            //        //Implementation for if the status is changed to something else
            //    }
            //}
            //else
            //{
            //    result = new BadRequestObjectResult("Deserialization of the ticket status failed");
            //}
            //return result;

            ObjectResult result = null;
            //Models.TicketEventObjects.TicketStatus ticketStatusObject = DeserializeToTicketStatus(json);
            var ticketStatusObject = DeserializeToTicketStatus(json);

            if (ObjectIsNotNull(ticketStatusObject))
            {
                if (IsObjectForTeamHood(ticketStatusObject))
                {
                    //deserializedTicket = await new WebhookController().GetAPITicket(ticketStatusObject.Id);
                    var deserializedTicket = await GetAPITicket(ticketStatusObject.Id);
                    if (deserializedTicket is not null)
                    {
                        if (await TaskExistsInCompleted(deserializedTicket) is OkObjectResult okObjectResult)
                        {
                            ObjectResult statusChangingResult = await ChangeTaskStatus((ItemElement)okObjectResult.Value);
                            if (statusChangingResult is OkObjectResult okStatusChangedResult)
                            {
                                var ticketClosedResult = await CloseTeamWorkTicket(ticketStatusObject.Id);
                                if (ticketClosedResult is OkObjectResult)
                                {
                                    result = okStatusChangedResult;
                                }
                                else
                                {
                                    //return new BadRequestObjectResult($"Closing the ticket in Teamwork failed. Possible Teamwork internal error");
                                    return new BadRequestObjectResult($"{MessagesResource.TicketClosingFailed} {ticketClosedResult.Value}");
                                }
                            }
                            else
                            {
                                return new BadRequestObjectResult($"{MessagesResource.ChangingStatusFailed} {statusChangingResult.Value}");
                            }
                        }
                        else
                        {
                            //ObjectResult createTaskActionResult = await new WebhookController().CreateTask(deserializedTicket);
                            ObjectResult createTaskActionResult = await CreateTask(deserializedTicket);
                            if (createTaskActionResult is OkObjectResult re)
                            {
                                result = await CloseTeamWorkTicket(ticketStatusObject.Id);
                                var responseTask = (ResponseTask)re?.Value;
                                TaskName = responseTask?.DisplayId ?? $"{MessagesResource.TaskNameNull}";
                            }
                            else
                            {
                                return new BadRequestObjectResult($"Creation of the task for ticket with id {ticketStatusObject?.Id} failed, {createTaskActionResult?.Value}");
                            }
                        }
                    }
                    else
                    {
                        return new BadRequestObjectResult($"Ticket with ID {ticketStatusObject?.Id} returned null. TeamWork internal error");
                    }
                }
                else
                {
                    // Implementation for if the status is changed to something else
                }
            }
            else
            {
                result = new BadRequestObjectResult($"{MessagesResource.TicketStatusDeserializationFailed}");
            }

            return result;
        }

        public static async Task<ObjectResult> TaskExistsInCompleted(TicketDTO ticket)
        {
            var allTasks = await GetAllCompletedFilteredTasks();
            var task = allTasks.Items?.FirstOrDefault(x => x.Title == ticket.Ticket.Subject);
            if (task != null)
            {
                task.Description = GetTaskNewDescription(ticket);
                return new OkObjectResult(task);
            }
            return new NotFoundObjectResult(task ?? new ItemElement());
        }

        public static async Task<Item> GetAllCompletedFilteredTasks()
        {
            //var item = new Item();
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri(Resource.TeamHoodFilteredCompleted),
            //};
            //string json;
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
            //using (var response = await client.SendAsync(request))
            //{
            //    json = await response.Content.ReadAsStringAsync();
            //    response.EnsureSuccessStatusCode();
            //    if (response.IsSuccessStatusCode)
            //    {
            //        item = JsonConvert.DeserializeObject<Item>(json);
            //    }
            //    else
            //    {
            //        item = null;
            //    }
            //}
            //return item;

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, Resource.TeamHoodFilteredCompleted);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    //return JsonConvert.DeserializeObject<Item>(json);
                    return new Item().Deserialize(json);
                }
            }
            return new Item();
        }

        public static async Task<ObjectResult> ChangeTaskStatus(ItemElement task)
        {
            var updateItemObject = GetUpdateItemObject(task);
            //string json = JsonConvert.SerializeObject(updateItemObject);
            string json = updateItemObject.Serialize();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
                    var uri = new Uri($"{Resource.TeamhoodAPIV1CompanyEndpoint}/items/{task.Id}");
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(uri, content);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        //return new OkObjectResult(JsonConvert.DeserializeObject<ResponseTask>(responseContent));
                        return new OkObjectResult(new ResponseTask().Deserialize(responseContent));
                    }
                    else
                    {
                        return new BadRequestObjectResult(responseContent);
                    }
                }
            }
            catch (Exception) { }
            return new BadRequestObjectResult($"{MessagesResource.RetrieveObjectFailed}");
        }

        public static UpdateItemObject GetUpdateItemObject(ItemElement task)
        {
            var updateItemObject = new UpdateItemObject();
            updateItemObject.Data = new Data();
            updateItemObject.Data.Description = task.Description;
            updateItemObject.Data.Completed = false;
            updateItemObject.Data.StatusId = Guid.ParseExact(Resource.StatusID, "D");
            //updateItemObject.Data.Color = 5;//red
            updateItemObject.Data.Color = 2;//yellow
            updateItemObject.Data.Tags = GetUpdateTaskTags();
            //updateItemObject.Data.CustomFields = GetUpdatedTaskFields();
            updateItemObject.Data.CustomFields = new List<Models.CustomField>();
            return updateItemObject;
        }

        public static string GetSerializedCloseTicketObject()
        {
            CloseTicketObject closeTicketObject = new CloseTicketObject();
            closeTicketObject.Ticket = new TicketObject();
            closeTicketObject.Ticket.Status = new TicketObjectStatus();
            closeTicketObject.Ticket.Status.Id = 6; //id for status "Closed"
            //string json = JsonConvert.SerializeObject(closeTicketObject);
            string json = closeTicketObject.Serialize();
            return json;
        }

        public static string GetTaskNewDescription(TicketDTO ticketDTO)
        {
            try
            {
                var messages = ticketDTO?.Included?.Messages
                    .Where(x => x.Status != null && x.Status.Id == 3)
                    .ToList();
                if (messages?.Count > 0)
                {
                    //var latestDate = messages.Max(x => x.UpdatedAt);
                    var latestID = messages.Max(x => x.ID);
                    //var latestMessage = messages.Where(x => x.UpdatedAt == latestDate).FirstOrDefault()?.TextBody;
                    //var latestMessage = messages.FirstOrDefault(x => x.UpdatedAt == latestDate)?.TextBody;
                    var latestMessage = messages.FirstOrDefault(x => x.ID == latestID).TextBody;
                    return latestMessage;
                }
            }
            catch (Exception)
            {
            }
            return ticketDTO.Ticket.PreviewText;
        }

        public static async void PrintResults(ObjectResult objectResult, HttpContext context)
        {
            if (objectResult is BadRequestObjectResult result)
            {
                await context.Response.WriteAsync($"Status Code:{result.StatusCode} | {result.Value}");
            }
            else if (objectResult is OkObjectResult okResult)
            {
                if (okResult.Value is TicketDTO)
                {
                    var responseTicketDTO = (TicketDTO)objectResult?.Value;
                    var success = $"{MessagesResource.Success} Ticket with ID {responseTicketDTO.Ticket.Id} was created as a task in TeamHood [{TaskName}] and closed in TeamWork";
                    await context.Response.WriteAsync(success);
                }
                else if (okResult.Value is ResponseTask)
                {
                    var resposeTaskDTO = (ResponseTask)objectResult?.Value;
                    foreach (var item in resposeTaskDTO.ResponseCustomFields)
                    {
                        if (item.Name == "Ticket")
                        {
                            TicketURL = item?.Value;
                        }
                    }
                    var success = $"{MessagesResource.Success} Task with name {resposeTaskDTO.DisplayId} was marked as Not Completed.\n Corresponding ticket URL: {TicketURL}";
                    await context.Response.WriteAsync(success);
                }
            }
        }

        public static async Task<TicketDTO> GetAPITicket(long id)
        {
            //var latestTicketIDURi = $"{Resource.TeamWorkTicketsEndpoint}/{id}.json?includes=all";
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri(latestTicketIDURi)
            //};
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamWorkAccessToken);
            //try
            //{
            //    using (var response = await client.SendAsync(request))
            //    {
            //        var json = await response.Content.ReadAsStringAsync();
            //        response.EnsureSuccessStatusCode();
            //        if (response.IsSuccessStatusCode)
            //        {
            //            //return JsonConvert.DeserializeObject<TicketDTO>(json);
            //            return new TicketDTO().Deserialize(json);
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //}
            //return new TicketDTO();

            try
            {
                using (var client = new HttpClient())
                {
                    var completeTicketEndpoint = $"{Resource.TeamWorkTicketsEndpoint}/{id}.json?includes=all";
                    var request = new HttpRequestMessage(HttpMethod.Get, completeTicketEndpoint);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamWorkAccessToken);

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var json = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            return new TicketDTO().Deserialize(json);
                        }
                    }
                }
            }
            catch (Exception) { }

            return new TicketDTO();
        }

        [HttpPost]
        public static async Task<ObjectResult> CreateTask(TicketDTO ticketDto)
        {
            //string json = JsonConvert.SerializeObject(PublicCode.GetTaskDTO(ticketDto));
            string json = PublicCode.GetTaskDTO(ticketDto).Serialize();
            ObjectResult result = await PublicCode.GetResponseTaskResult(json);
            if (result is OkObjectResult)
            {
                return result;
            }
            else
            {
                return new BadRequestObjectResult(result.Value);
            }
        }

        public static List<Models.CustomField> GetUpdatedTaskFields()
        {
            Models.CustomField commendField = new Models.CustomField();
            commendField.Name = "Comment";
            commendField.Value = "Ticket was updated";
            return new List<Models.CustomField>() { commendField };
        }
        public static List<string> GetUpdateTaskTags()
        {
            string tag = "User Replied";
            return new List<string>() { tag };
        }
    }
}
