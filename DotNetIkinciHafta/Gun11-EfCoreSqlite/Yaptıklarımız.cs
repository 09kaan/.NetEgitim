/*Entity Framework Core ve SQLite

RAM’deki List<Product> verilerinin uygulama kapanınca kaybolduğunu gördük ve kalıcı depolama için SQLite kullandık. 
Entity Framework Core paketlerini kurup AppDbContext ve DbSet<Product> ile C# modeli ile veritabanı tablosu arasındaki bağlantıyı kurduk. 
Migration oluşturarak Products tablosunu ve products.db veritabanı dosyasını ürettik. 
ProductServicei _context.Products ve SaveChanges() kullanacak şekilde değiştirip
 uygulama yeniden başlatıldığında ürünlerin kaybolmadığını doğruladık.