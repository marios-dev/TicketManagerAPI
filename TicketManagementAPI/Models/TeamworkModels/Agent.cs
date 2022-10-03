using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class Agent
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public AgentType? Type { get; set; }
        }
    }
}
