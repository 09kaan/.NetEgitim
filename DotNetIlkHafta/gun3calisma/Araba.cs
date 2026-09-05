public abstract class Araba {

    public string Model {get;}
    public string Marka {get;}
    public int Hiz {get; protected set;}
    public int MaksimumHiz { get; }

    protected Araba (string model, string marka, int maksimumHiz){

        Model = model;
        Marka = marka;
        MaksimumHiz = maksimumHiz;
        Hiz = 0;
    }  

    public void BilgileriYazdir(){

        Console.WriteLine("Marka: " + Marka );
        Console.WriteLine("Model: " + Model );
        Console.WriteLine("Hız: " + Hiz "/" + MaksimumHiz " km/s");
    }

    public void Dur(){

        Hiz = 0;
    }

    public abstract void Hizlan();
    public abstract void Yavasla();
    
}