namespace SensorDefinitions;

public class DerivedPcSensor : SensorBase
{
    public DerivedPcSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "derived_pc", new MetricDefinition
                {
                    ShortName = "d_pc",
                    Unit = "",
                    Precision = 6,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
