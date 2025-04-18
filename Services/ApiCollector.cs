using System.Text;
using System.Text.Json;
using AranetApiClient.Sensors;

public class ApiCollector : IApiCollector
{
    private readonly HttpClient _httpClient;
    public ApiCollector(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("AranetApiClient");
    }
    public async Task<IEnumerable<string>> GetSensorCsvDataAsync(SensorDataRequest sensorRequest)
    {

        var jsonRequest = JsonSerializer.Serialize(sensorRequest);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/lua/csvProvider", content);
        var csvContent = await response.Content.ReadAsStringAsync();
        var csvLines = csvContent.Split('\n');

        return csvLines;
    }

    public async Task<IEnumerable<SensorRawCollection>> GetSensorsAsync(string username)
    {
        var sensorsRequest = SensorsRequest.Default(username);
        var jsonRequest = JsonSerializer.Serialize(sensorsRequest);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/lua/api", content);
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        // Dodanie konwerterów do opcji serializacji
        options.Converters.Add(new MetricsConverter());
        options.Converters.Add(new ProductNumberConverter());
        options.PropertyNameCaseInsensitive = true;

        // Deserializacja typów czujników
        var document = JsonDocument.Parse(json);
        var sensorTypesElement = document.RootElement
            .GetProperty("sensors")
            .GetProperty("getMetricInfo")
            .GetProperty("sensorInfo");
        var sensorMap = new Dictionary<(int ptype, int vari), SensorDefinition>();
        foreach (var ptypeEntry in sensorTypesElement.EnumerateObject())
        {
            int ptype = int.Parse(ptypeEntry.Name);
            foreach (var variEntry in ptypeEntry.Value.EnumerateObject())
            {
                int vari = int.Parse(variEntry.Name);
                var sensorDef = JsonSerializer.Deserialize<SensorDefinition>(variEntry.Value.GetRawText(), options);
                sensorMap[(ptype, vari)] = sensorDef!;
            }
        }

        // Deserializacja aktualnych czujników
        var sensorsRawElement = document.RootElement
            .GetProperty("sensors_raw")
            .GetProperty("sensors");

        var currentSensors = JsonSerializer.Deserialize<SensorRawCollection>(sensorsRawElement.ToString(), options);


        return currentSensors != null ? new List<SensorRawCollection> { currentSensors } : Enumerable.Empty<SensorRawCollection>();
    }
}