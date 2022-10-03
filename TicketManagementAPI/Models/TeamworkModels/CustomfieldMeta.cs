using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class CustomfieldMeta
        {
            [JsonProperty("value")]
            public object Value { get; set; }
        }
    }
}
