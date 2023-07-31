namespace TicketManagementAPI.Models.TeamHoodModels.Board
{
    public class BoardRow
    {
        public string Title { get; set; }
        public Guid? BoardID { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? RequestID { get; set; }
    }
}
