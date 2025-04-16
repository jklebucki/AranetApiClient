namespace SensorDefinitions;

public class Energy2Sensor : SensorBase
{
    public Energy2Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "energy2", new MetricDefinition
                {
                    ShortName = "e3",
                    Unit = "kWh/h",
                    Precision = 0,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
