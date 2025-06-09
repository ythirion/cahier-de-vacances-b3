using FirewallCracker.Commands;
using FirewallCracker.Core;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt => { opt.WithTitle("Matrix - Firewall Cracker"); });
}

app.UseHttpsRedirection();

app.MapPost("/api/password-check", (CheckPassword command) => PasswordChecker.Check(command.Password))
    .WithDisplayName("Password check");

app.Run();

public partial class Program;