using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class TicketListMeta
        {
            [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
            public Page Page { get; set; }
        }
    }
}
