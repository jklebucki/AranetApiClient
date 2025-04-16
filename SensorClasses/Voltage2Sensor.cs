namespace SensorDefinitions;

public class Voltage2Sensor : SensorBase
{
    public Voltage2Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "voltage2", new MetricDefinition
                {
                    ShortName = "v2",
                    Unit = "V",
                    Precision = 2,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
