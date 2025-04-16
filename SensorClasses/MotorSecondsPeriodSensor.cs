namespace SensorDefinitions;

public class MotorSecondsPeriodSensor : SensorBase
{
    public MotorSecondsPeriodSensor()
    {
        Metrics = new Dictionary<string, MetricDefinition>
        {
            {
                "motor_seconds_period", new MetricDefinition
                {
                    ShortName = "msp",
                    Unit = "s",
                    Precision = 0,
                    MidName = "",
                    Icon = "clock-time-four-outline"
                }
            }
        };
    }
}
