using AranetApiClient.Services;
using System.Data;
using System.Data.SQLite;
using Npgsql;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
var apiSettings = builder.Configuration.GetSection("ApiSettings");
var sqliteConnectionString = builder.Configuration.GetConnectionString("SQLite");
var postgresConnectionString = builder.Configuration.GetConnectionString("Postgres");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sharedCookieContainer = new CookieContainer();

builder.Services.AddHttpClient("AranetApiClient")
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri(apiSettings["BaseAddress"] ?? string.Empty);
    })
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        CookieContainer = sharedCookieContainer,
        UseCookies = true
    });

builder.Services.AddScoped<IAuthClient, AuthClient>();
builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddScoped<IApiCollector, ApiCollector>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add controllers
builder.Services.AddControllers();

// Register Dapper connections
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var usePostgres = builder.Configuration.GetValue<bool>("UsePostgres");
    if (usePostgres)
    {
        return new NpgsqlConnection(postgresConnectionString);
    }
    return new SQLiteConnection(sqliteConnectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors();

// Map controllers
app.MapControllers();

app.Run();