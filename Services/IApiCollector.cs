using SensorDefinitions;

public interface IApiCollector
{
    Task<IEnumerable<string>> GetSensorCsvDataAsync(SensorRequest sensorRequest);
    Task<IEnumerable<SensorBase>> GetSensorsAsync();
}