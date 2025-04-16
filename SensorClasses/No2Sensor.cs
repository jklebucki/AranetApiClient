namespace SensorDefinitions;

public class No2Sensor : SensorBase
{
    public No2Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "no2", new MetricDefinition
                {
                    ShortName = "no2",
                    Unit = "ppm",
                    Precision = 2,
                    MidName = "no2",
                    Icon = "aranet:no2"
                }
            }
        };
    }
}
