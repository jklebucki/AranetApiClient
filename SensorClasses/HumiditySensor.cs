namespace SensorDefinitions;

public class HumiditySensor : SensorBase
{
    public HumiditySensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "humidity", new MetricDefinition
                {
                    ShortName = "h",
                    Unit = "%",
                    Precision = 1,
                    MidName = "humi",
                    Icon = "water"
                }
            }
        };
    }
}
