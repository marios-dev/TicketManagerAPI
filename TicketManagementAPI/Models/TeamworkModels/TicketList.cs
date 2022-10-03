using Newtonsoft.Json;
using TicketManagementAPI.Interfaces;
using TicketManagementAPI.Models.TeamHoodModels.Board;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList : ITicketService
    {
        [JsonProperty("tickets", NullValueHandling = NullValueHandling.Ignore)]
        public List<Ticket> Tickets { get; set; }

        [JsonProperty("included", NullValueHandling = NullValueHandling.Ignore)]
        public Included included { get; set; }

        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination pagination { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public TicketListMeta Meta { get; set; }

        public void GetTicket()
        {
            Ticket ticket = new Ticket();
            
        }

        public void PassTicket(BoardItem boardItem)
        {
            throw new NotImplementedException();
        }

        public partial class Included
        {
        }
    }
}
