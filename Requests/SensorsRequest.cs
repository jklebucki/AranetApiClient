using System.Text.Json.Serialization;

public class SensorsRequest
{
    [JsonPropertyName("settings")]
    public Settings Settings { get; set; } = new Settings();

    [JsonPropertyName("sensors_raw")]
    public int SensorsRaw { get; set; }

    [JsonPropertyName("currData")]
    public int CurrData { get; set; }

    [JsonPropertyName("alarms")]
    public int Alarms { get; set; }

    [JsonPropertyName("sensors")]
    public Sensors Sensors { get; set; } = new Sensors();

    [JsonPropertyName("pairing_status")]
    public int PairingStatus { get; set; }

    [JsonPropertyName("favourites")]
    public Favourites Favourites { get; set; } = new Favourites();

    public static SensorsRequest Default(string username)
    {
        return new SensorsRequest
        {
            Settings = new Settings
            {
                Get = new GetSettings
                {
                    Global = new GlobalSettings
                    {
                        Hardware = new List<string>
                        {
                            "ssid", "key", "encryption", "ipaddr", "proto", "netmask",
                            "gateway", "mode", "ethernet", "lte", "status", "gsm", "time"
                        },
                        Software = new List<string>
                        {
                            "smtp", "system", "snmp", "mqtt", "modbus"
                        }
                    },
                    User = new Dictionary<string, object>()
                }
            },
            SensorsRaw = 1,
            CurrData = 1,
            Alarms = 1,
            Sensors = new Sensors
            {
                GetLimits = 1,
                GetMetricInfo = 1
            },
            PairingStatus = 1,
            Favourites = new Favourites
            {
                Get = new List<string> { username }
            }
        };
    }
}

public class Settings
{
    [JsonPropertyName("get")]
    public GetSettings Get { get; set; } = new GetSettings();
}

public class GetSettings
{
    [JsonPropertyName("global")]
    public GlobalSettings Global { get; set; } = new GlobalSettings();

    [JsonPropertyName("user")]
    public Dictionary<string, object> User { get; set; } = new Dictionary<string, object>();
}

public class GlobalSettings
{
    [JsonPropertyName("hardware")]
    public List<string> Hardware { get; set; } = new List<string>();

    [JsonPropertyName("software")]
    public List<string> Software { get; set; } = new List<string>();
}

public class Sensors
{
    [JsonPropertyName("getLimits")]
    public int GetLimits { get; set; }

    [JsonPropertyName("getMetricInfo")]
    public int GetMetricInfo { get; set; }
}

public class Favourites
{
    [JsonPropertyName("get")]
    public List<string> Get { get; set; } = new List<string>();
}
