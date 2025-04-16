namespace SensorDefinitions;

public class PpfdSensor : SensorBase
{
    public PpfdSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "ppfd", new MetricDefinition
                {
                    ShortName = "ppfd",
                    Unit = "umol/(m^2 s)",
                    Precision = 1,
                    MidName = "",
                    Icon = "white-balance-sunny"
                }
            }
        };
    }
}
