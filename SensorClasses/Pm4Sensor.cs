using System.Collections.Generic;

namespace SensorDefinitions;

public class Pm4Sensor : SensorBase
{
    public Pm4Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "pm4", new MetricDefinition
                {
                    ShortName = "pm4",
                    Unit = "kg/m^3",
                    Precision = 5,
                    MidName = "",
                    Icon = "aranet:pm4"
                }
            }
        };
    }
}
