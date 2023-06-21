using Consumer.API.Endpoints;
using Consumer.API.Entities;
using Parser.Common.MassTransit;
using Parser.Common.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AdMongo()
    .AddMongoRepository<Client>("Clients")
    .AddMassTransitWithRabbitMQ();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapClientEndpoint();
app.Run();

