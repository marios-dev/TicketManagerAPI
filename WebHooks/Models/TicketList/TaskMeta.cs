using Newtonsoft.Json;

namespace WebHooks.API.Models.TicketList
{
    public class TaskMeta
    {
        [JsonProperty("completed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Completed { get; set; }
    }
}
