using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    internal class YearMonthJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            var s = reader.GetString();
            return new DateTime(int.Parse(s[..4]), int.Parse(s.Substring(5, 2)), 1);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM"));
        }
    }
}
