using System.Text.Json;
using System.Text.Json.Serialization;
namespace AranetApiClient.Sensors;
public class SensorType
{
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("metrics")]
    public Dictionary<string, SensorMetricDefinition> Metrics { get; set; }

    [JsonPropertyName("productNumber")]
    [JsonConverter(typeof(ProductNumberConverter))]
    public ProductNumber ProductNumber { get; set; }
}

public class SensorTypeCollection : Dictionary<string, Dictionary<string, SensorType>> { }