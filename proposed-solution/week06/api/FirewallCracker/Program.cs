using FirewallCracker.Commands;
using FirewallCracker.Core;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//var allowedOrigins = builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>();

builder.Services
    .AddOpenApi()
    .AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy
                //.WithOrigins(allowedOrigins ?? [])
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

var app = builder.Build();
app.UseCors();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt => { opt.WithTitle("Matrix - Firewall Cracker"); });
}

app.MapPost("/api/password-check", (CheckPassword command) => PasswordChecker.Check(command.Password))
    .WithDisplayName("Password check");

app.Run();

public partial class Program;