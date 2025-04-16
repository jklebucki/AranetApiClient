using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddAuthClient();
    })
    .Build();

var authClient = host.Services.GetRequiredService<AuthClient>();

if (await authClient.LoginAsync("citro_admin", "Tempora3udostemp"))
{
    Console.WriteLine("✅ Zalogowano pomyślnie!");

    var result = await authClient.GetSecureDataAsync();
    Console.WriteLine("🔒 Dane po zalogowaniu:");
    Console.WriteLine(result);
}
else
{
    Console.WriteLine("❌ Błąd logowania.");
}
