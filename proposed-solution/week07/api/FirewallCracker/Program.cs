using FirewallCracker;
using FirewallCracker.Adapters;
using FirewallCracker.Core;
using FirewallCracker.PasswordCheck;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>();

builder.Services
    .AddOpenApi()
    .AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy
                .WithOrigins(allowedOrigins ?? [])
                //.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    })
    // Configure IOC
    .AddScoped<IPasswordChecker, PasswordChecker>()
    .AddScoped<ICheckPasswordUseCase, CheckPasswordUseCase>()
    .AddScoped<IPasswordRuleRepository, PasswordRuleRepository>()
    .AddSingleton<Database>();

builder.Services.Configure<DatabaseOptions>(
    builder.Configuration.GetSection("ConnectionStrings")
);

var app = builder.Build();

app.UseCors()
    .UseHttpsRedirection()
    // Avoid to leak your implementation details to your callers
    .UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt => { opt.WithTitle("Matrix - Firewall Cracker"); });
}

app.MapPost("/api/password-check",
        async (ICheckPasswordUseCase useCase, CheckPassword request) =>
        {
            var result = await useCase.HandleAsync(request.Password);
            return result.ToResponse();
        })
    .WithDisplayName("Check Password");


var db = app.Services.GetRequiredService<Database>();
await db.InitializeAsync();
await app.RunAsync();

public partial class Program;