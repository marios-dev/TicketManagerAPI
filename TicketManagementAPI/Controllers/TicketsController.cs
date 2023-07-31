using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TicketManagementAPI.Interfaces;
using TicketManagementAPI.Models.TeamHoodModels.Responses;
using TicketManagementAPI.Models.TeamHoodModels.Board;
using TicketManagementAPI.Models.TeamHoodModels.Task;
using WebHooks.API.Models.TeamworkTicket;

namespace TicketManagementAPI.Controllers
{
    //Testing bench of the application in order to get the needed IDs of workspaces, Boards, Rows, Statuses and whatever we need.
    //First idea was to implement everything here but I decided to keep this as a bench and create a new project to be the primary one.
    //The application project is the Webhooks.API

    [Route("api/tickets/{action}")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        #region Variables and ctor
        private readonly ITicketService _ticketservice;
        private readonly IBoardItemService _itemservice;
        private readonly ILogger<TicketsController> _logger;
        public long? latestTicketID { get; set; }
        public TicketDTO ActualTicket { get; set; }


        public TicketsController(ILogger<TicketsController> logger, ITicketService ticketservice, IBoardItemService itemService)
        {
            _logger = logger;
            _ticketservice = ticketservice;
            _itemservice = itemService;
        }
        #endregion

        #region Get Latest Ticket from Teamwork API
        public async Task<ActionResult> GetTicket(int id)
        {
            string json;
            TicketDTO ticket = null;
            var latestTicketIDURi = $"{Resource.TeamWorkTicketsEndpoint}/{id}.json?includes=all";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(latestTicketIDURi)
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamWorkAccessToken);
            using (var response = await client.SendAsync(request))
            {
                json = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    ticket = JsonConvert.DeserializeObject<TicketDTO>(json);
                    if (ticket != null)
                    {
                        this.ActualTicket = ticket;
                    }
                }
                else
                {
                    return BadRequest("Api did not respond or your request did not bring any results");
                }
            }
            return Ok();
        }
        #endregion

        #region Create Task
        [HttpPost]
        public async Task<IActionResult> PostTask()
        {
            Guid boardID = Guid.ParseExact(Resource.BoardID, "D");
            Guid workspaceID = Guid.ParseExact(Resource.WorkspaceID, "D"); ;
            Guid statusID = Guid.ParseExact(Resource.StatusID, "D");
            Guid rowID = Guid.ParseExact(Resource.RowID, "D");

            Models.TeamHoodModels.Task.CustomField test2 = new Models.TeamHoodModels.Task.CustomField();
            Models.TeamHoodModels.Task.CustomField test1 = new Models.TeamHoodModels.Task.CustomField();
            test1.Name = "Priority";
            test1.Value = "P1";
            test2.Name = "Sub Status";
            test2.Value = "To be planned";
            var customFieldList = new List<Models.TeamHoodModels.Task.CustomField>() { test1, test2 };

            var taskDTO = new TaskDTO()
            {
                BoardId = boardID,
                RowId = rowID,
                StatusId = statusID,
                WorkspaceId = workspaceID,
                Title = this.ActualTicket.Ticket.Subject,
                Description = this.ActualTicket.Ticket.PreviewText,
                IsSuspended = false,
                Milestone = false,
                Completed = false,
                CustomFields = customFieldList,
                Tags = new List<string>(),
                Progress = 0,
                Color = 1
            };
            string json = JsonConvert.SerializeObject(taskDTO);
            string responseContent;
            var responseTask = new ResponseTask();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
                var uri = new Uri(Resource.postItemURI);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, content);
                responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    // Handle successful response
                    responseTask = JsonConvert.DeserializeObject<ResponseTask>(responseContent);
                }
                else
                {
                    // Handle error response
                    return BadRequest("Failed to retrieve data from TeamWork.");
                }
            }
            return Ok(responseTask);
        }
        #endregion

        #region Get All Tickets

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(Resource.getAllTicketsURL),
            };
            string json;
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamWorkAccessToken);
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
            }

            //var ticketList = JsonConvert.DeserializeObject<WebHooks.API.Models.TeamworkTicket.TicketList>(json);
            var ticketList = JsonConvert.DeserializeObject<TicketList>(json);

            latestTicketID = ticketList.Tickets
                .OrderByDescending(r => r.UpdatedAt)
                .Select(r => r.Id)
                .FirstOrDefault();
            var getTicketResult = await GetTicket((int)latestTicketID);

            //get the IDs I need
            //var status = await GetAllStatuses();
            //var workspace = await GetAllWorkspaces();
            //var boards = await GetAllBoards();
            //var rows = await GetAllRows();
            //var row = await CreateNewRow();

            if (getTicketResult is OkResult)
            {
                var postTaskResult = await PostTask();
                if (postTaskResult is not OkObjectResult)
                {
                    return BadRequest("Task failed to be uploaded to TeamHood");
                }
            }
            return Ok($"Task was created successfully.");
        }
        #endregion

        #region Get CustomFields from TeamWork
        //[HttpGet]
        //public async Task<ResponseCustomField> GetCustomFieldByID(long? id)
        //{
        //    var responseCustomField = new ResponseCustomField();
        //    string responseContent;
        //    var client = new HttpClient();

        //    try
        //    {
        //        var request = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Get,
        //            RequestUri = new Uri($"{Resource.TeamWorkCustomFieldsEndpoint}/{id}.json"),
        //        };
        //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamWorkAccessToken);
        //        using (var response = await client.SendAsync(request))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            if (response.IsSuccessStatusCode)
        //            {
        //                responseContent = await response.Content.ReadAsStringAsync();
        //                responseCustomField=JsonConvert.DeserializeObject<ResponseCustomField>(responseContent);
        //            }
        //            else
        //            {
        //                responseContent = string.Empty;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        responseContent = "Object not found";
        //    }
        //    return responseCustomField;
        //}
        #endregion

        #region Get all Boards to get boardID required
        //[HttpGet]
        //WorkspaceID is stored in Resources file
        //public async Task<Workspace> GetAllWorkspaces()
        //{
        //    var client = new HttpClient();
        //    string json;
        //    try
        //    {
        //        var request = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Get,
        //            RequestUri = new Uri($"{Resource.TeamHoodWorkspacesEndpoint}"),
        //        };
        //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
        //        using (var response = await client.SendAsync(request))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            json = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine(json);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        json = "Object not found";
        //    }
        //    Guid workspaceGuid = Guid.ParseExact($"{Resource.WorkSpaceID}", "D");

        //    var workspacesList = JsonConvert.DeserializeObject<WorkspaceList>(json);
        //    var Workspace = workspacesList.Workspaces.FirstOrDefault(d => d.Id == workspaceGuid);
        //    //this.workspaceID = Workspace.Id;
        //    return Workspace;
        //}
        #endregion

        #region GetAllBoards

        ////BoardID is stored in Resource file
        //[HttpGet]
        //public async Task<BoardElement> GetAllBoards()
        //{
        //    var client = new HttpClient();
        //    string json;
        //    try
        //    {
        //        var request = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Get,
        //            RequestUri = new Uri($"{Resource.TeamHoodWorkspacesEndpoint}/{Resource.WorkspaceID}/boards"),
        //        };
        //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
        //        using (var response = await client.SendAsync(request))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            json = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine(json);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        json = "Object not found";
        //    }
        //    //Guid workspaceGuid = Guid.ParseExact($"{Resource.WorkspaceID}", "D");

        //    var boardList = JsonConvert.DeserializeObject<Board>(json);
        //    Guid boardGuid = Guid.ParseExact($"{Resource.BoardID}", "D");
        //    var boardElement = boardList.Boards.Where(x => x.Id == boardGuid).FirstOrDefault();
        //    //this.BoardID = boardElement.Id;
        //    return boardElement;
        //}

        #endregion

        #region Get All Statuses
        //public async Task<StatusElement> GetAllStatuses()
        ////StatusID is stored in Resource file
        //{
        //    var client = new HttpClient();
        //    string json;
        //    try
        //    {
        //        var request = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Get,
        //            RequestUri = new Uri($"{Resource.TeamHoodBoardsEndpoint}/{Resource.BoardID}/statuses"),
        //        };
        //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
        //        using (var response = await client.SendAsync(request))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            json = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine(json);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        json = "Object not found";
        //    }
        //    //Guid workspaceGuid = Guid.ParseExact($"{Resource.WorkspaceID}", "D");

        //    var StatusList = JsonConvert.DeserializeObject<Status>(json);
        //    var toDoStatus = StatusList.Statuses.Where(s => s.Title == "To Do").FirstOrDefault();
        //    this.StatusID = toDoStatus.Id.ToString();
        //    return toDoStatus;
        //}
        #endregion

        #region CreateNewRow
        //[HttpPost]
        //public async Task<IActionResult> CreateNewRow()
        ////RowID is stored in Resource File
        //{
        //    var boardRow = new BoardRow()
        //    {
        //        //Title = ticket.Subject,
        //        Title = "Api tests",
        //        BoardID = Guid.ParseExact(Resource.BoardID, "D")
        //    };
        //    string json = JsonConvert.SerializeObject(boardRow);
        //    string responseContent;
        //    var responseRow = new ResponseRow();

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
        //        var uri = new Uri($"{Resource.TeamHoodRowsEndpoint}");
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");
        //        var response = await httpClient.PostAsync(uri, content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Handle successful response
        //            Console.WriteLine("Success");
        //            responseContent = await response.Content.ReadAsStringAsync();
        //            responseRow = JsonConvert.DeserializeObject<ResponseRow>(responseContent);
        //        }
        //        else
        //        {
        //            // Handle error response
        //            Console.WriteLine("Failure");
        //        }
        //    }
        //    //this.RowID = responseRow.ID;
        //    return responseRow != null ? Ok(Response) : NotFound();
        //}
        #endregion

        #region Get All Users from TeamHoodController
        [HttpGet]
        public async Task<string> ListAllUsers()
        {
            var client = new HttpClient();
            string json;
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(Resource.TeamHoodUsersEndpoint),
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ("Object not Found");
            }
            var users = JsonConvert.DeserializeObject<UserList>(json);

            return json;
        }
        #endregion

        #region GetAllRows
        ////RowID is stored in Resource file
        //[HttpGet]
        //public async Task<Models.TeamHoodModels.Row.Row> GetAllRows()
        //{
        //    var client = new HttpClient();
        //    string json;
        //    Row rowList = new Row();
        //    try
        //    {
        //        var request = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Get,
        //            RequestUri = new Uri($"{Resource.TeamHoodBoardsEndpoint}/{Resource.BoardTicketListID}/rows"),
        //        };
        //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Resource.teamHoodApiKey);
        //        using (var response = await client.SendAsync(request))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            json = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine(json);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                rowList = JsonConvert.DeserializeObject<Row>(json);
        //            }
        //            else
        //            {
        //                rowList = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        json = "Object not found";
        //    }
        //    return rowList;
        //}
        #endregion
    }
}
