using Newtonsoft.Json;

namespace WebHooks.API.Models.TeamworkTicket
{
    public class TicketList 
    {
        [JsonProperty("tickets", NullValueHandling = NullValueHandling.Ignore)]
        public List<Ticket> Tickets { get; set; }

        [JsonProperty("included", NullValueHandling = NullValueHandling.Ignore)]
        public Included included { get; set; }

        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination pagination { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public TicketListMeta Meta { get; set; }

        public partial class Included
        {
        }
    }
}
