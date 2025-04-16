using System.Collections.Generic;

namespace SensorDefinitions;

public class Co2Sensor : SensorBase
{
    public Co2Sensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "co2", new MetricDefinition
                {
                    ShortName = "co2",
                    Unit = "ppm",
                    Precision = 0,
                    MidName = "co2",
                    Icon = "molecule-co2"
                }
            }
        };
    }
}
