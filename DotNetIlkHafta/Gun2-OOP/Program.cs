/*
CLASS:
Object'lerin sahip olacağı property ve metotları tanımlayan şablondur.

OBJECT:
Bir class'tan new ile oluşturulan gerçek örnektir.

PROPERTY:
Nesneye ait bilgiyi tutar.
get okumayı, set değiştirmeyi sağlar.
private set dışarıdan değiştirmeyi engeller.

CONSTRUCTOR:
Object oluşturulurken otomatik çalışan özel metottur.
Class ile aynı adı taşır, dönüş tipi yazılmaz.
Başlangıç değerlerini ayarlar.

ENCAPSULATION:
Nesnenin iç durumunu korur.
Verilerin dışarıdan kontrolsüz değiştirilmesini engeller.
Değişikliklerin kurallı metotlarla yapılmasını sağlar.
*/

/*Araba araba1 = new Araba(); //gerçek örnek

araba1.Marka = "Tesla";
araba1.Model = "Model Y"; 
araba1.Hiz = 0;

araba1.BilgileriYazdir();

Araba araba2 = new Araba(); //Constructor olunca böyle yazamıyoruz içindeki marka modeli paranteze yazmamız gerek.
araba2.Marka = "Fiat";
araba2.Model = "Egea";
araba2.Hiz = 50;
*/
Araba araba1 = new Araba("Tesla", "Model Y"); //Object gerçek örnek
Araba araba2 = new Araba("Fiat", "Egea");
// araba1.Hız = 50; // güvenli değil hızı seti kapatalım

araba2.BilgileriYazdir();
araba2.Hızlan();
araba2.BilgileriYazdir();
araba2.Yavasla();
araba2.BilgileriYazdir();

araba1.Yavasla();
araba1.BilgileriYazdir();

public class Araba //şablon
{
    public string Marka { get; set; }    //property
    public string Model { get; set; }   
    public int Hiz { get; private set; }

    public Araba(string marka, string model)
    {
        Marka = marka;
        Model = model;
        Hiz = 0;
    }

    public void BilgileriYazdir()
    {
        Console.WriteLine($"Marka: {Marka}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Hız: {Hiz} km/s");
    }
    // Encapsulation:
    // Hiz yalnızca bu metot üzerinden değiştirilir.
    public void Hızlan(){
        Hiz = Hiz + 10;
    }
    public void Yavasla(){
        if(Hiz >= 10){
        Hiz = Hiz - 10;
        }
        else {
            Hiz = 0;
        }
    }
}