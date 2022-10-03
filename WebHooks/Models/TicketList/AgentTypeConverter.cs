using Newtonsoft.Json;

namespace WebHooks.API.Models.TicketList
{
    internal class AgentTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AgentType) || t == typeof(AgentType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "contacts":
                    return AgentType.Contacts;
                case "customers":
                    return AgentType.Customers;
                case "files":
                    return AgentType.Files;
                case "happinessratings":
                    return AgentType.Happinessratings;
                case "inboxes":
                    return AgentType.Inboxes;
                case "messages":
                    return AgentType.Messages;
                case "threademailrefs":
                    return AgentType.Threademailrefs;
                case "ticketpriorities":
                    return AgentType.Ticketpriorities;
                case "ticketsources":
                    return AgentType.Ticketsources;
                case "ticketstatuses":
                    return AgentType.Ticketstatuses;
                case "tickettypes":
                    return AgentType.Tickettypes;
                case "users":
                    return AgentType.Users;
            }
            throw new Exception("Cannot unmarshal type AgentType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AgentType)untypedValue;
            switch (value)
            {
                case AgentType.Contacts:
                    serializer.Serialize(writer, "contacts");
                    return;
                case AgentType.Customers:
                    serializer.Serialize(writer, "customers");
                    return;
                case AgentType.Files:
                    serializer.Serialize(writer, "files");
                    return;
                case AgentType.Happinessratings:
                    serializer.Serialize(writer, "happinessratings");
                    return;
                case AgentType.Inboxes:
                    serializer.Serialize(writer, "inboxes");
                    return;
                case AgentType.Messages:
                    serializer.Serialize(writer, "messages");
                    return;
                case AgentType.Threademailrefs:
                    serializer.Serialize(writer, "threademailrefs");
                    return;
                case AgentType.Ticketpriorities:
                    serializer.Serialize(writer, "ticketpriorities");
                    return;
                case AgentType.Ticketsources:
                    serializer.Serialize(writer, "ticketsources");
                    return;
                case AgentType.Ticketstatuses:
                    serializer.Serialize(writer, "ticketstatuses");
                    return;
                case AgentType.Tickettypes:
                    serializer.Serialize(writer, "tickettypes");
                    return;
                case AgentType.Users:
                    serializer.Serialize(writer, "users");
                    return;
            }
            throw new Exception("Cannot marshal type AgentType");
        }

        public static readonly AgentTypeConverter Singleton = new AgentTypeConverter();
    }
}
