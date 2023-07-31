using Newtonsoft.Json;
using WebHooks.API.Interfaces;

namespace WebHooks.API.Models.TicketEventObjects
{
    public partial class TicketStatus:IDeserializable<TicketStatus> 
    {
        public long Id { get; set; }
        public long EventCreatorId { get; set; }
        public Status Status { get; set; }

        public TicketStatus Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<TicketStatus>(json) ?? new TicketStatus();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public partial class Status
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
    }
}
