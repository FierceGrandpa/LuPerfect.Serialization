using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace LuPerfect.Serialization.JsonConverters
{
    public class TimespanJsonConverter : JsonConverter<TimeSpan>
    {
        /// <summary>
        /// Format: Days.Hours:Minutes:Seconds:Milliseconds
        /// </summary>
        public const string TimeSpanFormatString = @"d\.hh\:mm\:ss\:FFF";

        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();

            if (string.IsNullOrWhiteSpace(s))
                return TimeSpan.Zero;

            if (!TimeSpan.TryParseExact(s, TimeSpanFormatString, null, out var parsedTimeSpan))
                throw new FormatException($"Временной интервал не соответствует ожидаемому формату : ожидалось {Regex.Unescape(TimeSpanFormatString)}. Получите этот ключ как строку и проанализируйте вручную.");

            return parsedTimeSpan;
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.ToString(TimeSpanFormatString)}");
        }
    }
}
