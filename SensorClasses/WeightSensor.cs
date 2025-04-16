namespace SensorDefinitions;

public class WeightSensor : SensorBase
{
    public WeightSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "weight", new MetricDefinition
                {
                    ShortName = "w",
                    Unit = "kg",
                    Precision = 3,
                    MidName = "wght",
                    Icon = "weight"
                }
            }
        };
    }
}
