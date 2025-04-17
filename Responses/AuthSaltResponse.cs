using System.Text.Json.Serialization;

namespace AranetApiClient.Responses;

public class AuthSaltResponse
{
    [JsonPropertyName("auth")]
    public AuthSalt? Auth { get; set; }
}
