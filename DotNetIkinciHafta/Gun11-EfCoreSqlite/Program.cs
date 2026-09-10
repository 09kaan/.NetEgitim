/*
Controller → İlgili HTTP işlemlerini toplar.
Routing    → İsteği doğru action metoduna yönlendirir.
Action     → HTTP isteğini karşılayan public metottur.
IActionResult → Ok, NotFound gibi farklı cevapları döndürür.
Client     → İsteği gönderir
HTTP       → İletişim kurallarıdır
Controller → İsteği karşılar
Service    → Asıl işlemi yapar
DTO        → Gelen verinin şeklini belirler
API        → JSON cevabı döndürür
Dependency:
Controller'ın ihtiyaç duyduğu IProductService nesnesidir.

Dependency Injection:
Bu nesnenin controller tarafından new ile oluşturulmayıp dışarıdan verilmesidir.

Constructor Injection:
Nesnenin controller'ın constructor parametresi üzerinden verilmesidir.

Singleton → Uygulama boyunca aynı nesne
Scoped    → Her HTTP isteğinde yeni nesne

Migration tabloya çeviriyor gibi benim anladığım 
Products
├── Id
├── Name
└── Price
*/
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IProductService, ProductService>();    //Singletonı değiştik
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string? connectionString =
        builder.Configuration.GetConnectionString(
            "DefaultConnection"
        );

    options.UseSqlite(connectionString);
});
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