using System.Collections.Generic;

namespace SensorDefinitions;

public class Pm25Sensor : SensorBase
{
    public Pm25Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "pm2_5", new MetricDefinition
                {
                    ShortName = "pm2_5",
                    Unit = "kg/m^3",
                    Precision = 5,
                    MidName = "pm2_5",
                    Icon = "aranet:pm2_5"
                }
            }
        };
    }
}
