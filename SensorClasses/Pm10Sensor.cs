using System.Collections.Generic;

namespace SensorDefinitions;

public class Pm10Sensor : SensorBase
{
    public Pm10Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "pm10", new MetricDefinition
                {
                    ShortName = "pm10",
                    Unit = "kg/m^3",
                    Precision = 5,
                    MidName = "pm10",
                    Icon = "aranet:pm10"
                }
            }
        };
    }
}
