using System.Text;
using api;
using api.Authorization;
using api.DatabaseContext;
using api.Helpers;
using api.Middlewares;
using api.Models.Dto;
using api.Models.Dto.Account;
using api.Models.Entities;
using api.Models.Validators;
using api.Services;
using api.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

//dotnet ef database update --connection "server=localhost;port=5433;userid=dbuser;password=password;database=mysql;"

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QuizDbContext>( options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

var  MyAllowSpecificOrigins = "frontend_connection";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins(new string[]{"http://localhost:3000", "https://programowanie-projekt-2023.vercel.app"}).AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
builder.Services.AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var authenicationSettings = new AuthenticationSettings();

builder.Configuration.GetSection("Authentication").Bind(authenicationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = "Bearer";
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = authenicationSettings.JwtIssuer,
        ValidAudience = authenicationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenicationSettings.JwtKey))
    };
});

builder.Services.AddSingleton(authenicationSettings);
builder.Services.Inject();

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
