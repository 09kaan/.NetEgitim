/*List<int> sayilar = new() { 3, 8, 11, 14, 20, 25 };
List<int> buyukSayilar = sayilar
    .Where(sayi => (sayi % 2 == 0))                                                             WHERE Arama
    .ToList();
Console.WriteLine(string.Join(", ", buyukSayilar));


List<int> sayilar = new() { 2, 3, 4 };

List<int> kareler = sayilar
    .Select(sayi => sayi * sayi)                                                                SELECT Değiştirme
    .ToList();

Console.WriteLine(string.Join(", ", kareler));


List<int> sayilar = new() { 2, 3, 4 };

List<string> etiketler = sayilar
    .Select(sayi => "Sayı: " + sayi)                                                            SELECT Değiştirme
    .ToList();

foreach (string etiket in etiketler)
{
    Console.WriteLine(etiket);
}

List<int> notlar = new() { 75, 60, 45, 30, 80 };

// FirstOrDefault kullanarak 50'den küçük ilk notu bul.                                         FirstOrDefault kriteri ilk karşılayan veya 0
int ilkBasarisizNot = notlar
    .FirstOrDefault(not => not < 50);

Console.WriteLine($"İlk başarısız not: {ilkBasarisizNot}");

List<int> notlar = new() { 75, 60, 45, 80 };

bool basarisizNotVarMi = notlar
    .Any(not => not < 50);                                                                      Any En az bir tane var mı

Console.WriteLine(basarisizNotVarMi);


List<int> notlar = new() { 75, 60, 45, 80 };

bool tumNotlarGecerliMi = notlar
    .All(not => not >= 0 && not <= 100);                                                        All Hepsi karşıluıyor mu

Console.WriteLine(tumNotlarGecerliMi);

List<decimal> fiyatlar = new() { 850, 450, 6200, 1200 };

// Küçükten büyüğe sırala.
List<decimal> artanFiyatlar = fiyatlar
    .OrderBy(fiyat => fiyat)                                                                    OrderBy Küçükten büyüğe
    .ToList();

// Büyükten küçüğe sırala.
List<decimal> azalanFiyatlar = fiyatlar                                                         OrderByDescending Büyükten Küçüğe
    .OrderByDescending(fiyat => fiyat)
    .ToList();

Console.WriteLine($"Artan: {string.Join(", ", artanFiyatlar)}");
Console.WriteLine($"Azalan: {string.Join(", ", azalanFiyatlar)}");

List<decimal> fiyatlar = new() { 850, 450, 6200, 1200 };

// Uygun LINQ metotlarını kullan.
int urunSayisi = fiyatlar.Count();
decimal toplamFiyat = fiyatlar.Sum();
decimal ortalamaFiyat = fiyatlar.Average();                                                     LINQ metotları
decimal enUcuzFiyat = fiyatlar.Min();
decimal enPahaliFiyat = fiyatlar.Max();

Console.WriteLine($"Ürün sayısı: {urunSayisi}");
Console.WriteLine($"Toplam fiyat: {toplamFiyat}");
Console.WriteLine($"Ortalama fiyat: {ortalamaFiyat}");
Console.WriteLine($"En ucuz: {enUcuzFiyat}");
Console.WriteLine($"En pahalı: {enPahaliFiyat}");

List<Product> products = new()
{
    new Product { Name = "Klavye", Price = 850, Stock = 5 },
    new Product { Name = "Mouse", Price = 450, Stock = 0 },                                     //Nesne Listelerinde LINQ
    new Product { Name = "Monitör", Price = 6200, Stock = 3 }
};

List<Product> sonuc = products
    .Where(urun => urun.Price >= 500)
    .OrderByDescending(urun => urun.Price)
    .ToList();

foreach (Product urun in sonuc)
{
    Console.WriteLine($"{urun.Name}: {urun.Price} TL");
}
*/

List<Product> products = new()
{
    new Product
    {
        Name = "Klavye",
        Category = "Çevre Birimi",
        Price = 850,
        Stock = 5
    },
    new Product
    {
        Name = "Mouse",
        Category = "Çevre Birimi",
        Price = 450,
        Stock = 0
    },
    new Product
    {
        Name = "Monitör",
        Category = "Ekran",
        Price = 6200,
        Stock = 3
    },
    new Product
    {
        Name = "Webcam",
        Category = "Kamera",
        Price = 1200,
        Stock = 2
    }
};

// 1. Fiyatı 500 TL veya üzerindeki ürünleri filtrele.
List<Product> filtrelenenUrunler = products
    .Where(urun => urun.Price >= 500)
    .ToList();

// 2. Filtrelenen ürünleri pahalıdan ucuza sırala.
List<Product> siralananUrunler = filtrelenenUrunler
    .OrderByDescending(urun => urun.Price)
    .ToList();

// 3. Stokta en az bir ürün var mı?
bool stoktaUrunVarMi = products
    .Any(urun => urun.Stock > 0);

// 4. Ortalama fiyatı hesapla.
decimal ortalamaFiyat = products
    .Average(urun => urun.Price);

// 5. Kategoriye göre grupla.
var kategoriGruplari = products
    .GroupBy(urun => urun.Category);

Console.WriteLine("500 TL ve üzerindeki ürünler:");

foreach (Product urun in siralananUrunler)
{
    // Ürün adını ve fiyatını yazdır.
    Console.WriteLine("Ürün adı " +urun.Name +" Fiyatı: " +urun.Price );
}

Console.WriteLine($"\nStokta ürün var mı: {stoktaUrunVarMi}");
Console.WriteLine($"Ortalama fiyat: {ortalamaFiyat} TL");

Console.WriteLine("\nKategoriler:");

foreach (var grup in kategoriGruplari)
{
    // Kategori adını ve ürün sayısını yazdır.
    Console.WriteLine("Kategori adı: " + grup.Key + " Ürün sayısı: " + grup.Count());                       //Key Groupbydan geliyor
}