using System.Collections.Generic;

namespace SensorDefinitions;

public class ContactPulsesPeriodSensor : SensorBase
{
    public ContactPulsesPeriodSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "contact_pulses_period", new MetricDefinition
                {
                    ShortName = "cpp",
                    Unit = "pulses",
                    Precision = 0,
                    MidName = "",
                    Icon = "electric-switch"
                }
            }
        };
    }
}
