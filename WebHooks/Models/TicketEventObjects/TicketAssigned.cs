namespace WebHooks.API.Models.TicketEventObjects
{
    public partial class TicketAssigned
    {
        public Agent Agent { get; set; }
        public long EventCreatorId { get; set; }
        public long Id { get; set; }
    }

    public partial class Agent
    {
        public Uri AvatarUrl { get; set; }
        public string FirstName { get; set; }
        public long Id { get; set; }
        public string LastName { get; set; }
    }
}
