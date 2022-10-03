using Newtonsoft.Json;

namespace WebHooks.API.Models.TicketList
{
    public class CustomfieldMeta
    {
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
