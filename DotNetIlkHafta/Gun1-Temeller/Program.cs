Console.WriteLine("Hello, World!"); 
Console.WriteLine("C# Öğreniyorum");
Console.WriteLine("Harika gidiyor!");

Console.WriteLine("Lütfen isminizi giriniz");
// ? işareti değişkenin null olabileceğini belirtir.
string? isim = Console.ReadLine();
Console.WriteLine("Lütfwen yaşınızı giriniz");


int yas;
//bool basarili = int.TryParse(Console.ReadLine(), out yas);
while (!int.TryParse(Console.ReadLine(), out yas)  || (yas<=0)) { //Tryparse ve Parse ikisi de stringi inte çeviriyor ama TryParse boolean 
    Console.WriteLine("Yaşınızı yanlış girdiniz");                //döndürürken Parse hata veriyor. Kullanıcı girdisinde TryParse daha iyi.
    Console.WriteLine("Lütfwen yaşınızı tekrar giriniz");
}
//if (basarili) {
    if (yas < 18) {
        Console.WriteLine("Ehliyet alamaz");
    }
    else {
    Console.WriteLine("Ehliyet alabilir");
    }
//}

//else {
// Console.WriteLine("Yaşınızı yanlış girdiniz");
// basarili = int.TryParse(Console.ReadLine(), out yas);
//}

double boy = 1.75;
bool okuyor = false;
// Metnin başındaki $ işareti,
// değişkenleri { } içinde kullanmamızı sağlar.
Console.WriteLine($"İsim: {isim}, yaş: {yas}");

Console.WriteLine("İsmim " + isim + " Yasım " + yas + " Boyum " + boy + " Üniversite durumum " + okuyor);

for (int i =0; i<yas; i++){
    Console.WriteLine(i);
    Console.WriteLine(i%2);
    if (i%2 == 0) {
        Console.WriteLine("Çift");
    }
    else {
        Console.WriteLine("Tek");
    }
}
//decimal return döndüğrüyor ki sonradan kullanabilesin void döndürmüyor
static decimal Indirimhesap(decimal fiyat, decimal yuzde){
    decimal indirim = fiyat * yuzde / 100;
    return fiyat - indirim;
}
Console.WriteLine("Fiyatı giriniz");
decimal fiyat = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Yüzdeyi giriniz");
decimal yuzde = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("İndirimli fiyat " + Indirimhesap (fiyat, yuzde));
decimal indirim = fiyat * yuzde / 100;
Console.WriteLine("İndirim miktarı " + indirim);