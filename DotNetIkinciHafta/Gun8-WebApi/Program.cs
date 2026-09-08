/*# Gün 8 — Web API ve HTTP Notları

## Web API

Farklı uygulamaların HTTP üzerinden veri ve işlem paylaşmasını sağlar.

Örneğin bir mobil uygulama, ürün listesini Web API'den isteyebilir.

## Client — İstemci

API'ye istek gönderen taraftır.

Örnekler:

- Tarayıcı
- Mobil uygulama
- React veya Angular uygulaması
- Postman
- Başka bir servis

## Server — Sunucu

İstemciden gelen isteği karşılar, gerekli işlemi yapar ve cevap döndürür.

ASP.NET Core Web API uygulamamız sunucu olarak çalışır.

## HTTP

İstemci ile sunucunun nasıl iletişim kuracağını belirleyen kurallar bütünüdür.

Temel akış:

İstemci → HTTP Request → API  
İstemci ← HTTP Response ← API

## Request — İstek

İstemcinin API'ye gönderdiği mesajdır.

Bir request şunları içerebilir:

- HTTP metodu
- Adres/path
- Header
- Body

## Response — Cevap

API'nin istemciye gönderdiği sonuçtur.

Bir response şunları içerebilir:

- Durum kodu
- Header
- Response body

## Endpoint

HTTP metodu ile adresin birleşimidir.

Örnek:

GET /api/products

GET /api/products ile POST /api/products farklı endpoint'lerdir.

## HTTP Metotları

GET: Veri getirir.

POST: Yeni veri oluşturur.

PUT: Var olan kaynağın tamamını günceller.

PATCH: Kaynağın yalnızca belirli alanlarını günceller.

DELETE: Kaynağı siler.

## HTTP Durum Kodları

200 OK: İstek başarıyla işlendi.

201 Created: Yeni kaynak oluşturuldu.

400 Bad Request: İstemci geçersiz veri gönderdi.

404 Not Found: İstenen endpoint veya kaynak bulunamadı.

500 Internal Server Error: Sunucuda beklenmeyen hata oluştu.

## JSON

Uygulamalar arasında veri taşımak için kullanılan metin biçimidir.

Örnek:

{
  "id": 1,
  "name": "Klavye",
  "price": 850,
  "inStock": true
}

## Serialization

C# nesnesinin JSON'a dönüştürülmesidir.

C# nesnesi → JSON

ASP.NET Core, endpoint'ten döndürdüğümüz nesneleri çoğunlukla otomatik olarak JSON'a çevirir.

## localhost

Çalıştığımız bilgisayarı ifade eder.

Örnek:

http://localhost:5189

## Port

Aynı bilgisayarda çalışan farklı uygulamaları ayıran kapı numarasıdır.

Örnek:

5189

## MapGet

Belirtilen adrese gelen GET isteğini karşılayan endpoint oluşturur.

Örnek:

app.MapGet("/", () => "API çalışıyor");

## app.Run

Web sunucusunu başlatır ve gelen istekleri dinler.

Endpoint tanımları app.Run satırından önce yazılmalıdır.
*/

var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/api/products", () =>
{
    return new[]
    {
        new
        {
            Id = 1,
            Name = "Klavye",
            Price = 850,
            InStock = true
        },
        new
        {
            Id = 2,
            Name = "Mouse",
            Price = 450,
            InStock = false
        }
    };
});

app.Run();