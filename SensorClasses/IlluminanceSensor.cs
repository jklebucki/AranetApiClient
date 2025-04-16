namespace SensorDefinitions;

public class IlluminanceSensor : SensorBase
{
    public IlluminanceSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "illuminance", new MetricDefinition
                {
                    ShortName = "il",
                    Unit = "lx",
                    Precision = 0,
                    MidName = "",
                    Icon = "lightbulb-on"
                }
            }
        };
    }
}
