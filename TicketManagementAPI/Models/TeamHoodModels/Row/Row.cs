namespace TicketManagementAPI.Models.TeamHoodModels.Row
{
    public partial class Row
    {
        public List<RowElement> Rows { get; set; }
    }

    public partial class RowElement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public long Index { get; set; }
    }
}
