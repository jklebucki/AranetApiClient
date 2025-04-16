using System.Collections.Generic;

namespace SensorDefinitions;

public class MotorSecondsCumulativeSensor : SensorBase
{
    public MotorSecondsCumulativeSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "motor_seconds_cumulative", new MetricDefinition
                {
                    ShortName = "msc",
                    Unit = "s",
                    Precision = 0,
                    MidName = "",
                    Icon = "clock-time-four-outline"
                }
            }
        };
    }
}
