using Newtonsoft.Json;

namespace TicketManagementAPI.Models.TeamHoodModels.Board
{
    public partial class User
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }
        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public Status? Status { get; set; }

        [JsonProperty("accessibleWorkspaces", NullValueHandling = NullValueHandling.Ignore)]
        public List<Guid> AccessibleWorkspaces { get; set; }
    }
}
