namespace SensorDefinitions;

public class DistanceSensor : SensorBase
{
    public DistanceSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "distance", new MetricDefinition
                {
                    ShortName = "dist",
                    Unit = "m",
                    Precision = 3,
                    MidName = "dist",
                    Icon = "ruler"
                }
            }
        };
    }
}
