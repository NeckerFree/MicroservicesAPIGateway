using Identity.Api.DbContext;
using Identity.Api.EndPoints;
using Identity.Api.Entities;
using Identity.Api.Interfaces;
using Identity.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//https://www.kafle.io/tutorials/asp-dot-net/Secure-Minimal-APIs-in-.NET-6
var builder = WebApplication.CreateBuilder(args);
// Add JWT configuration
//builder.Services.AddIdentity<IdentityUser, IdentityRole>();
builder.Services.AddSingleton<ITokenService>(new TokenService());
builder.Services.AddSingleton<IUserService>(new UserService());
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Not Found"))),
        //ValidateIssuer = true,
        //ValidateAudience = true,
        //ValidateLifetime = false,
        //ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IdentityMSContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("IdentityMSConnection");
    options.UseSqlServer(connectionString);
});

JWT jwt = new JWT()
{
    Issuer = builder.Configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("Issuer Not Found"),
    Audience = builder.Configuration["Jwt:Audience"] ?? throw new InvalidOperationException("Audience Not Found"),
    Key = builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("Key Not Found")
};
var app = builder.Build();

//app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapSecurityEndPoint(jwt);
//app.MapSecurityEndPoint();
app.UseHttpsRedirection();
app.Run();
