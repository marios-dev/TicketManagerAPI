namespace TicketManagementAPI.Models.TeamHoodModels.Task
{
    public partial class TaskDTO
    {
        public string Title { get; set; }
        public Guid BoardId { get; set; }
        public Guid? AssignedUserId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid RowId { get; set; }
        public Guid StatusId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public long? Color { get; set; }
        public string Description { get; set; }
        public long? Budget { get; set; }
        public long? Estimation { get; set; }
        public bool Completed { get; set; }
        public Guid WorkspaceId { get; set; }
        public bool Milestone { get; set; }
        public long? Progress { get; set; }
        public bool IsSuspended { get; set; }
        public string SuspendReason { get; set; }
        public List<CustomField> CustomFields { get; set; }
        public List<string> Tags { get; set; }
    }

    public partial class CustomField
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
