using System.Diagnostics;

int boy =1 , kilo = 1;
float vki;
var girdi = "";

Console.WriteLine("VKI (vücut kitle indeksi) hesaplama programina hos geldin.");
Console.WriteLine("Istenen Bilgileri Lutfen Girin");

BoyAlma();
KiloAlma();
Hesaplama();
Siralama();
Again();

void BoyAlma()
{
    Console.Write("Lutfen boyunuzu giriniz (Min: 50cm Max: 300cm): ");
    girdi = Console.ReadLine();
    if (int.TryParse(girdi, out int girdiboy) && girdiboy > 50 && girdiboy < 300)
    {
        boy = girdiboy;
    }
    else
    {
        Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz.");
        BoyAlma();
    }
}
void KiloAlma()
{
    Console.Write("Lutfen kilonuzu giriniz (Min: 0kg Max: 300kg): ");
    girdi = Console.ReadLine();
    if (int.TryParse(girdi, out int girdikilo) && girdikilo > 0 && girdikilo < 300)
    {
        kilo = girdikilo;
    }
    else
    {
        Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz.");
        KiloAlma();
    }
}
void Hesaplama()
{
    
    vki = kilo/(float)Math.Round(Math.Pow(((float)boy / 100), 2), 2);
 
    Console.WriteLine($"Vucut Kitle Indeksiniz: {vki}");

}
void Siralama()
{
    Console.Write("VKI seviyeniz: ");

    if (vki < 18.49)
    {
        Console.WriteLine("Zayif");
    }
    else if (vki<24.99)
    {
        Console.WriteLine("Ideal");
    }
    else if (vki < 29.99)
    {
        Console.WriteLine("Hafif Kilolu");
    }
    else 
    {
        Console.WriteLine("Obez");
    }

}
void Again()
{
    Console.WriteLine("Yeni bir hesaplama yapmak istiyor musunuz? (E/H)");
    girdi = Console.ReadLine();
    girdi = girdi.ToLower();
    if (girdi == "e")
    {
        Console.Clear();
        Process.Start("VKI (vücut kitle indeksi) hesaplama", "");
    }
    else if (girdi == "h")
    {
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("Hatali Giris Yaptiniz");
        Again();
    }

}