public class Tesla : Araba, IElektrikli                //Class declaration 
{
    public int BataryaYuzdesi { get; private set; }    //Kendi özellikleri Property

    public Tesla(string model, int bataryaYuzdesi)     //?
        : base("Tesla", model, 220)
    {
        BataryaYuzdesi = bataryaYuzdesi;
    }
    public override void Hizlan(){
        if (BataryaYuzdesi <= 0){
            Console.WriteLine("Batarya 0 hızlanamaz");
            return;                                    //Voidde return değer döndürmez metodun çalışmasını bitirir.
        }
        Hiz +=30;

        if (Hiz > MaksimumHiz){
            Hiz = MaksimumHiz;
        } 
        BataryaYuzdesi--;
    }
    public void SarjEt()
    {
        BataryaYuzdesi = 100;
    }
   
    public override void Yavasla(){
        if (Hiz < 15){
            Hiz = 0;
            return;
        }
        Hiz = Hiz -15;
    }
}