using Newtonsoft.Json;
using WebHooks.API.Models.TeamworkTicket;
using WebHooks.API.Models.TicketList;

namespace WebHooks.API
{
    public static class PublicCode
    {
        public static void CreateTicketWithJson(string json)
        {
            var ticket= JsonConvert.DeserializeObject<TicketDTO>(json).ticket;
            var result = new WebHooks.API.Controllers.WebhookController().WebhookReceiver(ticket);
        }
    }
}
