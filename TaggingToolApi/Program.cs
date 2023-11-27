using Infrastructure;
using TaggingToolApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
config.AddEnvironmentVariables("TaggingToolApi_");

builder.Services.AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCampaignEndpoints();

app.UseHttpsRedirection();

app.Run();