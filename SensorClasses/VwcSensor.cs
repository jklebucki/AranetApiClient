namespace SensorDefinitions;

public class VwcSensor : SensorBase
{
    public VwcSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "vwc", new MetricDefinition
                {
                    ShortName = "vwc",
                    Unit = "/",
                    Precision = 3,
                    MidName = "",
                    Icon = "cup-water"
                }
            }
        };
    }
}
