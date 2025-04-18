using System.Text.Json.Serialization;
namespace AranetApiClient.Sensors;
public class SensorRaw
{
    [JsonPropertyName("channel")]
    public int Channel { get; set; }

    [JsonPropertyName("fw")]
    public int? Firmware { get; set; }

    [JsonPropertyName("groupThresh")]
    public bool? GroupThreshold { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("pairTime")]
    public long PairTime { get; set; }

    [JsonPropertyName("txInt")]
    public int TxInterval { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("variant")]
    public int Variant { get; set; }

    [JsonPropertyName("probe")]
    public ProbeInfo Probe { get; set; } = new ProbeInfo();
}

public class SensorRawCollection : Dictionary<string, SensorRaw> { }