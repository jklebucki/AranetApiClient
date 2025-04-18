using AranetApiClient.Sensors;

public interface IApiCollector
{
    Task<IEnumerable<string>> GetSensorCsvDataAsync(SensorDataRequest sensorRequest);
    Task<IEnumerable<SensorRawCollection>> GetSensorsAsync(string username);
}