using Identity.Api.DbContext;
using Identity.Api.EndPoints;
using Identity.Api.Entities;
using Identity.Api.Interfaces;
using Identity.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityMSContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("IdentityMSConnection");
    options.UseSqlServer(connectionString);
});

// For Identity  
builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityMSContext>()
                .AddDefaultTokenProviders();
// Adding Authentication  
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
            {
                //options.SaveToken = true;
                //options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudience = builder.Configuration["Jwt:Audience"] ?? throw new InvalidOperationException("Audience Not Found"),
                    ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("Issuer Not Found"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"] ?? throw new InvalidOperationException("Secret Not Found"))),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                };
            });
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapSecurityEndPoint();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.Run();
