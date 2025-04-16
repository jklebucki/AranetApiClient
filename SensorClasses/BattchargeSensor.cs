using System.Collections.Generic;

namespace SensorDefinitions;

public class BattchargeSensor : SensorBase
{
    public BattchargeSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "battCharge", new MetricDefinition
                {
                    ShortName = "batt",
                    Unit = "/",
                    Precision = 2,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
