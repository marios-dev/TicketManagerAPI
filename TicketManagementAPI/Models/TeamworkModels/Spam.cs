using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class Spam
        {
            [JsonProperty("reports")]
            public object Reports { get; set; }

            [JsonProperty("isSpam", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsSpam { get; set; }

            [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
            public long? Score { get; set; }

            [JsonProperty("reasons")]
            public object Reasons { get; set; }
        }
    }
}
