string[] sehirler =
{
    "İstanbul",
    "Ankara",
    "İzmir"
};

Console.WriteLine("İlk şehir:");
Console.WriteLine(sehirler[0]);

Console.WriteLine();

Console.WriteLine("Bütün şehirler:");

foreach (string sehir in sehirler)
{
    Console.WriteLine(sehir);
}

Console.WriteLine();

Console.WriteLine(
    $"Şehir sayısı: {sehirler.Length}"
);

List <decimal> fiyatlar = new();
fiyatlar.Add(20);
fiyatlar.Add(40);
fiyatlar.Add(50);
fiyatlar.Insert(1,150);

Console.WriteLine(fiyatlar[0]);

foreach (decimal fiyat in fiyatlar){

    Console.WriteLine("fiyat "+ fiyat);
}

Console.WriteLine(fiyatlar.Count);

decimal aranansayi = Convert.ToDecimal(Console.ReadLine());

if (fiyatlar.Contains(aranansayi)){

    Console.WriteLine("Fiyatlarda " +aranansayi + " var.");
}
else {
    
    Console.WriteLine("Fiyatlarda " +aranansayi + " yok.");
}


decimal SilinecekSayi = Convert.ToDecimal(Console.ReadLine());
fiyatlar.Remove(SilinecekSayi);

//fiyatlar.RemoveAt(0);

//fiyatlar.Clear();











fiyatlar.Add(60);

fiyatlar.Insert(1,60);

if (fiyatlar.Contains(40)){

    Console.WriteLine("40 tl bulundu");

}

fiyatlar.Remove(40);

foreach( decimal fiyat in fiyatlar){

    Console.WriteLine(fiyat);

}

Console.WriteLine(fiyatlar.Count);