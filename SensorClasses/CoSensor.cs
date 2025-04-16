using System.Collections.Generic;

namespace SensorDefinitions;

public class CoSensor : SensorBase
{
    public CoSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "co", new MetricDefinition
                {
                    ShortName = "co",
                    Unit = "ppm",
                    Precision = 0,
                    MidName = "co",
                    Icon = "molecule-co"
                }
            }
        };
    }
}
