using System.Collections.Generic;

namespace SensorDefinitions;

public class Voltage1Sensor : SensorBase
{
    public Voltage1Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "voltage1", new MetricDefinition
                {
                    ShortName = "v1",
                    Unit = "V",
                    Precision = 2,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
