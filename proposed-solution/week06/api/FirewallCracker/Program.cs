using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt.WithTitle("Matrix - Firewall Cracker");
    });
}

app.UseHttpsRedirection();

app.MapPost("/api/password-check", () => "OK coco")
    .WithDisplayName("Password check");

app.RunAsync();

public partial class Program;