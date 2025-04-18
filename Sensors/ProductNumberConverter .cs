using System.Text.Json;
using System.Text.Json.Serialization;

public class ProductNumberConverter : JsonConverter<Dictionary<string, string>>
{
    public override Dictionary<string, string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = new Dictionary<string, string>();

        if (reader.TokenType == JsonTokenType.String)
        {
            result["0"] = reader.GetString()!;
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(ref reader, options);
            if (dict != null)
            {
                foreach (var kvp in dict)
                    result[kvp.Key] = kvp.Value;
            }
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, string> value, JsonSerializerOptions options)
    {
        if (value.Count == 1 && value.ContainsKey("0"))
        {
            writer.WriteStringValue(value["0"]);
        }
        else
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
