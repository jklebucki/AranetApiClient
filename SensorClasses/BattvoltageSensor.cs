using System.Collections.Generic;

namespace SensorDefinitions;

public class BattvoltageSensor : SensorBase
{
    public BattvoltageSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "battVoltage", new MetricDefinition
                {
                    ShortName = "battVoltage",
                    Unit = "V",
                    Precision = 2,
                    MidName = "batt",
                    Icon = ""
                }
            }
        };
    }
}
