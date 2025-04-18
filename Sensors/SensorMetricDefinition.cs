using System.Text.Json;
using System.Text.Json.Serialization;

public class SensorMetricDefinition
{
    [JsonPropertyName("max")]
    public double? Max { get; set; }

    [JsonPropertyName("min")]
    public double? Min { get; set; }

    [JsonPropertyName("threshold")]
    public Dictionary<string, bool> Threshold { get; set; } = new Dictionary<string, bool>();

    [JsonPropertyName("hide")]
    public Dictionary<string, bool> Hide { get; set; } = new Dictionary<string, bool>();
}

public class SensorMetricDefinitionConverter : JsonConverter<SensorMetricDefinition>
{
    public override SensorMetricDefinition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Jeśli jest tablicą ([]), pomijamy
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            reader.Skip();
            return null!;
        }

        // Jeśli jest obiektem, deserializujemy normalnie
        using (var doc = JsonDocument.ParseValue(ref reader))
        {
            var json = doc.RootElement.GetRawText();
            return JsonSerializer.Deserialize<SensorMetricDefinition>(json, options)!;
        }
    }

    public override void Write(Utf8JsonWriter writer, SensorMetricDefinition value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}