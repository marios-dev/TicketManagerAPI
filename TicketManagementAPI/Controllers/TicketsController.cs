using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TicketManagementAPI.Interfaces;
using TicketManagementAPI.Models.TeamHoodModels.Board;
using TicketManagementAPI.Models.TeamHoodModels.Workspaces;
using TicketManagementAPI.TeamworkModels;
using WebHooks.API.Models.TeamworkTicket;
using WebHooks.API.Models.TicketList;
using TicketList = WebHooks.API.Models.TicketList.TicketList;

namespace TicketManagementAPI.Controllers
{
    [Route("api/tickets/{action}")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        #region Variables and ctor
        private const string teamWorkAccessToken = "tkn.v1_MDJmYWY3MWUtMTQ0OC00ZWZmLWE1OTctZjRkNDUxYTEwNTk1LTYyODIxMi40ODAzNjguRVU=";
        private const string teamHoodApiKey = "03Z42VKARBRYIOZMSGLI9H66YWCA0HQCHFPC41Q0IG6BM1HPPN370H0L66HYH18M";
        private const string getAllUsersURL = "https://api-p5g8yky1i4u6cefmqwihnw.teamhood.com/api/v1/users";
        private const string getAllTicketsURL = "https://effectmakers1.eu.teamwork.com/desk/api/v2/tickets.json";
        private const string getLatestTicketID = $"https://effectmakers1.eu.teamwork.com/desk/api/v2/tickets/4533938.json";

        private readonly ITicketService _ticketservice;
        private readonly IBoardItemService _itemservice;
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(ILogger<TicketsController> logger, ITicketService ticketservice,IBoardItemService itemService)
        {
            _logger = logger;
            _ticketservice = ticketservice;
            _itemservice=itemService;
        }
        #endregion

        #region  Get All Tickets from WebHookController
        [HttpGet]
        public async Task<string> GetTickets()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(getAllTicketsURL),
            };
            string json;
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", teamWorkAccessToken);
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            var ticketList = JsonConvert.DeserializeObject<TicketList>(json);
            foreach (WebHooks.API.Models.TicketList.Ticket tick in ticketList.Tickets)
            {
                Console.WriteLine(tick.PreviewText);
                //all other properties
            }
            return json;
        }
        #endregion
        #region Get Latest Ticket from Teamwork API
        public async Task<string> GetTicket(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(getLatestTicketID),
            };
            string json;
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", teamWorkAccessToken);
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            var ticket = JsonConvert.DeserializeObject<TicketDTO>(json).ticket;
            WebHooks.API.PublicCode.CreateTicketWithJson(json);
            return json;
        }
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
                    RequestUri = new Uri(getAllUsersURL),
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", teamHoodApiKey);
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

        #region Get all Boards to get boardID required
        [HttpGet]
        public async Task<string> GetAllWorkspaces()
        {
            var client = new HttpClient();
            string json;
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://api-p5g8yky1i4u6cefmqwihnw.teamhood.com/api/v1/workspaces"),
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", teamHoodApiKey);
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
            var workspaces = JsonConvert.DeserializeObject<WorkspaceList>(json);
            return json;
        }
        #endregion
    }
}
