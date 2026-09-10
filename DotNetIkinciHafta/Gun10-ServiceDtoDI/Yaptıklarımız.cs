/* Service, DTO ve Dependency Injection

Ürün listesini ve veri işlemlerini controller’dan çıkarıp ProductService class’ına taşıdık. 
IProductService interface’iyle service’in sunması gereken GetAll, GetById ve Create işlemlerini tanımladık. 
CreateProductDto ile client’ın yeni ürün oluştururken yalnızca Name ve Price göndermesini sağladık. 
Dependency Injection ve constructor injection kullanarak ProductService nesnesinin ASP.NET Core tarafından controller’a verilmesini sağladık
; POST işleminde 201 Created, geçersiz veride 400 Bad Request döndürdük.
