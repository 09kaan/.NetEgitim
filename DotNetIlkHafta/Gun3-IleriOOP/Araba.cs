public abstract class Araba
{
    public string Marka { get; }
    public string Model { get; }
    public int Hiz { get; protected set; }
    public int MaksimumHiz { get; }

    protected Araba(string marka, string model, int maksimumHiz)
    {
        Marka = marka;
        Model = model;
        MaksimumHiz = maksimumHiz;
        Hiz = 0;
    }

    public void Dur()
    {
        Hiz = 0;
    }

    public void BilgileriYazdir()
    {
        Console.WriteLine($"Marka: {Marka}");
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Hız: {Hiz}/{MaksimumHiz} km/s");
    }
    public abstract void Hizlan();

    public abstract void Yavasla();

}