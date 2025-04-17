using AranetApiClient.Services;
using Microsoft.AspNetCore.Mvc;

public class AuthClientController : ControllerBase
{
    private readonly IAuthClient _authClient;

    public AuthClientController(IAuthClient authClient)
    {
        _authClient = authClient;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest == null || !loginRequest.IsValid())
        {
            return BadRequest("Invalid request.");
        }

        var authRequest = new AuthRequest
        {
            Auth = new Auth
            {
                Username = loginRequest.Username,
            }
        };
        if (authRequest == null || string.IsNullOrEmpty(authRequest.Auth.Username))
        {
            return BadRequest("Invalid request.");
        }

        var result = await _authClient.LoginAsync(authRequest.Auth.Username, loginRequest.Password); // Use the actual password

            if (result)
        {
            return Ok("Login successful.");
        }
        else
        {
            return Unauthorized("Login failed.");
        }
    }
}