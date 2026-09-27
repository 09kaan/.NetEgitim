using Gun16.Application;
using Gun16.Infrastructure;
using Gun16.Api.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);

// API servisleri
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

// Application katmanındaki service kayıtları
builder.Services.AddApplicationServices();

// Infrastructure katmanındaki DbContext ve repository kayıtları
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddExceptionHandler<ValidationExceptionHandler>();

var app = builder.Build();

// Uygulamadaki yakalanmamış hataları ProblemDetails formatında döndürür.
app.UseExceptionHandler();

// OpenAPI endpoint'ini yalnızca Development ortamında açar.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();