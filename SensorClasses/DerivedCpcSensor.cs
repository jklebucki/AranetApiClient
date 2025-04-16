namespace SensorDefinitions;

public class DerivedCpcSensor : SensorBase
{
    public DerivedCpcSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "derived_cpc", new MetricDefinition
                {
                    ShortName = "d_cpc",
                    Unit = "",
                    Precision = 6,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
