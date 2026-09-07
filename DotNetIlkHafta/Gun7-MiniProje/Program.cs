bool devam = true;

List<Product> products = new();



while (devam)
{
    Console.WriteLine("\n--- Stok ve Sipariş Yönetimi ---");
    Console.WriteLine("1 - Ürün ekle");
    Console.WriteLine("2 - Ürünleri listele");
    Console.WriteLine("3 - Ürün ara");
    Console.WriteLine("4 - LINQ raporu");
    Console.WriteLine("5 - Sipariş hazırla");
    Console.WriteLine("0 - Çıkış");
    Console.Write("Seçiminiz: ");

    string secim = Console.ReadLine() ?? "";

    switch (secim)
    {
        case "1":
            Console.WriteLine("1 - Ürün ekle");
            AddProduct(products);
            break;

        case "2":
            Console.WriteLine("2 - Ürünleri listele");
            ListProducts(products);
            break;

        case "3":
            Console.WriteLine("3 - Ürün ara");
            FindProduct(products);

            break;

        case "4":
            Console.WriteLine("4 - LINQ raporu");
            ShowReport(products);
            break;

        case "5":
            Console.WriteLine("5 - Sipariş hazırla");
            await RunOrdersAsync(products);

            break;

        case "0":
            devam = false;
           Console.WriteLine("0 - Çıkış");
            break;

        default:
            Console.WriteLine("Geçersiz bir seçimö yaptını.");
            break;
    }
}
static void AddProduct(List<Product> products)
{
    Console.Write("Ürün adı: ");
    string name = Console.ReadLine() ?? "";

    Console.Write("Kategori: ");
    string category = Console.ReadLine() ?? "";
    // Ad veya kategori boşsa işlemi durdur.
if (string.IsNullOrWhiteSpace(name) ||
    string.IsNullOrWhiteSpace(category))
{
    Console.WriteLine("Ürün adı veya kategori boş olamaz.");
    return;
}
    Console.Write("Fiyat: ");

    // Girilen fiyatı decimal.TryParse ile kontrol et.
    bool priceOk = decimal.TryParse(Console.ReadLine(),out decimal price);

    Console.Write("Stok: ");

    // Girilen stoku int.TryParse ile kontrol et.
    bool stockOk = int.TryParse(Console.ReadLine(),out int stock);
    // Fiyat veya stok sayıya dönüştürülemediyse işlemi durdur.
if (priceOk == false || stockOk == false)
{
    Console.WriteLine("Fiyat ve stok geçerli sayı olmalıdır.");
    return;
}

    // Şimdilik sonuçları ekrana yazdır.
    Console.WriteLine($"Fiyat geçerli mi: {priceOk}");
    Console.WriteLine($"Stok geçerli mi: {stockOk}");
    try
{
    // name, category, price ve stock değerleriyle
    // yeni bir Product oluştur.
    Product newProduct = new Product(name, category, price, stock);

    products.Add(newProduct);

    Console.WriteLine("Ürün başarıyla eklendi.");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Ürün eklenemedi: {ex.Message}");
}
}

static void ListProducts(List<Product> products)
{
    // Liste boşsa kullanıcıya bilgi ver ve metodu bitir.
    if (products.Count <= 0)
    {
        Console.WriteLine("Henüz ürün eklenmedi.");
        return;
    }

    Console.WriteLine("\n--- Ürünler ---");

    foreach (Product urun in products)
    {
        // Ürünün adını, kategorisini, fiyatını ve stokunu yazdır.
        Console.WriteLine("Ürün adı " + urun.Name + " kategorisi " + urun.Category + " fiyatı " + urun.Price + " stok " +urun.Stock);
    }
}

