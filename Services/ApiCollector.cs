using System.Text;
using System.Text.Json;

public class ApiCollector
{
    private readonly HttpClient _httpClient;
    public ApiCollector(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<string> GetSecureDataAsync()
    {
        var request = new
        {
            from = 1743976800,
            to = 1744667999,
            sensor = "6304716",
        };
        var jsonRequest = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://77.91.1.141:55200/lua/csvProvider", content);
        var csvContent = await response.Content.ReadAsStringAsync();
        var csvLines = csvContent.Split('\n');
        var measurements = new List<string>();
        foreach (var line in csvLines)
        {
            var columns = line.Split(',');
            var timestamp = columns[0];
            if (columns.Length < 2)
                continue; // Skip lines that don't have enough columns
            var value = columns[1];
            measurements.Add($"{timestamp}: {value}");

        }
        return $"Liczba pomiarów: {measurements.Count()}";
    }

}