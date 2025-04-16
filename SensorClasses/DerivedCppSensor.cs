using System.Collections.Generic;

namespace SensorDefinitions;

public class DerivedCppSensor : SensorBase
{
    public DerivedCppSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "derived_cpp", new MetricDefinition
                {
                    ShortName = "d_cpp",
                    Unit = "",
                    Precision = 6,
                    MidName = "",
                    Icon = ""
                }
            }
        };
    }
}
