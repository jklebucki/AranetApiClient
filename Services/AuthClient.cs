using System.Text;
using System.Text.Json;
using AranetApiClient.Responses;

namespace AranetApiClient.Services;

public class AuthClient : IAuthClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "/lua/api";
    private readonly IPasswordHasher _passwordHasher;

    public AuthClient(IHttpClientFactory httpClientFactory, IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
        _httpClient = httpClientFactory.CreateClient("AranetApiClient");
    }

    public async Task<bool> LoginAsync(string username, string password)
    {

        var saltRequest = new AuthRequest
        {
            Auth = new Auth
            {
                Username = username
            }
        };

        var jsonRequest = JsonSerializer.Serialize(saltRequest);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        try
        {
            var saltResponse = await _httpClient.PostAsync(_baseUrl, content);
            if (!saltResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Błąd pobierania salt.");
                return false;
            }

            var saltJson = await saltResponse.Content.ReadFromJsonAsync<AuthSaltResponse>();

            if (saltJson?.Auth == null)
                return false;

            string hash = _passwordHasher.HashPassword(password, saltJson.Auth.Permasalt, saltJson.Auth.Salt);

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
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Błąd podczas wysyłania żądania: {ex.Message}");
            return false;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Błąd podczas deserializacji odpowiedzi: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd nieznany: {ex.Message}");
            return false;
        }
    }
}


