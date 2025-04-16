namespace SensorDefinitions;

public class Nh3Sensor : SensorBase
{
    public Nh3Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "nh3", new MetricDefinition
                {
                    ShortName = "nh3",
                    Unit = "ppm",
                    Precision = 2,
                    MidName = "nh3",
                    Icon = "aranet:nh3"
                }
            }
        };
    }
}
