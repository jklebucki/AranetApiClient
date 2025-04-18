using System.Text.Json;
using System.Text.Json.Serialization;

public class MetricsDictionaryConverter : JsonConverter<Dictionary<string, SensorMetricDefinition>>
{
    public override Dictionary<string, SensorMetricDefinition> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = new Dictionary<string, SensorMetricDefinition>();

        using (JsonDocument document = JsonDocument.ParseValue(ref reader))
        {
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Object)
                {
                    var value = property.Value.Deserialize<SensorMetricDefinition>(options);
                    result[property.Name] = value!;
                }
                else
                {
                    // obsługa przypadków typu []
                    result[property.Name] = null!;
                }
            }
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, SensorMetricDefinition> value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
