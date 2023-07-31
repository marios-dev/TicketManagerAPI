namespace TicketManagementAPI.Models.TeamHoodModels.Board
{
    public partial class Status
    {
        public List<StatusElement> Statuses { get; set; }
    }

    public partial class StatusElement
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public long? Index { get; set; }
    }
}
