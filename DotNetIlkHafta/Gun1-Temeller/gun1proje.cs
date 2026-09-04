/*
Projen şu bilgileri kullanıcıdan alsın:
Ürün adı
Ürün fiyatı
İndirim oranı
Şunları kontrol etsin:
Ürün adı boş mu?
Fiyat geçerli bir sayı mı?
Fiyat sıfırdan büyük mü?
İndirim geçerli bir sayı mı?
İndirim 0–100 arasında mı?
Son olarak indirimli fiyatı bir metotla hesaplasın.
*/
Console.WriteLine("Ürün adını giriniz");
string? urun_adi = Console.ReadLine();
while (string.IsNullOrWhiteSpace(urun_adi)){
    Console.WriteLine("Ürün adı boş bıraklıamaz.");
    Console.WriteLine("Ürün adını giriniz");
    urun_adi = Console.ReadLine();

}
Console.WriteLine("Ürün adı" + urun_adi);
Console.WriteLine("Ürün fiyatını giriniz");
int fiyat;
while (!int.TryParse(Console.ReadLine(),out fiyat) || (fiyat <= 0)){
        Console.WriteLine("0dan büyük sayı giriniz.");
        Console.WriteLine("Ürün fiyatını giriniz");

}
    
        Console.WriteLine("Ürünün fiyatı " + fiyat );
    
Console.WriteLine("İndirim Oranı");
int oran;
while (!int.TryParse(Console.ReadLine(),out oran) || (oran > 100) || (oran < 0)){
   
        Console.WriteLine("0 ve 100 arasında olmalı.");
    
}
        Console.WriteLine("İndirim Oranu  " + oran );

static decimal Indirimhesap (decimal fiyat, decimal oran){
    decimal indirim = fiyat*oran/100;
    return fiyat - indirim;
}
Console.WriteLine(Indirimhesap(fiyat,oran));