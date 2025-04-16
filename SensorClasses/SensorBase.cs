namespace SensorDefinitions;

public abstract class SensorBase
{
    public string ProductNumber { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public Dictionary<string, MetricDefinition> Metrics { get; set; } = new Dictionary<string, MetricDefinition>();
}
