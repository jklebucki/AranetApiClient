using System.Collections.Generic;

namespace SensorDefinitions;

public class WeightRawSensor : SensorBase
{
    public WeightRawSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "weight_raw", new MetricDefinition
                {
                    ShortName = "w_raw",
                    Unit = "kg",
                    Precision = 3,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
