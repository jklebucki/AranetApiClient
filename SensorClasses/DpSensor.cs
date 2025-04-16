namespace SensorDefinitions;

public class DpSensor : SensorBase
{
    public DpSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "dp", new MetricDefinition
                {
                    ShortName = "dp",
                    Unit = "",
                    Precision = 6,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
