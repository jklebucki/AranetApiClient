using System.Collections.Generic;

namespace SensorDefinitions;

public class Voltage3Sensor : SensorBase
{
    public Voltage3Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "voltage3", new MetricDefinition
                {
                    ShortName = "v3",
                    Unit = "V",
                    Precision = 2,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