static void FindProduct(List<Product> products)
{
    Console.Write("Aranacak ürün adı: ");
    string search = Console.ReadLine() ?? "";

    // Liste içinde adı search değerine eşit olan
    // ilk ürünü bul. Büyük-küçük harfi önemseme.
    Product? bulunanUrun = products.FirstOrDefault(
        urun => string.Equals(                                              //Byük küçük harf oldupu için equals kullanıyoruz
    urun.Name,                                                              //Yoksa urun.Name == search kullanabilirdik
    search,
    StringComparison.OrdinalIgnoreCase
        )
    );

    // Ürün bulunamadıysa mesaj yazdır ve metodu bitir.
    if (bulunanUrun == null)
    {
        Console.WriteLine("Ürün bulunamadı.");
        return;
    }

    // Bulunan ürünün bilgilerini yazdır.
    Console.WriteLine(
        $"Bulundu: {bulunanUrun.Name} — " +
        $"Fiyat: {bulunanUrun.Price} TL — " +
        $"Stok: {bulunanUrun.Stock}"
    );
}
static void ShowReport(List<Product> products)
{
    // Liste boşsa rapor oluşturmadan metodu bitir.
    if (products.Count <= 0)
    {
        Console.WriteLine("Rapor oluşturmak için ürün yok.");
        return;
    }

    // Stokta olan ürünleri seç ve
    // pahalıdan ucuza sırala.
    List<Product> stoktakiUrunler = products
        .Where(urun => urun.Stock > 0)
        .OrderByDescending(urun => urun.Price)
        .ToList();

    Console.WriteLine(
        "\n--- Stoktaki Ürünler: Pahalıdan Ucuza ---"
    );

    foreach (Product urun in stoktakiUrunler)
    {
        Console.WriteLine(
            $"{urun.Name} — " +
            $"{urun.Price} TL — " +
            $"Stok: {urun.Stock}"
        );
    }
    // Bütün ürünlerin ortalama fiyatını hesapla.
    decimal ortalamaFiyat = products.Average(
        urun => urun.Price
    );

    // En pahalı ürünü bul.
    Product enPahaliUrun = products
        .OrderByDescending(urun => urun.Price)
        .First();

    Console.WriteLine(
        $"\nOrtalama fiyat: {ortalamaFiyat} TL"
    );

    Console.WriteLine(
        $"En pahalı ürün: {enPahaliUrun.Name} — " +
        $"{enPahaliUrun.Price} TL"
    );

    // Ürünleri kategoriye göre grupla.
    var kategoriGruplari = products
        .GroupBy(urun => urun.Category);

    Console.WriteLine("\n--- Kategori Raporu ---");

    foreach (var grup in kategoriGruplari)
    {
        // Kategori adını ve ürün sayısını yazdır.
        Console.WriteLine(
            $"Kategori: {grup.Key} — " +
            $"Ürün sayısı: {grup.Count()}"
        );
    }
    
}
static async Task<string> PrepareOrderAsync(
    Product product,
    int quantity,
    int duration)
{
    Console.WriteLine(
        $"{product.Name} siparişi hazırlanmaya başladı."
    );

    // Product class’ındaki metodu kullanarak
    // stoktan quantity miktarını düş.
    product.StockDecrease(quantity);

    // duration kadar asenkron bekle.
    await Task.Delay(duration);

    // Ürün adını ve kalan stoku içeren mesaj döndür.
    string Message2 = "Ürün adı " + product.Name + " Stok " + product.Stock;
    return Message2;
}

static async Task RunOrdersAsync(
    List<Product> products)
{
    if (products.Count < 2)
    {
        Console.WriteLine(
            "Sipariş için en az iki ürün eklemelisiniz."
        );

        return;
    }

    Product firstProduct = products[0];
    Product secondProduct = products[1];

    try
    {
        Task<string> firstOrder =
            PrepareOrderAsync(
                firstProduct,
                1,
                3000
            );

        Task<string> secondOrder =
            PrepareOrderAsync(
                secondProduct,
                1,
                1000
            );

        string[] results = await Task.WhenAll(
            firstOrder,
            secondOrder
        );

        foreach (string result in results)
        {
            Console.WriteLine(result);
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(
            $"Geçersiz sipariş: {ex.Message}"
        );
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(
            $"Stok hatası: {ex.Message}"
        );
    }
}