using Employment.API.EndPoints;
using Employment.API.Entities;
using Parser.Common.MassTransit;
using Parser.Common.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AdMongo()
    .AddMongoRepository<JobPosition>("Employments")
    .AddMongoRepository<Client>("Clients")
    .AddMassTransitWithRabbitMQ();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapJobPositionEndPoint();
app.Run();

