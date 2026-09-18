/*
Katmanların çok kısa anlamı
Domain                                              //Temel iş nesnelerini barındırır.
Uygulamadaki temel şeyler:

Product
Category
​
Domain şunu söyler:
Uygulamamızda hangi varlıklar var?

Application                                         //İşlemleri ve sözleşmeleri tanımlar.
Uygulamanın yapabileceği işlemleri tanımlar:

DTO’lar
IProductService
ICategoryService
​
Application şunu söyler:
Uygulama hangi işlemleri yapabilmeli?
Ancak SQLite’a nasıl bağlanacağını bilmez.

Infrastructure                                      //Veritabanı işlemlerini gerçekten uygular.
Veritabanıyla ilgili gerçek uygulamaları taşır:

AppDbContext
ProductService
CategoryService
EF Core
SQLite
Migrations
​
Infrastructure şunu söyler:
Application’ın istediği işlemleri SQLite kullanarak nasıl yaparım?

API                                                 //Yönlendirme, HTTP isteğini alır, cevap döndürür.
Dışarıdan gelen HTTP isteklerini karşılar:

Controllers
Program.cs
appsettings.json
​
API şunu söyler:
HTTP isteğini hangi service’e göndereceğim ve hangi HTTP cevabını döndüreceğim?

DTO        → Veriyi taşır
Controller → HTTP isteğini yönetir
Service    → İşlemi yapar
Entity     → Gerçek iş/veritabanı nesnesidir
DbContext  → Veritabanıyla konuşur

MSSQL 
String için başta N yazıyoruz. Unicode olduğunu belirtiyormuş.

Gün 18 
Repository Pattern, veri erişim işlemlerini service katmanından ayırır. 
Service hangi veriye ihtiyacı olduğunu repository interface’i üzerinden söyler; 
repository ise EF Core ve AppDbContext kullanarak bu verinin veritabanından nasıl okunacağını veya yazılacağını gerçekleştirir.
*/