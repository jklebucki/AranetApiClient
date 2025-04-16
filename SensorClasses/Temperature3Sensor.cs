namespace SensorDefinitions;

public class Temperature3Sensor : SensorBase
{
    public Temperature3Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "temperature3", new MetricDefinition
                {
                    ShortName = "t3",
                    Unit = "C",
                    Precision = 2,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
