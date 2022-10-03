using Newtonsoft.Json;

namespace TicketManagementAPI.Models.TeamHoodModels.Workspaces
{
    public class WorkspaceList
    {

        [JsonProperty("workspaces", NullValueHandling = NullValueHandling.Ignore)]
        public List<Workspace> Workspaces { get; set; }
    }
}
