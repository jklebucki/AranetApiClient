using System.Collections.Generic;

namespace SensorDefinitions;

public class VoltageSensor : SensorBase
{
    public VoltageSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "voltage", new MetricDefinition
                {
                    ShortName = "v",
                    Unit = "V",
                    Precision = 3,
                    MidName = "volt",
                    Icon = "aranet:voltmeter-symbol"
                }
            }
        };
    }
}
