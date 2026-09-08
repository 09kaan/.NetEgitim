
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "API çalışıyor");

app.MapGet("/api/info", () =>
{
    return new
    {
        Application = "DotNet Eğitimi API",
        Day = 8,
        IsActive = true
    };
});

app.MapGet("/api/categories", () =>
{
    return new[]
    {
        "Çevre Birimi",
        "Ekran",
        "Kamera"
    };
});



app.MapControllers();
app.Run();