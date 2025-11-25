using System.Numerics;
using System.Text;

var fileData = File.ReadAllLines("snooker.txt", Encoding.UTF8).Skip(1);
var versenyzok = new List<Versenyzo>();

foreach (var line in fileData)
{
    var data = line.Split(';');
    versenyzok.Add(new Versenyzo
    {
        Helyezes = int.Parse(data[0]),
        Nev = data[1],
        Orszag = data[2],
        Nyeremeny = int.Parse(data[3])
    });
}
Console.WriteLine("1. feladat: Adatok beolvasva.");

// 2. feladat - Kiiratások ellenőrzése
Console.WriteLine("\n2. feladat: Kiiratások ellenőrzése");
var minta = versenyzok.Take(3);
foreach (var v in minta)
{
    Console.WriteLine($"Helyezés: {v.Helyezes}, Név: {v.Nev}, Ország: {v.Orszag}, Nyeremény: {v.Nyeremeny}");
}

// 3. feladat - Versenyzők száma országonként
Console.WriteLine("\n3. feladat: A világranglistán 100 versenyző szerepel");

var orszagStatisztika = versenyzok
    .GroupBy(v => v.Orszag)
    .Select(g => new { Orszag = g.Key, Darab = g.Count() })
    .OrderByDescending(x => x.Darab);

Console.WriteLine("\nOrszágonkénti megoszlás:");
foreach (var stat in orszagStatisztika)
{
    Console.WriteLine($"{stat.Orszag}: {stat.Darab} fő");
}

// 4. feladat - Átlagos nyeremény
var atlag = versenyzok.Average(v => v.Nyeremeny);
Console.WriteLine($"\n4. feladat: A versenyzők átlagos nyereménye: {atlag:F2} font (kb. {(atlag * 380):F0} Ft)");

// 5. feladat - Legjobb kínai versenyző
var legjobbKinai = versenyzok
    .Where(v => v.Orszag == "Kína")
    .OrderBy(v => v.Helyezes)
    .First();

Console.WriteLine($"\n5. feladat: A legjobban kereső kínai versenyző:");
Console.WriteLine($"Helyezés: {legjobbKinai.Helyezes}");
Console.WriteLine($"Név: {legjobbKinai.Nev}");
Console.WriteLine($"Ország: {legjobbKinai.Orszag}");
Console.WriteLine($"Nyeremény összege: {legjobbKinai.Nyeremeny:N0} font (kb. {(legjobbKinai.Nyeremeny * 380):N0} Ft)");

// 6. feladat - Norvég versenyző keresése
var norvegVersenyzo = versenyzok.FirstOrDefault(v => v.Orszag == "Norvégia");

if (norvegVersenyzo != null)
{
    Console.WriteLine($"\n6. feladat: Van norvég versenyző a világranglistán: {norvegVersenyzo.Nev}");
}
else
{
    Console.WriteLine("\n6. feladat: Nincs norvég versenyző a világranglistán.");
}

// 7. feladat - Statisztika készítése
Console.WriteLine("\n7. feladat: Statisztika országok szerint csoportosításban");

var statisztika = versenyzok
    .GroupBy(v => v.Orszag)
    .Where(g => g.Count() > 4)
    .Select(g => new
    {
        Orszag = g.Key,
        Darab = g.Count()
    })
    .OrderByDescending(x => x.Darab);

using (var writer = new StreamWriter("stat.txt", false, Encoding.UTF8))
{
    foreach (var stat in statisztika)
    {
        writer.WriteLine($"{stat.Orszag} - {stat.Darab} fő");
    }
}

foreach (var stat in statisztika)
{
    Console.WriteLine($"{stat.Orszag} - {stat.Darab} fő");
}

Console.ReadKey();