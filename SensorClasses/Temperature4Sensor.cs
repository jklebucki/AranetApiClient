using System.Collections.Generic;

namespace SensorDefinitions;

public class Temperature4Sensor : SensorBase
{
    public Temperature4Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "temperature4", new MetricDefinition
                {
                    ShortName = "t4",
                    Unit = "C",
                    Precision = 2,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
