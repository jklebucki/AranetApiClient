namespace AranetApiClient.Services;

/// <summary>
/// Interface defining the contract for password hashing functionality.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Hashes a password according to the specified logic.
    /// </summary>
    /// <param name="password">The user's password.</param>
    /// <param name="permasalt">The constant salt (permasalt).</param>
    /// <param name="salt">The random salt for the login session.</param>
    /// <returns>The hashed password ready to be sent to the backend.</returns>
    string HashPassword(string password, string permasalt, string salt);
}