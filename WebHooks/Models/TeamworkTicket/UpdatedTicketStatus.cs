namespace WebHooks.API.Models.TeamworkTicket
{
    public partial class UpdatedTicketStatus
    {
        public Ticket Ticket { get; set; }
    }
    public partial class Ticket
    {
        public Status TicketStatus { get; set; }
    }

    public partial class Status
    {
        public long Id { get; set; }
    }
}