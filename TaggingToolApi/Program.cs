using Application.Settings;
using Infrastructure;
using TaggingToolApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
config.AddEnvironmentVariables("TaggingToolApi_");

builder.Services.AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(config.GetSection(DatabaseSettings.KeyName));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCampaignEndpoints();
app.MapChannelEndpoints();
app.MapTagEndpoints();

app.UseHttpsRedirection();

app.Run();