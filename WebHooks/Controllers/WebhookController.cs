using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using WebHooks.API.Models.TeamworkTicket;
using WebHooks.API.Models.TicketList;
using Ticket = WebHooks.API.Models.TeamworkTicket.Ticket;

namespace WebHooks.API.Controllers
{
    [Route("[controller]/[action]")]
    //[ApiController]
    public class WebhookController : ControllerBase
    {
        #region jsonstring test
        private const string js = $"{{\"ticket\":{{\"id\":4533938,\"subject\":\"Brev vedr tradeshift\",\"readonly\":false,\"messageCount\":1,\"previewText\":\"Hej. I skulle have fået besked fra JDE om det nye PO-faktureringssystem gældende her pr. 1. maj, men videresender lige for en sikkerheds skyld, se nedenfor og vedhæftede. Rigtig god påske Med venlig hilsen / Best regards, Morten Russ Key Account Specia...\",\"originalRecipient\":\"support@catmansolution.com\",\"responseTimeMins\":null,\"resolutionTimeMins\":31,\"imagesHidden\":false,\"isRead\":false,\"spam\":{{\"reports\":null,\"isSpam\":false,\"score\":0,\"reasons\":null}},\"spam_score\":0,\"spam_rules\":\"[{{\\\"checker\\\":\\\"phistank\\\",\\\"score\\\":0,\\\"always_spam\\\":false,\\\"reasons\\\":[]}},{{\\\"checker\\\":\\\"spamassassin\\\",\\\"score\\\":-6.7,\\\"always_spam\\\":false,\\\"reasons\\\":[\\\"-1.9 BAYES_00\\\",\\\"-5 RCVD_IN_DNSWL_HI\\\",\\\"0 HTML_IMAGE_RATIO_02\\\",\\\"0 HTML_MESSAGE\\\",\\\"0.1 DKIM_SIGNED\\\",\\\"0.1 DKIM_INVALID\\\",\\\"0 MSGID_FROM_MTA_HEADER\\\"]}}]\",\"customer\":{{\"id\":887052,\"type\":\"customers\"}},\"contact\":{{\"id\":170763,\"type\":\"contacts\"}},\"inbox\":{{\"id\":12257,\"type\":\"inboxes\"}},\"status\":{{\"id\":5,\"type\":\"ticketstatuses\"}},\"source\":{{\"id\":1,\"type\":\"ticketsources\"}},\"type\":{{\"id\":1,\"type\":\"tickettypes\"}},\"updatedBy\":{{\"id\":461124,\"type\":\"users\"}},\"messages\":[{{\"id\":16705258,\"type\":\"messages\"}},{{\"id\":16705259,\"type\":\"messages\"}},{{\"id\":16705761,\"type\":\"messages\"}},{{\"id\":16705762,\"type\":\"messages\"}}],\"customfields\":[{{\"id\":64,\"type\":\"customfields\",\"meta\":{{\"value\":null}},{{\"id\":65,\"type\":\"customfields\",\"meta\":{{\"value\":null}}],\"files\":[{{\"id\":3277884,\"type\":\"files\"}},{{\"id\":3277885,\"type\":\"files\"}},{{\"id\":3277886,\"type\":\"files\"}}],\"createdAt\":\"2020-04-06T07:51:31Z\",\"updatedAt\":\"2020-04-06T08:22:45Z\",\"state\":\"active\"}},\"included\":{{}}";
        #endregion

        #region Variables, URLs and Ctor
        private const string webhookURL = "https://effectmakers1.eu.teamwork.com/desk/api/v2/webhookendpoints.json";
        private const string TeamWorkAccessToken = "tkn.v1_MDJmYWY3MWUtMTQ0OC00ZWZmLWE1OTctZjRkNDUxYTEwNTk1LTYyODIxMi40ODAzNjguRVU=";
        private const string TeamHoodApiKey = "03Z42VKARBRYIOZMSGLI9H66YWCA0HQCHFPC41Q0IG6BM1HPPN370H0L66HYH18M";
        private const string createItemURL = "https://api-p5g8yky1i4u6cefmqwihnw.teamhood.com/api/v1/items";
        private const string getWorkspaces = "https://api-p5g8yky1i4u6cefmqwihnw.teamhood.com/api/v1/workspaces";
        private const string getBoards = "https://api-p5g8yky1i4u6cefmqwihnw.teamhood.com/api/v1/boards";

