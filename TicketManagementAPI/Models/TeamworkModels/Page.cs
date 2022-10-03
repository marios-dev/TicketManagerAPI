using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class Page
        {
            [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
            public long? Count { get; set; }

            [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
            public long? PageSize { get; set; }

            [JsonProperty("pageOffset", NullValueHandling = NullValueHandling.Ignore)]
            public long? PageOffset { get; set; }

            [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
            public long? Pages { get; set; }

            [JsonProperty("hasMore", NullValueHandling = NullValueHandling.Ignore)]
            public bool? HasMore { get; set; }
        }
    }
}
