using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class TaskMeta
        {
            [JsonProperty("completed", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Completed { get; set; }
        }
    }
}
