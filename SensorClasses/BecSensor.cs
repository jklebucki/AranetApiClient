namespace SensorDefinitions;

public class BecSensor : SensorBase
{
    public BecSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "bec", new MetricDefinition
                {
                    ShortName = "bec",
                    Unit = "S/m",
                    Precision = 3,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
