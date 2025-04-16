using System.Collections.Generic;

namespace SensorDefinitions;

public class Pm1Sensor : SensorBase
{
    public Pm1Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "pm1", new MetricDefinition
                {
                    ShortName = "pm1",
                    Unit = "kg/m^3",
                    Precision = 5,
                    MidName = "pm1",
                    Icon = "aranet:pm1"
                }
            }
        };
    }
}
