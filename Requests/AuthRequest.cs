using System.Text.Json.Serialization;

public class AuthRequest
{
    [JsonPropertyName("auth")]
    public Auth Auth { get; set; } = new Auth();
}