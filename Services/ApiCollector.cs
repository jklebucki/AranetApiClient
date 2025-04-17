using System.Net.Http;
using System.Text;
using System.Text.Json;
using SensorDefinitions;

public class ApiCollector: IApiCollector
{
    private readonly HttpClient _httpClient;
    public ApiCollector(IHttpClientFactory  httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("AranetApiClient");
    }
    public async Task<IEnumerable<string>> GetSensorCsvDataAsync(SensorRequest sensorRequest)
    {

        var jsonRequest = JsonSerializer.Serialize(sensorRequest);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://77.91.1.141:55200/lua/csvProvider", content);
        var csvContent = await response.Content.ReadAsStringAsync();
        var csvLines = csvContent.Split('\n');

        return csvLines;
    }

    public async Task<IEnumerable<SensorBase>> GetSensorsAsync()
    {
        return await Task.FromResult(new List<SensorBase>());
    }
}