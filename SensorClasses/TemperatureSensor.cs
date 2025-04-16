using System.Collections.Generic;

namespace SensorDefinitions;

public class TemperatureSensor : SensorBase
{
    public TemperatureSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "temperature", new MetricDefinition
                {
                    ShortName = "t",
                    Unit = "C",
                    Precision = 3,
                    MidName = "temp",
                    Icon = "thermometer"
                }
            }
        };
    }
}
