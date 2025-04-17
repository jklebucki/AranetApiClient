using System.Text.Json.Serialization;

public class SensorRequest
{
    [JsonPropertyName("from")]
    public int From { get; set; }
    [JsonPropertyName("to")]
    public int To { get; set; }
    [JsonPropertyName("sensor")]
    public string Sensor { get; set; } = string.Empty;
}