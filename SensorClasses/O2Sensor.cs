namespace SensorDefinitions;

public class O2Sensor : SensorBase
{
    public O2Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "o2", new MetricDefinition
                {
                    ShortName = "o2",
                    Unit = "ppm",
                    Precision = 0,
                    MidName = "o2",
                    Icon = "aranet:o2"
                }
            }
        };
    }
}
