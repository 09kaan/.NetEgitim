/*
Controller → İlgili HTTP işlemlerini toplar.
Routing    → İsteği doğru action metoduna yönlendirir.
Action     → HTTP isteğini karşılayan public metottur.
IActionResult → Ok, NotFound gibi farklı cevapları döndürür.
*/
/*
Client     → İsteği gönderir
HTTP       → İletişim kurallarıdır
Controller → İsteği karşılar
Service    → Asıl işlemi yapar
DTO        → Gelen verinin şeklini belirler
API        → JSON cevabı döndürür
*/

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductService>();

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