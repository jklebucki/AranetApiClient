namespace SensorDefinitions;

public class Temperature2Sensor : SensorBase
{
    public Temperature2Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "temperature2", new MetricDefinition
                {
                    ShortName = "t2",
                    Unit = "C",
                    Precision = 2,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
