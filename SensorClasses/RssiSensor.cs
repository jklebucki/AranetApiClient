using System.Collections.Generic;

namespace SensorDefinitions;

public class RssiSensor : SensorBase
{
    public RssiSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "rssi", new MetricDefinition
                {
                    ShortName = "rssi",
                    Unit = "dBm",
                    Precision = 0,
                    MidName = "rssi",
                    Icon = ""
                }
            }
        };
    }
}
