using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;

namespace TicketManagementAPI.TeamworkModels
{
    public partial class TicketList
    {
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                AgentTypeConverter.Singleton,
                CustomfieldTypeConverter.Singleton,
                StateConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    }
}
