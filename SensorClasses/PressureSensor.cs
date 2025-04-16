namespace SensorDefinitions;

public class PressureSensor : SensorBase
{
    public PressureSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "pressure", new MetricDefinition
                {
                    ShortName = "p",
                    Unit = "Pa",
                    Precision = 0,
                    MidName = "pres",
                    Icon = "aranet:pressure-symbol"
                }
            }
        };
    }
}
