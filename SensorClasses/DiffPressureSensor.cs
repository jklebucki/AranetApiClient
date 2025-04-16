using System.Collections.Generic;

namespace SensorDefinitions;

public class DiffPressureSensor : SensorBase
{
    public DiffPressureSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "diff_pressure", new MetricDefinition
                {
                    ShortName = "diffp",
                    Unit = "Pa",
                    Precision = 3,
                    MidName = "diffp",
                    Icon = "gauge"
                }
            }
        };
    }
}
