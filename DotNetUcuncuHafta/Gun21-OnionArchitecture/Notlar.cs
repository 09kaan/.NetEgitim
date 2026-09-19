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

Yeni görev dağılımı Gün 19
ProductService
├── CategoryId kontrolü
├── DTO → Product mapping
└── Repository’yi çağırma

ProductRepository
├── Product’ı DbContext’e ekleme
├── SaveChangesAsync çalıştırma
└── Kaydedilen Product’ı döndürme

Add(product)    → Eklenecek olarak işaretler
Update(product) → Güncellenecek olarak işaretler
Remove(product) → Silinecek olarak işaretler

Teknik altyapıyı kimse bilmiyor değil. Infrastructure katmanı teknik altyapıyı bilir. 
Application yalnızca repository interface’ini bilir. 
API’deki Program.cs ise interface ile gerçek Infrastructure uygulamasını birbirine bağlar.
Yani “sadece repository biliyor” demek yerine:
EF Core ve veritabanı ayrıntılarını Infrastructure katmanı bilir; iç katmanlardan gizleriz.

En dış halka
┌─────────────────────────────┐
│ API                         │
│  ┌───────────────────────┐  │
│  │ Infrastructure        │  │
│  │  ┌─────────────────┐  │  │
│  │  │ Application     │  │  │
│  │  │  ┌───────────┐  │  │  │
│  │  │  │ Domain    │  │  │  │
│  │  │  └───────────┘  │  │  │
│  │  └─────────────────┘  │  │
│  └───────────────────────┘  │
└─────────────────────────────┘
Domain merkezdedir:
Domain hiçbir proje katmanını bilmez.
​
Application, Domain’i bilir:
Application → Domain
​
Infrastructure, iç katmanlardaki sözleşmeleri uygular:
Infrastructure → Application
Infrastructure → Domain
​
API parçaları birleştirir:
API → Application
API → Infrastructure

Domain
└── Entity’ler ve temel iş kuralları

Application
├── DTO’lar
├── Interface’ler
├── ProductService
└── CategoryService

Infrastructure
├── AppDbContext
├── ProductRepository
└── CategoryRepository

API
├── Controller’lar
├── DI kayıtları
└── HTTP işlemleri

İç katmanlar dış katmanların teknik ayrıntılarını bilmez; dış katmanlar iç katmanlardaki sözleşmeleri uygular.

Repository Pattern, veritabanı işlemlerini ayıran tek bir tasarım desenidir.
Onion Architecture ise bütün uygulamanın katmanlarını ve bağımlılık yönlerini düzenleyen mimaridir.
*/