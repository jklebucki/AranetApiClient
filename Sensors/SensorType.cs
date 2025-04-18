using System.Text.Json.Serialization;
namespace AranetApiClient.Sensors;
public class SensorType
{
    [JsonPropertyName("icon")]
    public string Icon { get; set; } = string.Empty;

    [JsonPropertyName("metrics")]
    [JsonConverter(typeof(MetricsDictionaryConverter))]
    public Dictionary<string, SensorMetricDefinition> Metrics { get; set; } = new Dictionary<string, SensorMetricDefinition>();

    [JsonPropertyName("productNumber")]
    [JsonConverter(typeof(ProductNumberConverter))]
    public ProductNumber ProductNumber { get; set; } = new ProductNumber();
}

public class SensorTypeCollection : Dictionary<string, Dictionary<string, SensorType>> { }