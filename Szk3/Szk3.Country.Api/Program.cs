using Szk3.Country.Application.Country;
using Szk3.Country.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddCountryApplication();
services.AddCountryInfrastructure();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();


await app.RunAsync();