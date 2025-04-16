using System.Collections.Generic;

namespace SensorDefinitions;

public class PecSensor : SensorBase
{
    public PecSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "pec", new MetricDefinition
                {
                    ShortName = "pec",
                    Unit = "S/m",
                    Precision = 3,
                    MidName = "",
                    Icon = "cup"
                }
            }
        };
    }
}
