using Newtonsoft.Json;

namespace WebHooks.API.Models.TicketList
{
    public class Task
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        //[JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        //public TaskMeta Meta { get; set; }
    }
}
