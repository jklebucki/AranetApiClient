namespace SensorDefinitions;

public class Energy0Sensor : SensorBase
{
    public Energy0Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "energy0", new MetricDefinition
                {
                    ShortName = "e1",
                    Unit = "kWh/h",
                    Precision = 0,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
