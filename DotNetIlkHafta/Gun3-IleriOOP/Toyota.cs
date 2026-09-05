public class Toyota : Araba, IBenzinli
{
    public double BenzinLitresi { get; private set; }

    public Toyota(
        string model,
        double benzinLitresi)
        : base("Toyota", model, 190)
    {
        BenzinLitresi = benzinLitresi;
    }

    public override void Hizlan()
    {
        if (BenzinLitresi <= 0)
        {
            Console.WriteLine(
                "Benzin olmadığı için hızlanamaz."
            );

            return;
        }

        Hiz += 15;

        if (Hiz > MaksimumHiz)
        {
            Hiz = MaksimumHiz;
        }

        BenzinLitresi -= 0.2;
    }

    public void BenzinDoldur(double litre)
    {
        if (litre > 0)
        {
            BenzinLitresi += litre;
        }
    }

    public override void Yavasla(){
        if (Hiz < 10){
            Hiz = 0;
            return;
        }
        Hiz = Hiz - 10;
    }
}