/*
HashSet<string> kategoriler = new();

kategoriler.Add("Elektronik");
kategoriler.Add("Kitap");
kategoriler.Add("Giyim");

Console.WriteLine(kategoriler.Count);

bool birinciSonuc =
    kategoriler.Add("Kaan");

bool ikinciSonuc =
    kategoriler.Add("Kaan");

Console.WriteLine(birinciSonuc);
Console.WriteLine(ikinciSonuc);

if (kategoriler.Add("Elektronik"))
{
    Console.WriteLine("Kategori eklendi.");
}
else
{
    Console.WriteLine("Kategori zaten var.");
}

foreach (string kategori in kategoriler)
{
    Console.WriteLine(kategori);
}

if (kategoriler.Contains("Kitap"))
{
    Console.WriteLine("Kitap kategorisi var.");
}

bool silindiMi =
    kategoriler.Remove("Kitap");

if (silindiMi)
{
    Console.WriteLine("Kitap kategorisi silindi.");
}
*/

HashSet <string> kategoriler = new();

bool test1 = kategoriler.Add("Elektronik");
if(test1 ){

    Console.WriteLine("Elektronik eklendi");
}
else {
    Console.WriteLine("Elektronik zaten vardı");}
bool test2 = kategoriler.Add("Kitap");
if(test2 ){

    Console.WriteLine("Kitap eklendi");
}
else {
    Console.WriteLine("Kitap zaten vardı");}
bool test = kategoriler.Add("Elektronik");
if(test ){

    Console.WriteLine("Elektronik eklendi");
}
else {
    Console.WriteLine("Elektronik zaten vardı");}

foreach (string kategori in kategoriler){

    Console.WriteLine(kategori);
}

Console.WriteLine(kategoriler.Count);