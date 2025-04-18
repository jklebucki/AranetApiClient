using System.Text.Json;
using System.Text.Json.Serialization;
namespace AranetApiClient.Sensors;
public class MetricsConverter : JsonConverter<Dictionary<string, MetricDefinition>>
{
    public override Dictionary<string, MetricDefinition> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = new Dictionary<string, MetricDefinition>();

        using var doc = JsonDocument.ParseValue(ref reader);
        foreach (var prop in doc.RootElement.EnumerateObject())
        {
            if (prop.Value.ValueKind == JsonValueKind.Object)
            {
                var metric = prop.Value.Deserialize<MetricDefinition>(options);
                result[prop.Name] = metric!;
            }
            else if (prop.Value.ValueKind == JsonValueKind.Array)
            {
                // Pusta lista → metryka bez dodatkowych właściwości
                result[prop.Name] = null!; // lub new MetricDefinition() jeśli wolisz
            }
            else
            {
                // Nieobsługiwany przypadek – np. liczba, string
                throw new JsonException($"Unexpected value for metric '{prop.Name}': {prop.Value.ValueKind}");
            }
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, MetricDefinition> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        foreach (var kvp in value)
        {
            if (kvp.Value == null)
            {
                writer.WriteStartArray(kvp.Key);
                writer.WriteEndArray();
            }
            else
            {
                writer.WritePropertyName(kvp.Key);
                JsonSerializer.Serialize(writer, kvp.Value, options);
            }
        }
        writer.WriteEndObject();
    }
}
