using System.Text.Json.Serialization;

namespace AranetApiClient.Sensors;
public class SensorDefinition
{
    public string Icon { get; set; } = string.Empty;

    // Klucz: np. "temperature", "co2", "vwc"
    [JsonConverter(typeof(MetricsConverter))]
    public Dictionary<string, MetricDefinition> Metrics { get; set; } = new Dictionary<string, MetricDefinition>();

    // Może być string albo Dictionary<int, string> — więc uniwersalnie:
    [JsonConverter(typeof(ProductNumberConverter))]
    public Dictionary<string, string> ProductNumbers { get; set; } = new Dictionary<string, string>();
}
