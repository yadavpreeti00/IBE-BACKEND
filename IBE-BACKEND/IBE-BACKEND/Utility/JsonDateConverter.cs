using Newtonsoft.Json;

namespace IBE_BACKEND.Utility
{
    public class JsonDateConverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is DateTime dateTime)
            {
                return dateTime;
            }
            else if (reader.Value is string stringValue && DateTime.TryParse(stringValue, out DateTime parsedDateTime))
            {
                return parsedDateTime;
            }

            throw new JsonSerializationException($"Unable to parse DateTime from {reader.Value}");
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}