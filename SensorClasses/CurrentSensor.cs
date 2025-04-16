namespace SensorDefinitions;

public class CurrentSensor : SensorBase
{
    public CurrentSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "current", new MetricDefinition
                {
                    ShortName = "i",
                    Unit = "A",
                    Precision = 6,
                    MidName = "curr",
                    Icon = "aranet:ammeter-symbol"
                }
            }
        };
    }
}
