namespace SensorDefinitions;

public class DerivedSensor : SensorBase
{
    public DerivedSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "derived", new MetricDefinition
                {
                    ShortName = "d",
                    Unit = "",
                    Precision = 6,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
