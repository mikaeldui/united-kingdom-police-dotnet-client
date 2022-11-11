using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    internal class StringOrFalseJsonConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(string));
            if (reader.TokenType == JsonTokenType.False)
                return "false";
            return reader.GetString();
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            if (value == "false")
                writer.WriteBooleanValue(false);
            else
                writer.WriteStringValue(value.ToString());
        }
    }
}
