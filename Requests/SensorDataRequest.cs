using System.Text.Json.Serialization;

public class SensorDataRequest
{
    [JsonPropertyName("from")]
    public int From { get; set; }
    [JsonPropertyName("to")]
    public int To { get; set; }
    [JsonPropertyName("sensor")]
    public string Sensor { get; set; } = string.Empty;
}