using Newtonsoft.Json;

namespace WebHooks.API.Models.TicketList
{
    public class Customfield
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public CustomfieldType? Type { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public CustomfieldMeta Meta { get; set; }
    }
}
