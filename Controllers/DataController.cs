using Microsoft.AspNetCore.Mvc;

public class DataController : ControllerBase
{
    private readonly IApiCollector _apiCollector;

    public DataController(IApiCollector apiCollector)
    {
        _apiCollector = apiCollector;
    }

    [HttpGet("sensors")]
    public async Task<IActionResult> GetSensors(string username)
    {
        var sensors = await _apiCollector.GetSensorsAsync(username);
        return Ok(sensors);
    }


    [HttpGet("sensor-data")]
    public async Task<IActionResult> GetSensorData([FromQuery] SensorDataRequest sensorRequest)
    {
        var data = await _apiCollector.GetSensorCsvDataAsync(sensorRequest);
        return Ok(data);
    }
}