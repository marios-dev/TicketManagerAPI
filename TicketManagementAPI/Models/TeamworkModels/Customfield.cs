using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class Customfield
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public CustomfieldType? Type { get; set; }

            [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
            public CustomfieldMeta Meta { get; set; }
        }
    }
}
