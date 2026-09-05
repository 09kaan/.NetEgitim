Dictionary<int, string> urunler = new();

urunler.Add(101, "Klavye");
urunler.Add(102, "Mouse");
urunler.Add(103, "Monitör");


Console.WriteLine(urunler[101]);

if (int.TryParse(Console.ReadLine(),out int urunId)){                   //Girdi input, istediğimiz urunId

    if (urunler.TryGetValue(urunId, out string urunAdi))                //Girdi urunId, istediğimiz urunAdi

        Console.WriteLine("Ürün bulundu " +urunAdi);
    
    else {
        Console.WriteLine("Ürün bulunamadı.");
    }
}

else {
    Console.WriteLine("Id sayı olmalıdır.");
}

foreach(KeyValuePair<int,string> urun in urunler){                       //foreach(var urun in urunler){  bu da oluyor var her dğeişken yerine geçiyormuş

    Console.WriteLine(urun);
}