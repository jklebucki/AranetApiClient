namespace SensorDefinitions;

public class Temperature1Sensor : SensorBase
{
    public Temperature1Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "temperature1", new MetricDefinition
                {
                    ShortName = "t1",
                    Unit = "C",
                    Precision = 2,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
