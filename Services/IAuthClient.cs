namespace AranetApiClient.Services;

/// <summary>
/// Interface defining the contract for authentication client functionality.
/// </summary>
public interface IAuthClient
{
    /// <summary>
    /// Logs in a user asynchronously.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>A task representing the asynchronous operation, with a boolean indicating success or failure.</returns>
    Task<bool> LoginAsync(string username, string password);
}