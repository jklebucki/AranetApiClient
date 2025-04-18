using System.Text.Json.Serialization;
namespace AranetApiClient.Sensors;
public class ProbeInfo
{
    [JsonPropertyName("type")]
    public int Type { get; set; }
}