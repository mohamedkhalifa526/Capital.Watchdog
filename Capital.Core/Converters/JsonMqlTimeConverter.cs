using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Capital.Core.Converters
{
    namespace SystemTextJsonSamples
    {
        public class JsonMqlTimeConverter : JsonConverter<DateTime>
        {
            private const string _format = "yyyy.MM.dd HH:mm:ss";

            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (string.IsNullOrEmpty(reader.GetString()))
                    return default;

                bool converted = DateTime.TryParseExact(reader.GetString()!, _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt);
                return converted ? dt : default;
            }

            public override void Write(Utf8JsonWriter writer, DateTime dateTimeValue, JsonSerializerOptions options)
                => writer.WriteStringValue(dateTimeValue.ToString(_format, CultureInfo.InvariantCulture));
        }
    }
}