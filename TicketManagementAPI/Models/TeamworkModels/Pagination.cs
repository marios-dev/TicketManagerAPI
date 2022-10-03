﻿using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class Pagination
        {
            [JsonProperty("records", NullValueHandling = NullValueHandling.Ignore)]
            public long? Records { get; set; }

            [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
            public long? PageSize { get; set; }

            [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
            public long? Pages { get; set; }

            [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
            public long? Page { get; set; }

            [JsonProperty("hasMorePages", NullValueHandling = NullValueHandling.Ignore)]
            public bool? HasMorePages { get; set; }
        }
    }
}
