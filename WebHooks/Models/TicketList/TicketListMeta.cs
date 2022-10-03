using Newtonsoft.Json;

namespace WebHooks.API.Models.TicketList
{
    public class TicketListMeta
    {
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public Page Page { get; set; }
    }
}
