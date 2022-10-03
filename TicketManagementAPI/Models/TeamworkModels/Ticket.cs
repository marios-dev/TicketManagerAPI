using Newtonsoft.Json;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        public partial class Ticket
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
            public string Subject { get; set; }

            [JsonProperty("readonly", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Readonly { get; set; }

            [JsonProperty("messageCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? MessageCount { get; set; }

            [JsonProperty("previewText", NullValueHandling = NullValueHandling.Ignore)]
            public string PreviewText { get; set; }

            [JsonProperty("originalRecipient")]
            public string OriginalRecipient { get; set; }

            [JsonProperty("responseTimeMins")]
            public long? ResponseTimeMins { get; set; }

            [JsonProperty("resolutionTimeMins", NullValueHandling = NullValueHandling.Ignore)]
            public long? ResolutionTimeMins { get; set; }

            [JsonProperty("imagesHidden", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ImagesHidden { get; set; }

            [JsonProperty("isRead", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsRead { get; set; }

            [JsonProperty("spam", NullValueHandling = NullValueHandling.Ignore)]
            public Spam Spam { get; set; }

            [JsonProperty("spam_score", NullValueHandling = NullValueHandling.Ignore)]
            public double? SpamScore { get; set; }

            [JsonProperty("spam_rules", NullValueHandling = NullValueHandling.Ignore)]
            public string SpamRules { get; set; }

            [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
            public Agent Customer { get; set; }

            [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
            public Agent Contact { get; set; }

            [JsonProperty("inbox", NullValueHandling = NullValueHandling.Ignore)]
            public Agent Inbox { get; set; }

            [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
            public Agent Status { get; set; }

            [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
            public Agent Source { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public Agent Type { get; set; }

            [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore)]
            public Agent UpdatedBy { get; set; }

            [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
            public List<Agent> Messages { get; set; }

            [JsonProperty("customfields", NullValueHandling = NullValueHandling.Ignore)]
            public List<Customfield> Customfields { get; set; }

            [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
            public List<Agent> Files { get; set; }

            [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
            public DateTimeOffset? CreatedAt { get; set; }

            [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
            public DateTimeOffset? UpdatedAt { get; set; }

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public State? State { get; set; }

            [JsonProperty("agent", NullValueHandling = NullValueHandling.Ignore)]
            public Agent Agent { get; set; }

            [JsonProperty("happinessRating", NullValueHandling = NullValueHandling.Ignore)]
            public Agent HappinessRating { get; set; }

            [JsonProperty("threademailrefs", NullValueHandling = NullValueHandling.Ignore)]
            public List<Agent> Threademailrefs { get; set; }

            [JsonProperty("companycustomers", NullValueHandling = NullValueHandling.Ignore)]
            public List<Agent> Companycustomers { get; set; }

            [JsonProperty("tasks", NullValueHandling = NullValueHandling.Ignore)]
            public List<Task> Tasks { get; set; }

            [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
            public Agent Priority { get; set; }
        }
    }
}
