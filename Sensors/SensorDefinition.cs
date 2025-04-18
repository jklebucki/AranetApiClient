using System.Text.Json.Serialization;

namespace AranetApiClient.Sensors;
public class SensorDefinition
{
    [JsonPropertyName("icon")]
    public string Icon { get; set; } = string.Empty;

    // Klucz: np. "temperature", "co2", "vwc"
    [JsonPropertyName("metrics")]
    [JsonConverter(typeof(MetricsConverter))]
    public Dictionary<string, MetricDefinition> Metrics { get; set; } = new Dictionary<string, MetricDefinition>();

    // Może być string albo Dictionary<int, string> — więc uniwersalnie:
    [JsonPropertyName("productNumber")]
    [JsonConverter(typeof(ProductNumberConverter))]
    public ProductNumber ProductNumbers { get; set; } = new();
}
