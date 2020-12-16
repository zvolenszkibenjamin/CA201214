using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA201214
{
    internal static class Kosar2004
    {
        private static List<Merkozes> _merkozesek = new List<Merkozes>();
        
        public static void Main(string[] args)
        {
            // Programozás gyakorlat házi feladat
            // 2020. 12. 14.
            // "ACB kosárlabdaliga 2004-2005"
            // Zvolenszki Benjámin

            Console.WriteLine("ACB kosárlabdaliga 2004-2005 - Zvolenszki Benjámin");
            
            Beolvasas(); // 2. feladat
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

            Console.ReadKey(true);
        }

        private static void Beolvasas() // eredmenyek.csv beolvasása
        {
            const string eredmenyekPath = @"..\..\Resources\eredmenyek.csv";
            using (var sr = new StreamReader(eredmenyekPath, Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                    _merkozesek.Add((Merkozes) sr.ReadLine());
            }
        }

        private static void Feladat3()
        {
            var realMadridHazai = _merkozesek.Count(m => m.HazaiCsapat == "Real Madrid");
            var realMadridIdegen = _merkozesek.Count(m => m.IdegenCsapat == "Real Madrid");
            Console.WriteLine($"3. feladat: Real Madrid: Hazai: {realMadridHazai}, Idegen: {realMadridIdegen}");
        }

        private static void Feladat4()
        {
            var dontetlen = _merkozesek.Any(m => m.HazaiPont == m.IdegenPont) ? "igen" : "nem";
            Console.WriteLine($"4. feladat: Volt döntetlen? {dontetlen}");
        }

        private static void Feladat5()
        {
            // Megkeresem azt a mérkőzést, ahol a hazai vagy az idegen
            // csapat neve tartalmazza a "Barcelona" szót.
            var barcCsapatosMerkozes = _merkozesek.Find(
                m =>
                    m.HazaiCsapat.Contains("Barcelona")
                    || m.IdegenCsapat.Contains("Barcelona"));
            // Megnézem, hogy a hazai vagy az idegen csapat neve tartalmazta -e
            // a "Barcelona" szót, és ez alapján visszaadom a hazai csapat vagy
            // az idegen csapat nevét.
            var barcCsapatNev = barcCsapatosMerkozes.HazaiCsapat.Contains("Barcelona")
                ? barcCsapatosMerkozes.HazaiCsapat
                : barcCsapatosMerkozes.IdegenCsapat;
            
            Console.WriteLine($"5. feladat: barcelonai csapat neve: {barcCsapatNev}");
        }

        private static void Feladat6()
        {
            var refDate = new DateTime(2004, 11, 21);
            var _2004esMerkozesek = _merkozesek.Where(
                m => m.Idopont == refDate);
            
            Console.WriteLine("6. feladat:");
            foreach (var merkozes in _2004esMerkozesek)
            {
                Console.WriteLine(
                    $"\t{merkozes.HazaiCsapat}-{merkozes.IdegenCsapat} " +
                    $"({merkozes.HazaiPont}-{merkozes.IdegenPont})");
            }
        }

        private static void Feladat7()
        {
            var stadionok = _merkozesek.Select(m => m.Helyszin).ToHashSet();
            var stadMerk = stadionok.ToDictionary(
                stadion => stadion, 
                stadion => _merkozesek.Count(m => m.Helyszin == stadion));

            Console.WriteLine("7. feladat");
            foreach (var stad in stadMerk.Where(stad => stad.Value > 20))
                Console.WriteLine($"\t{stad.Key}: {stad.Value}");
        }
    }
}