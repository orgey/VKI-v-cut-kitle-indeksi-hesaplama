using System.Diagnostics;

public class Program
{
    struct Hasta
    {
        public string hastaAdi;
        public int hastaBoyu;
        public int hastaKilosu;
        public float hastaVKI;
        public string hastaTeshisi;
    }
    static List<Hasta> hastaList = new List<Hasta>();
    static string girdi = "";

    public static void Main()
    {
        Console.WriteLine("VKI (vücut kitle indeksi) hesaplama programina hos geldin.");

        Menu();

    }
    private static void Menu()
    {
        Console.WriteLine("Hangi Islemi Yapmak Istersiniz?");
        Console.WriteLine("1 - Yeni Hasta");
        Console.WriteLine("2 - Hasta Listesi");
        Console.WriteLine("3 - Cikis");
        MenuSecimi();
    }
    private static void MenuSecimi()
    {
        string secim = Console.ReadLine();
        switch (secim)
        {
            case "1":
                YeniHasta();
                break;
            case "2":
                HastaListesi();
                break;
            case "3":
                break;
            default:
                Console.WriteLine("Yanlis Bir Secim Yaptiniz. Tekrar Deneyiniz.");
                MenuSecimi();
                break;
        }
    }
    static void YeniHasta()
    {
        Hasta h = new Hasta();
        Console.WriteLine("Istenen Bilgileri Lutfen Girin");

        h.hastaAdi = IsimAlma();
        h.hastaBoyu = BoyAlma();
        h.hastaKilosu = KiloAlma();
        h.hastaVKI = Hesaplama(h);
        h.hastaTeshisi = Siralama(h);
        hastaList.Add(h);
        Yazdir(h);
        MenuDon();
    }
    static string IsimAlma()
    {
        Console.Write("Lutfen Adinizi Giriniz : ");
        return Console.ReadLine();
    }
    static int BoyAlma()
    {
        Console.Write("Lutfen boyunuzu giriniz (Min: 50cm Max: 300cm): ");
        girdi = Console.ReadLine();
        if (int.TryParse(girdi, out int girdiboy) && girdiboy > 50 && girdiboy < 300)
        {
            return girdiboy;
        }
        else
        {
            Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz.");
            return BoyAlma();

        }


    }
    static int KiloAlma()
    {
        Console.Write("Lutfen kilonuzu giriniz (Min: 0kg Max: 300kg): ");
        girdi = Console.ReadLine();
        if (int.TryParse(girdi, out int girdikilo) && girdikilo > 0 && girdikilo < 300)
        {
            return girdikilo;
        }
        else
        {
            Console.WriteLine("Lutfen Gecerli Bir Deger Giriniz.");
            return KiloAlma();
        }
    }
    static float Hesaplama(Hasta h)
    {
        return (h.hastaKilosu / (float)Math.Round(Math.Pow(((float)h.hastaBoyu / 100), 2), 2));
    }
    static string Siralama(Hasta h)
    {
        float vki = h.hastaVKI;
        if (vki < 18.49)
        {
            return "Zayif";
        }
        else if (vki < 24.99)
        {
            return "Normal";
        }

        else if (vki < 29.99)
        {
            return "Hafif Kilolu";
        }
        else
        {
            return "Obez";
        }
    }
    private static void Yazdir(Hasta h)
    {
        RenkDegistir(h);
        Console.WriteLine($"Hasta : {h.hastaAdi}, Boyu : {h.hastaBoyu}," +
            $" Kilosu : {h.hastaKilosu}, VKI Indexi : {h.hastaVKI}, " +
            $"Teshis: {h.hastaTeshisi}");
        ResetRenk();
    }

    private static void RenkDegistir(Hasta h)
    {
        switch (h.hastaTeshisi)
        {
            case "Zayif":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "Normal":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "Hafif Kilolu":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "Obez":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            default:
                break;
        }
    }
    static void ResetRenk()
    {
        Console.ResetColor();
    }

    static void MenuDon()
    {
        Console.WriteLine("Menuye Donmek Icin Enter'a Basin.");
        Console.ReadLine();
        Console.Clear();
        Menu();
    }

    private static void HastaListesi()
    {
        foreach (var h in hastaList)
        {
            Yazdir(h);
        }
        MenuDon();
    }

}