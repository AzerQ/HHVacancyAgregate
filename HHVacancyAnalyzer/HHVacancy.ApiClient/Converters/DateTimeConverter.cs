using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace HHVacancy.ApiClient.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string _format = "yyyy-MM-ddTHH:mm:ssK";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (DateTime.TryParseExact(value, _format, null, System.Globalization.DateTimeStyles.None, out var result))
            {
                return result;
            }
            throw new JsonException($"Unable to convert \"{value}\" to DateTime using format \"{_format}\".");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }
}
