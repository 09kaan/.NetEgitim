/* Task değer döndürmez
Task<T> değer döndürür. Return zorunlu Task<int> gibi 
async: Metotta await kullanılabileceğini belirtir.
Task: Sonuç döndürmeyen asenkron işi temsil eder.
Task<T>: Tamamlandığında T tipinde sonuç veren işi temsil eder.
await: Görev tamamlanınca metodun devam etmesini sağlar.
Task.Delay: Eğitimde beklemeli bir işlemi taklit eder.
Task.WhenAll: Bağımsız görevleri birlikte bekler.
Asenkron hatalar try/catch ile yönetilebilir.
async tek başına yeni thread oluşturmaz.

async/await, özellikle API, veritabanı ve dosya işlemleri gibi beklemeli operasyonlarda thread’i bloke etmeden çalışmayı sağlar. 
Bağımsız görevler önce başlatılıp Task.WhenAll ile birlikte beklenebilir.



static async Task DosyaIndirAsync(string dosyaAdi, int sure)
{
    Console.WriteLine($"{dosyaAdi} indirilmeye başladı.");

    // Verilen süre kadar asenkron bekle.
    await Task.Delay(sure);

    Console.WriteLine($"{dosyaAdi} indirildi.");
}

// Üç görevi önce başlat.
// Süreler: 3000, 1000 ve 2000 milisaniye
Task dosya1 = DosyaIndirAsync("Dosya 1", 3000);
Task dosya2 = DosyaIndirAsync("Dosya 2", 1000);
Task dosya3 = DosyaIndirAsync("Dosya 3", 2000);

// Üç görevin de tamamlanmasını birlikte bekle.
await Task.WhenAll(dosya1, dosya2, dosya3);

Console.WriteLine("Bütün dosyalar indirildi.");

static async Task DosyaIndirAsync(string dosyaAdi)
{
    Console.WriteLine($"{dosyaAdi} indirilmeye başladı.");

    await Task.Delay(1000);

    // Bir hata oluştur.
    throw new Exception("Dosya indirilemedi.");
}

try
{
    // Metodu await ederek çağır.
    await DosyaIndirAsync("Rapor.pdf");
}
catch (Exception ex)
{
    // Hata mesajını ekrana yazdır.
    Console.WriteLine(ex.Message);
}
*/

static async Task<string> SiparisHazirlaAsync(
    int siparisNo,
    int hazirlanmaSuresi)
{
    Console.WriteLine($"Sipariş {siparisNo} hazırlanmaya başladı.");

    // Verilen süre kadar asenkron bekle.
    await Task.Delay(hazirlanmaSuresi);

    // Sipariş numarasını içeren bir tamamlanma mesajı döndür.
    string mesaj = + siparisNo + " Nolu siparişiniz hazırlandı.";
    return mesaj;
}
try
{
    // Siparişleri henüz await etmeden başlat.
    Task<string> siparis1 = SiparisHazirlaAsync(1, 3000);
    Task<string> siparis2 = SiparisHazirlaAsync(2, 3000);
    Task<string> siparis3 = SiparisHazirlaAsync(3, 3000);

    // Bütün siparişleri birlikte bekle.
    string[] sonuclar = await Task.WhenAll(siparis1,siparis2,siparis3);

    foreach (string sonuc in sonuclar)
    {
        Console.WriteLine(sonuc);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}