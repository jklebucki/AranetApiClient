namespace SensorDefinitions;

public class PulsesPeriodSensor : SensorBase
{
    public PulsesPeriodSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "pulses_period", new MetricDefinition
                {
                    ShortName = "pp",
                    Unit = "pulses",
                    Precision = 0,
                    MidName = "",
                    Icon = "aranet:dc-voltage-pulse"
                }
            }
        };
    }
}
