using Newtonsoft.Json;
using WebHooks.API.Interfaces;

namespace WebHooks.API.Models;

public partial class ResponseTask : IDeserializable<ResponseTask>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool? Completed { get; set; }
    public long? Color { get; set; }
    public string DisplayId { get; set; }
    public string Description { get; set; }
    public long? Budget { get; set; }
    public long? Estimation { get; set; }
    public string EstimationType { get; set; }
    public Uri Url { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? DueDate { get; set; }
    public Guid? OwnerId { get; set; }
    public Guid? AssignedUserId { get; set; }
    public Guid? BoardId { get; set; }
    public Guid? RowId { get; set; }
    public Guid? StatusId { get; set; }
    public Guid? WorkspaceId { get; set; }
    public long? TotalLoggedTime { get; set; }
    public bool? Milestone { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public bool? IsSuspended { get; set; }
    public string SuspendReason { get; set; }
    public List<string> Tags { get; set; }
    [JsonProperty("customfields")]
    public List<ResponseCustomField> ResponseCustomFields { get; set; }

    public ResponseTask Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<ResponseTask>(json) ?? new ResponseTask();
    }

    public void GetCommendCustomField(string commend)
    {
        ResponseCustomField field = new ResponseCustomField();
        field.Name = "Comment";
        field.Value = $"{commend}";
        ResponseCustomFields.Add(field);
    }

    public string Serialize()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public partial class ResponseCustomField
{
    public string Name { get; set; }
    public string Value { get; set; }
}
