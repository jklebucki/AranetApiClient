using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AranetApiClient.HttpClients;
public class AuthClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "http://77.91.1.141:55200/lua/api";

    public AuthClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var saltRequest = new
        {
            auth = new { username }
        };
        var jsonRequest = JsonSerializer.Serialize(saltRequest);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var saltResponse = await _httpClient.PostAsync(_baseUrl, content);

        if (!saltResponse.IsSuccessStatusCode)
        {
            Console.WriteLine("Błąd pobierania salt.");
            return false;
        }

        var saltJson = await saltResponse.Content.ReadFromJsonAsync<AuthSaltResponse>();

        if (saltJson?.Auth == null)
            return false;

        string hash = PasswordHasher.HashPassword(password, saltJson.Auth.Permasalt, saltJson.Auth.Salt);

        var loginRequest = new
        {
            auth = new
            {
                username,
                hash,
                remember = true
            }
        };

        var loginRequestJson = JsonSerializer.Serialize(loginRequest);
        var loginContent = new StringContent(loginRequestJson, Encoding.UTF8, "application/json");
        var loginResponse = await _httpClient.PostAsync(_baseUrl, loginContent);
        var loginMessage = await loginResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Login response: {loginMessage}");

        return loginResponse.IsSuccessStatusCode;
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

    string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

public class AuthSaltResponse
{
    [JsonPropertyName("auth")]
    public AuthSalt? Auth { get; set; }
}

public class AuthSalt
{
    [JsonPropertyName("permasalt")]
    public string Permasalt { get; set; } = string.Empty;

    [JsonPropertyName("salt")]
    public string Salt { get; set; } = string.Empty;
}
