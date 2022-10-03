using Newtonsoft.Json;

namespace WebHooks.API.Models.TicketList
{
    internal class CustomfieldTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CustomfieldType) || t == typeof(CustomfieldType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "customfields")
            {
                return CustomfieldType.Customfields;
            }
            throw new Exception("Cannot unmarshal type CustomfieldType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CustomfieldType)untypedValue;
            if (value == CustomfieldType.Customfields)
            {
                serializer.Serialize(writer, "customfields");
                return;
            }
            throw new Exception("Cannot marshal type CustomfieldType");
        }

        public static readonly CustomfieldTypeConverter Singleton = new CustomfieldTypeConverter();
    }
}
