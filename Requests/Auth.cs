using System.Text.Json.Serialization;

public class Auth
{
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
}