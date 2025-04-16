using System.Collections.Generic;

namespace SensorDefinitions;

public class PulsesCumulativeSensor : SensorBase
{
    public PulsesCumulativeSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "pulses_cumulative", new MetricDefinition
                {
                    ShortName = "pc",
                    Unit = "pulses",
                    Precision = 0,
                    MidName = "",
                    Icon = "aranet:dc-voltage-pulse"
                }
            }
        };
    }
}
