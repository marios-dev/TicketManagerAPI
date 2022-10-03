using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class Task
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
            public TaskMeta Meta { get; set; }
        }
    }
}
