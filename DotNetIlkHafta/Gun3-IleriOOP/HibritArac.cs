public class HibritArac : Araba, IElektrikli, IBenzinli{

    public int BataryaYuzdesi { get; private set;}
    public double BenzinLitresi { get; private set;}

    public HibritArac (string model, int bataryaYuzdesi, double benzinLitresi) : base ("HibritArac", model, 170){
        BenzinLitresi = benzinLitresi;
        BataryaYuzdesi = bataryaYuzdesi;
    }

    public override void Hizlan (){
        if (BataryaYuzdesi <= 0 && BenzinLitresi <= 0){
            Console.WriteLine("Yakıtın bitmiş hızlanamaz.");
            return;
        }
        Hiz += 25;

        if (Hiz > MaksimumHiz){
            Hiz = MaksimumHiz;
        }

        if (BataryaYuzdesi > 0){
            BataryaYuzdesi -= 5;

        }
        else if (BenzinLitresi > 0 ){
            BenzinLitresi -= 10;
        }
    }

    public override void Yavasla(){
        if (Hiz <= 10){
            Hiz = 0;
        }
        else {
            Hiz -= 10;
        }
    }

    public void SarjEt() {
        BataryaYuzdesi = 100;
    }

     public void BenzinDoldur(double litre)
    {
        if (litre > 0)
        {
            BenzinLitresi += litre;
        }
    }







}