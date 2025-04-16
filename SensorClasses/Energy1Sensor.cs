using System.Collections.Generic;

namespace SensorDefinitions;

public class Energy1Sensor : SensorBase
{
    public Energy1Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "energy1", new MetricDefinition
                {
                    ShortName = "e2",
                    Unit = "kWh/h",
                    Precision = 0,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
