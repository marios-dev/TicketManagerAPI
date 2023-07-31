using Newtonsoft.Json;
using WebHooks.API.Interfaces;

namespace WebHooks.API.Models.TeamworkTicket
{
    public partial class CloseTicketObject:IDeserializable<CloseTicketObject>
    {
        public TicketObject Ticket { get; set; }

        public CloseTicketObject Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<CloseTicketObject>(json) ?? new CloseTicketObject();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public partial class TicketObject
    {
        public TicketObjectStatus Status { get; set; }
    }
    public partial class TicketObjectStatus
    {
        public int Id { get; set; }
    }
}
