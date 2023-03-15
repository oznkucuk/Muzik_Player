using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
 
namespace calisma2022_12_26
{
    public enum Durum
    {
        Stop,
        Play,
        Pause
    }
 
    class Program
    {
        static List<string> parcalar = new List<string>();
        static int secilenParca;
        static Durum programDurum = Durum.Stop;
 
        static void Main(string[] args)
        {
            // SETUP
            int toplamParcaSayisi = 3;
            ListeDoldur(toplamParcaSayisi);
            Console.Clear();
 
            //Döngü
            bool devam = true;
            while (devam)
            {
                switch (programDurum)
                {
                    case Durum.Stop:
                        EkranStop();
                        devam = EkranStopIslemler();
                        break;
                    case Durum.Play:
                        EkranPlay(secilenParca);
                        devam = EkranPlayIslemler();
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Program Sonlanıyor...");
        }
 
        private static bool EkranPlayIslemler()
        {
            bool programDevam = true;
            bool donguDevam = true;
            while (donguDevam)
            {
                Console.WriteLine("(S)top\t\t E(x)it");
                string s = Console.ReadLine();
 
                if (s.ToLower() == "s")
                {
                    programDurum = Durum.Stop;
                    donguDevam = false;
                    programDevam = true;
                }
                else if (s.ToLower() == "x")
                {
                    donguDevam = false;
                    programDevam = false;
                }
                else
                {
                    Console.WriteLine("Geçersiz komut");
                    donguDevam = true;
                }
            }
            return programDevam;
        }
 
        private static bool EkranStopIslemler() // geri dönüş değeri devam bilgisi içeriyor
        {
            Console.WriteLine("Parça Seçim Yapınız. Çıkış için (x)");
 
            bool devam = true;
            while (devam)
            {
                string giris = Console.ReadLine();
 
                if (giris.ToLower() == "x")
                {
                    return false; // x girildi döngü sonlandır
                }
 
                if (int.TryParse(giris, out int girisSayi))
                {
                    // girilen bir sayı  0 1 2
                    girisSayi = girisSayi - 1;
 
                    if (girisSayi >= 0 && girisSayi < parcalar.Count)
                    {
                        // parça seçildi
                        secilenParca = girisSayi;
                        devam = false;
 
                    }
                }
                Console.WriteLine("Geçersiz Giriş");
            }
            // Parça seçildi Play'e geçiş
            programDurum = Durum.Play;
            return true; // döngü devam
 
        }
 
        private static void EkranPlay(int parcaIndex)
        {
            Console.Clear();
            Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=");
            Console.WriteLine($" {parcalar[parcaIndex]} ÇALIYOR...");
            Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=");
        }
 
        private static void EkranStop()
        {
            Console.Clear();
            Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=");
            for (int i = 0; i < parcalar.Count; i++)
            {
                Console.WriteLine($"    ({i + 1}) : {parcalar[i]} ");
            }
            Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=");
        }
 
        private static void ListeDoldur(int toplamParca)
        {
            for (int i = 0; i < toplamParca; i++)
            {
                parcalar.Add($"    {i + 1}.Parça");
            }
        }
    }
}
