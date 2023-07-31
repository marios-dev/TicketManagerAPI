namespace TicketManagementAPI.Models.TeamHoodModels.Board
{
    public partial class Board
    {
        public List<BoardElement> Boards { get; set; }
    }

    public partial class BoardElement
    {
        public Guid Id { get; set; }
        public string DisplayId { get; set; }
        public string Title { get; set; }
    }
}
