using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gruppe9.Converters
{
    public class DateOnlyConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                var root = doc.RootElement;

                if (root.TryGetProperty("year", out var yearProp) &&
                    root.TryGetProperty("month", out var monthProp) &&
                    root.TryGetProperty("day", out var dayProp))
                {
                    int year = yearProp.GetInt32();
                    int month = monthProp.GetInt32();
                    int day = dayProp.GetInt32();

                    return new DateTime(year, month, day).ToString("yyyy-MM-dd");
                }
            }

            throw new JsonException("Ugyldig datoformat i API-respons.");
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value); // Ikke brukt i vårt tilfelle
        }
    }
}