        //private readonly ILogger _logger;
        //public WebhookController(ILogger<WebhookController> logger)
        //{
        //    this._logger = logger;
        //}
        #endregion
        //webhook template
        [HttpGet]
        [ActionName("Receiver")]
        public async Task<ActionResult> WebhookReceiver(/*string json*/Ticket ticket)
        {
            //Deployment Code
            //Console.WriteLine(ticket.ToString());
            //string json = string.Empty;
            //if (json!=String.Empty)
            //{
            //    Ticket deserializedTicket = DeserializeToObject(json);
            //    if (deserializedTicket != null)
            //    {
            //        await PostToTeamHood(deserializedTicket);
            //        Console.WriteLine(deserializedTicket.ToString());
            //        return new OkResult();
            //    }
            //    //_logger.Log(LogLevel.Error,"Serialization Failed");
            //}
            //return BadRequest();

            //Test Code
            Console.WriteLine(ticket.ToString());

            if (ticket != null)
            {
                PostToTeamHood(ticket);
                Console.WriteLine(ticket.ToString());
                if (PostToTeamHood(ticket).IsCompletedSuccessfully)
                {
                    return new OkResult();
                }
                //_logger.Log(LogLevel.Error,"Serialization Failed");
            }
            return BadRequest();
        }

        public bool IsFull(string data)
        {
            if (data != null)
            {
                return true;
            }
            return false;
        }

        public Ticket DeserializeToObject(string data)
        {
            var ticket = JsonConvert.DeserializeObject<TicketDTO>(data).ticket;
            if (ticket != null)
            {
                return ticket;
            }
            return null;
        }
        public async Task<string> PostToTeamHood(Ticket ticket)
        {
            string operationsWorkspace = "3f2f775d-5724-43e1-9151-87f8fd655aff";
            var getworkspaces = GetWorkspaceID();
            var getboards = GetBoards();

            string serializedJson = JsonConvert.SerializeObject(ticket);
            HttpContent content = new StringContent(serializedJson, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(createItemURL),
                Content = content
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TeamHoodApiKey);
            string payload;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                payload = await response.Content.ReadAsStringAsync();
                var responseheader = response.Headers.ToString();
                Console.WriteLine(payload);
                //_logger.LogInformation(payload);
                Console.WriteLine(responseheader);
            }
            return serializedJson;
        }
        public async Task<string> GetWorkspaceID()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(getWorkspaces),
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TeamHoodApiKey);
            string json;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
                var responseheader = response.Headers.ToString();
                Console.WriteLine(json);
                Console.WriteLine(responseheader);
            }
            return json;
        }

        public async Task<string> GetBoards()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(getBoards),
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TeamHoodApiKey);
            string json;

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
                var responseheader = response.Headers.ToString();
                Console.WriteLine(json);
                Console.WriteLine(responseheader);
            }
            return json;
        }
    }
}

//
//var response = client.SendAsync(request).Result;
//data = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
//Console.WriteLine(data);
//

//}

#region old test ticketcreatedHandler
//[HttpGet]
//[ActionName("ticketcreated")]
//public async Task<IActionResult> TicketCreatedEventHandler()
//{
//    //Serialize the data we got from webhook and POST to teamhood API
//    //Part 1 Get the data from Teamwork
//    var client = new HttpClient();
//    var request = new HttpRequestMessage
//    {
//        Method = HttpMethod.Get,
//        RequestUri = new Uri(url),
//    };

//    //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
//    request.Headers.Add("X-Desk-Event", "ticket.created");          //The event name of the webhook
//    request.Headers.Add("X-Desk-Signature", TeamWorkAccessToken);   //Token
//    //request.Headers.Add("X-Desk-Delivery", "UUID");               //The delivery UUID, this is listed in the Recent Deliveries section of your webhook.
//    //request.Headers.Add("User-Agent", "v2");                      //The version of the webhooks service used to make this request is included in this header



//    //Part 2 Serialize the Json recieved and send to the Teamhood API
//    object data;
//    HttpContent content = new StringContent(serializedJson, Encoding.UTF8, "application/json");

//    //dont allow redirection
//    var handler = new HttpClientHandler();
//    handler.AllowAutoRedirect = false;
//    var senderClient = new HttpClient(handler);
//    try
//    {
//        var request2 = new HttpRequestMessage
//        {
//            Method = HttpMethod.Post,
//            RequestUri = new Uri("https://api-p5g8yky1i4u6cefmqwihnw.teamhood.com/api/v1/items"),
//            Content = content
//        };
//        request2.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TeamHoodApiKey);

//        //json = await response2.Content.ReadAsStringAsync();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.ToString());
//    }
//    RedirectToAction("GetTickets", "TicketsController", null);
//    return Ok();
//}
#endregion

//    }
//}
