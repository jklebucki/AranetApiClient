using System.Security.Cryptography;
using System.Text;

public static class PasswordHasher
{
    /// <summary>
    /// Hashuje hasło zgodnie z logiką z frontendu (5x SHA256 → +permasalt → SHA256 → +salt → SHA256).
    /// </summary>
    /// <param name="password">Hasło użytkownika</param>
    /// <param name="permasalt">Stała sól (permasalt)</param>
    /// <param name="salt">Losowa sól dla sesji logowania</param>
    /// <returns>Zahashowane hasło gotowe do wysłania do backendu</returns>
    public static string HashPassword(string password, string permasalt, string salt)
    {
        // 1. Pięciokrotne SHA256 hasła
        string hashed = password;
        for (int i = 0; i < 5; i++)
        {
            hashed = Sha256Hash(hashed);
        }

        // 2. Dodanie permasalt
        string permaSalted = Sha256Hash(hashed + permasalt);

        // 3. Dodanie salt
        string fullySalted = Sha256Hash(salt + permaSalted);

        return fullySalted;
    }

    private static string Sha256Hash(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha256.ComputeHash(bytes);
            return ByteArrayToHexString(hash);
        }
    }

    private static string ByteArrayToHexString(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (var b in bytes)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
}
