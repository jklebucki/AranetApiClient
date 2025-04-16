namespace SensorDefinitions;

public class DerivedPpSensor : SensorBase
{
    public DerivedPpSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "derived_pp", new MetricDefinition
                {
                    ShortName = "d_pp",
                    Unit = "",
                    Precision = 6,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
