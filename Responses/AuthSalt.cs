using System.Text.Json.Serialization;

namespace AranetApiClient.Responses;
public class AuthSalt
{
    [JsonPropertyName("permasalt")]
    public string Permasalt { get; set; } = string.Empty;

    [JsonPropertyName("salt")]
    public string Salt { get; set; } = string.Empty;
}