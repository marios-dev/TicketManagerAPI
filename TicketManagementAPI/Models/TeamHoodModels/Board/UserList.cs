using Newtonsoft.Json;

namespace TicketManagementAPI.Models.TeamHoodModels.Board
{
    public partial class UserList
    {
        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public List<User> users { get; set; }
    }
}
