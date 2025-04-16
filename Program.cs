using AranetApiClient.HttpClients;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<AuthClient>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        CookieContainer = new CookieContainer(),
        UseCookies = true
    });

var app = builder.Build();

