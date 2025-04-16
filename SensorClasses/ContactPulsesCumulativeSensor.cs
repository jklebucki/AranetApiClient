namespace SensorDefinitions;

public class ContactPulsesCumulativeSensor : SensorBase
{
    public ContactPulsesCumulativeSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "contact_pulses_cumulative", new MetricDefinition
                {
                    ShortName = "cpc",
                    Unit = "pulses",
                    Precision = 0,
                    MidName = "",
                    Icon = "electric-switch"
                }
            }
        };
    }
}
