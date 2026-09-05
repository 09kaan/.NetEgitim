/*
int.Parse:
Metni sayıya çevirir.
Başarılıysa int değer döndürür.
Başarısızsa exception oluşturur.

int sayi = int.Parse(metin);

int.TryParse:
Metni sayıya çevirmeyi dener.
Başarılıysa true, başarısızsa false döndürür.
Sonucu out değişkenine koyar.

bool basarili = int.TryParse(metin, out int sayi);

try:
Hata çıkarma ihtimali olan kod.

catch:
Oluşan hatayı yakalayıp yönetir.

finally:
Hata olsa da olmasa da çalışır.

throw:
Kendi belirlediğim hata mesajını atar.
*/

List<decimal> fiyatlar = new List<decimal>();

try
{
    Console.Write("Eklenecek fiyatı giriniz: ");

    decimal fiyat =
        decimal.Parse(Console.ReadLine());

    FiyatEkle(fiyatlar, fiyat);

    Console.WriteLine(
        $"{fiyat} TL listeye eklendi."
    );
}
catch (FormatException)
{
    Console.WriteLine(
        "Geçerli bir sayı girmelisiniz."
    );
}
catch (ArgumentException hata)
{
    Console.WriteLine(
        $"Hata: {hata.Message}"
    );
}
finally
{
    Console.WriteLine("Fiyat ekleme işlemi sona erdi.");
}

Console.WriteLine("Fiyatlar:");

foreach (decimal fiyat in fiyatlar)
{
    Console.WriteLine($"{fiyat} TL");
}

static void FiyatEkle(
    List<decimal> fiyatlar,
    decimal fiyat)
{
    if (fiyat <= 0)
    {
        throw new ArgumentException(
            "Fiyat sıfırdan büyük olmalıdır."
        );
    }

    fiyatlar.Add(fiyat);
}