using Newtonsoft.Json;

namespace WebHooks.API.Models.TicketList
{
    public class Agent
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public AgentType? Type { get; set; }
    }
}
