using AranetApiClient.Services;
using System.Data.SQLite;
using Npgsql;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using AranetApiClient.Data.Postgres;
using AranetApiClient.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
var apiSettings = builder.Configuration.GetSection("ApiSettings");
var sqliteConnectionString = builder.Configuration.GetConnectionString("SQLite");
var postgresConnectionString = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(postgresConnectionString));

builder.Services.AddDbContext<SqliteDbContext>(options =>
    options.UseSqlite(sqliteConnectionString));

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
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IApiCollector, ApiCollector>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// Register PostgreSQL connection
builder.Services.AddScoped<NpgsqlConnection>(_ => new NpgsqlConnection(postgresConnectionString));
// Register SQLite connection
builder.Services.AddScoped<SQLiteConnection>(_ => new SQLiteConnection(sqliteConnectionString));

// Register repositories
//builder.Services.AddScoped<ISensorPostgresRepository, SensorPostgresRepository>();
//builder.Services.AddScoped<ISensorSqliteRepository, SensorSqliteRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.Run();
