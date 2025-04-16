namespace SensorDefinitions;

public class MetricDefinition
{
    public string ShortName {get; set; } = string.Empty;
    public string Unit {get; set; } = string.Empty;
    public int? Precision {get; set; }
    public string MidName {get; set; } = string.Empty;
    public string Icon {get; set; } = string.Empty;
}
