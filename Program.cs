using AranetApiClient.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
var apiSettings = builder.Configuration.GetSection("ApiSettings");

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