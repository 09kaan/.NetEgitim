/*Gün sonu görevlerin
Kod tamamlandıktan sonra aşağıdakileri kendin ekle:
Yavasla() metodunu Araba class’ına ekle.
Hızın sıfırın altına düşmesini engelle.
Tesla’nın bataryası bittiğinde hızlanmasını engelle.
Toyota’nın benzini bittiğinde hızlanmasını engelle.
Maksimum hızın aşılmasını engelle.
HibritAraba class’ı oluştur.
HibritAraba, hem IElektrikli hem IBenzinli uygulasın.
Bütün araçları List<Araba> içinde çalıştır.
*/
List<Araba> arabalar = new List<Araba>();

Tesla tesla = new Tesla("Model Y", 80);
Toyota toyota = new Toyota("Corolla", 30);
HibritArac hibritarac = new HibritArac("hibrit", 40, 80);

arabalar.Add(tesla);
arabalar.Add(toyota);
arabalar.Add(hibritarac);

foreach (Araba araba in arabalar)
{
    araba.Hizlan();
    araba.Hizlan();

    araba.BilgileriYazdir();

    Console.WriteLine();
}

foreach (Araba araba in arabalar)
{
    if (araba is IElektrikli elektrikliAraba)
    {
        elektrikliAraba.SarjEt();

        Console.WriteLine(
            $"{araba.Marka} şarj edildi."
        );
    }
}
foreach (Araba araba in arabalar){
    araba.Yavasla();
    araba.Yavasla();

    araba.BilgileriYazdir();

    Console.WriteLine();
}