using Newtonsoft.Json;
using static TicketManagementAPI.TeamworkModels.TicketList;

namespace TicketManagementAPI.Models.TeamHoodModels.TicketList
{
    public partial class TicketDTO
    {
        public Ticket ticket { get; set; }
        public Included? Included { get; set; }
    }

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
        public Customer customer { get; set; }

        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public Agent Contact { get; set; }

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
        public List<CustomField> Customfields { get; set; }

        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public List<File> Files { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
    public partial class Included
    {
        public List<Company> Companies { get; set; }
        public List<CustomField> CustomFields { get; set; }
        public List<Agent> Contacts { get; set; }
        public List<CustomerTicketsReads> CustomerTicketsReads { get; set; }
        public List<Customer> Customers { get; set; }
        public List<File> Files { get; set; }
        public List<Inbox> Inboxes { get; set; }
        public List<Message> Messages { get; set; }
        public List<Tag> Tags { get; set; }
        public List<TicketActivity> TicketActivities { get; set; }
        public List<TicketSource> TicketSources { get; set; }
        public List<TicketStatus> TicketStatuses { get; set; }
        public List<TicketType> TicketTypes { get; set; }
        public List<User> Users { get; set; }
    }
    public partial class CustomerCompany
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("meta")]
        public CompanyMeta Meta { get; set; }
    }
    public partial class CompanyMeta
    {
        [JsonProperty("addMethod")]
        public string AddMethod { get; set; }
    }
    public enum TypeEnum { Companies, Contacts, Customers, Customfieldapps, Domains, Files, Inboxes, Messages, Tags, Ticketactivities, Tickets, Ticketsources, Ticketstatuses, Tickettypes, Users };

    public enum State { Active };

    public enum Disposition { Attachment };

    public enum Filename { AtCpdSoDmMarktCsv, AtCpdSoReweCsv };

    public enum MimeType { TextCsv };

    public enum DeliveryMethod { Empty, Sendgrid };

    public enum DeliveryStatus { Delivered, Empty };

    public enum EditMethod { Html };

    public enum ThreadType { EventInfo, Message };

    public enum Color { F0935A, The1Dc8E8, The2Cc649, The336699, The3790E2, The54C248, The56B0F5 };

    public enum EventType { Assign, Message, New, Read, Status, Tagadded, Unassign };

    public enum Icon { ActivePng, AssignedPng, CustomStatusPng, RepliedPng, TagAddedPng, WaitingPng };
    public partial class TicketSource
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("displayOrder")]
        public int DisplayOrder { get; set; }
        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
        [JsonProperty("createdBy")]
        public Agent CreatedBy { get; set; }
        [JsonProperty("updatedBy")]
        public Agent UpdatedBy { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
    public partial class TicketType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public List<Inbox> Inboxes { get; set; }
        public bool Default { get; set; }
        public bool EnabledForFutureInboxes { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Agent CreatedBy { get; set; }
        public Agent UpdatedBy { get; set; }
        public string State { get; set; }
    }
    public class TicketStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsCustom { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Agent CreatedBy { get; set; }
        public Agent UpdatedBy { get; set; }
        public string State { get; set; }
    }
    public partial class TicketListMeta
    {
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public Page Page { get; set; }
    }
    public partial class TicketActivityTicket
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
    public partial class TicketActivity
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
    public partial class TaskMeta
    {
        [JsonProperty("completed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Completed { get; set; }
    }
    public partial class Task
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public TaskMeta Meta { get; set; }
    }
    public partial class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Agent CreatedBy { get; set; }
        public Agent UpdatedBy { get; set; }
        public string State { get; set; }
    }
    public partial class Spam
    {
        [JsonProperty("reports")]
        public object Reports { get; set; }

        [JsonProperty("isSpam", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSpam { get; set; }

        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public long? Score { get; set; }

        [JsonProperty("reasons")]
        public object Reasons { get; set; }
    }
    public partial class Page
    {
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }

        [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public long? PageSize { get; set; }

        [JsonProperty("pageOffset", NullValueHandling = NullValueHandling.Ignore)]
        public long? PageOffset { get; set; }

        [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pages { get; set; }

        [JsonProperty("hasMore", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasMore { get; set; }
    }
    public partial class Message
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
    public partial class Inbox
    {
    }
    public partial class File
    {
        public int Id { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }
        public int Size { get; set; }
        public string Attachment { get; set; }
        public string DownloadURL { get; set; }
        public string S3Path { get; set; }
        public int PixelHeight { get; set; }
        public int PixelWidth { get; set; }
        public string Customer { get; set; }
        public string ProxyKey { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Agent CreatedBy { get; set; }
        public Agent UpdatedBy { get; set; }
    }
    public partial class Domain
    {
    }
    public partial class CustomfieldMeta
    {
        [JsonProperty("value")]
        public object Value { get; set; }
    }
    //public enum CustomfieldType { Customfields };
    //public partial class Customfield
    //{
    //    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? Id { get; set; }

    //    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    //    public CustomfieldType? Type { get; set; }

    //    [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
    //    public CustomfieldMeta Meta { get; set; }
    //}

    public partial class CustomField
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public partial class CustomerTicketsReadsTicket
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
    public partial class CustomerTicketsReadsMessage
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
    public partial class CustomerTicketsReadsCustomer
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
    public partial class CustomerTicketsReads
    {
        public long ID { get; set; }
        public CustomerTicketsReadsCustomer Customer { get; set; }
        public CustomerTicketsReadsTicket Ticket { get; set; }
        public CustomerTicketsReadsMessage Message { get; set; }
        public string CreatedAt { get; set; }
        public void GetCustomer()
        {
            CustomerTicketsReadsCustomer customer = new CustomerTicketsReadsCustomer();
        }
        public void GetTicket()
        {
            CustomerTicketsReadsTicket ticket = new CustomerTicketsReadsTicket();
        }
        public void GetMessage()
        {
            CustomerTicketsReadsMessage message = new CustomerTicketsReadsMessage();
        }
    }

    public partial class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarURL { get; set; }
        public string EditMethod { get; set; }
        public bool IsPartTime { get; set; }
        public string TicketReplyRedirect { get; set; }
        public bool Reviewer { get; set; }
        public string TrainingWheelsEnrollment { get; set; }
        public string Role { get; set; }
        public bool SendPushNotifications { get; set; }
        public bool SendWebNotifications { get; set; }
        public bool AutoFollowOnCC { get; set; }
        public int TimeFormatID { get; set; }
        public int TimeZoneID { get; set; }
        public int ProjectsCompanyID { get; set; }
        public bool IsAppOwner { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Agent CreatedBy { get; set; }
        public Agent UpdatedBy { get; set; }
        public string State { get; set; }
    }
    public partial class Customer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("organization")]
        public string Organization { get; set; }

        [JsonProperty("extraData")]
        public string ExtraData { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("verifiedEmail")]
        public bool VerifiedEmail { get; set; }

        [JsonProperty("permission")]
        public string Permission { get; set; }

        [JsonProperty("linkedinURL")]
        public string LinkedinUrl { get; set; }

        [JsonProperty("facebookURL")]
        public string FacebookUrl { get; set; }

        [JsonProperty("twitterHandle")]
        public string TwitterHandle { get; set; }

        [JsonProperty("numTickets")]
        public long NumTickets { get; set; }

        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("avatarURL")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("contacts")]
        public List<Agent> Contacts { get; set; }

        [JsonProperty("customerwelcomeemails")]
        public object Customerwelcomeemails { get; set; }

        [JsonProperty("trusted")]
        public bool Trusted { get; set; }

        [JsonProperty("welcomeEmailSent")]
        public bool WelcomeEmailSent { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("createdBy")]
        public Agent CreatedBy { get; set; }

        [JsonProperty("updatedBy")]
        public Agent UpdatedBy { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public partial class Contact
    {
        //public string Name { get; set; }
        public long ID { get; set; }
        public string Type { get; set; }

    }
    public partial class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Details { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string avatarPath { get; set; }
        public string Permissions { get; set; }
        public string Kind { get; set; }
        public int CustomersCount { get; set; }
        public List<Domain> Domains { get; set; }
    }
    public enum AgentType
    { Contacts, Customers, Files, Happinessratings, Inboxes, Messages, Threademailrefs, Ticketpriorities, Ticketsources, Ticketstatuses, Tickettypes, Users }
    public partial class Agent
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("agent_type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("isMain", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsMain { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; set; }

        [JsonProperty("createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public Agent CreatedBy { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? State { get; set; }
    }
}
