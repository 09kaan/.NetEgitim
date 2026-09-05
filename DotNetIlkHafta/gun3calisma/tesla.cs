public class Tesla : Araba {

    public Tesla (string model, string bataryaYuzdesi) : base ( Marka, Model, MaksimumHiz){

        BataryaYuzdesi = bataryaYuzdesi;

    }

    public void Hızlan() {

        if (BataryaYuzdesi = 0 ){
            Console.WriteLine("Batarya yok hızalanmaz");

            return;
        }

        Hiz += 30;
        

    }


}