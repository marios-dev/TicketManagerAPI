using Newtonsoft.Json;

namespace TicketManagementAPI.Models.TeamHoodModels.Workspaces
{
    public class Workspace
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }

        [JsonProperty("displayId", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    }
}
