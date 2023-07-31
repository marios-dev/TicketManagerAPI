namespace WebHooks.API.Models.TicketEventObjects
{
    public partial class TicketPriority
    {
        public long EventCreatorId { get; set; }
        public long Id { get; set; }
        public Priority Priority { get; set; }
    }
    public partial class Priority
    {
        public string Color { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public long SortOrder { get; set; }
    }
}
