using Newtonsoft.Json;
using WebHooks.API.Models.TicketList;

namespace WebHooks.API.Models.TeamworkTicket
{
    public class Ticket
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

        [JsonProperty("originalRecipient", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalRecipient { get; set; }

        [JsonProperty("responseTimeMins")]
        public object ResponseTimeMins { get; set; }

        [JsonProperty("resolutionTimeMins", NullValueHandling = NullValueHandling.Ignore)]
        public long? ResolutionTimeMins { get; set; }

        [JsonProperty("imagesHidden", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ImagesHidden { get; set; }

        [JsonProperty("isRead", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRead { get; set; }

        [JsonProperty("spam", NullValueHandling = NullValueHandling.Ignore)]
        public Spam Spam { get; set; }

        [JsonProperty("spam_score", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpamScore { get; set; }

        [JsonProperty("spam_rules", NullValueHandling = NullValueHandling.Ignore)]
        public string SpamRules { get; set; }

        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Customer { get; set; }

        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Contact { get; set; }

        [JsonProperty("inbox", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Inbox { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Status { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Source { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Type { get; set; }

        [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public Contact UpdatedBy { get; set; }

        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public List<Contact> Messages { get; set; }

        [JsonProperty("customfields", NullValueHandling = NullValueHandling.Ignore)]
        public List<Customfield> Customfields { get; set; }

        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public List<Contact> Files { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
