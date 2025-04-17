using AranetApiClient.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<HttpClient>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        CookieContainer = new CookieContainer(),
        UseCookies = true
    });


builder.Services.AddScoped<IAuthClient, AuthClient>();
builder.Services.AddScoped<PasswordHasher>();
//builder.Services.AddScoped<IApiCollector, ApiCollector>();

var app = builder.Build();

