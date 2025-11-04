using NB1;
using System.Text;

// Adatok beolvasása
var fileData = await File.ReadAllLinesAsync("adatok.txt", Encoding.UTF8);

var players = new List<Player>();

foreach (var line in fileData)
{
    if (string.IsNullOrWhiteSpace(line)) continue;
    var data = line.Split('\t');
    DateTime birthDate;
    if (!DateTime.TryParse(data[4], out birthDate))
    {
        birthDate = new DateTime(2000, 1, 1);
    }

    players.Add(new Player
    {
        Club = data[0],
        Number = int.Parse(data[1]),
        FirstName = data[2],
        LastName = data[3],
        BirthDate = birthDate,
        Hungarian = data[5] == "-1",
        Foreign = data[6] == "-1",
        Value = int.Parse(data[7]),
        Position = data[8]
    });
}

// 1. Összes adat kiíratása
Console.WriteLine("1. feladat – Összes adat:\n");
foreach (var player in players)
{
    Console.WriteLine(player);
}

// 2. Legidősebb mezőnyjátékos
var oldest = players
    .Where(p => p.Position.ToLower() != "kapus")
    .OrderBy(p => p.BirthDate)
    .First();

Console.WriteLine($"\n2. feladat – Legidősebb mezőnyjátékos: {oldest.FullName} ({oldest.BirthDate:yyyy-MM-dd})");

// 3. Állampolgárság statisztika
int magyar = players.Count(p => p.Hungarian && !p.Foreign);
int kulfoldi = players.Count(p => p.Foreign && !p.Hungarian);
int kettos = players.Count(p => p.Hungarian && p.Foreign);

Console.WriteLine("\n3. feladat – Állampolgárság statisztika:");
Console.WriteLine($"   Magyar játékosok: {magyar}");
Console.WriteLine($"   Külföldi játékosok: {kulfoldi}");
Console.WriteLine($"   Kettős állampolgárok: {kettos}");

// 4. Csapatonkénti összérték
var teamValues = players
    .GroupBy(p => p.Club)
    .Select(g => new { Club = g.Key, TotalValue = g.Sum(p => p.Value) });

Console.WriteLine("\n4. feladat – Csapatonkénti összérték (ezer EUR):");
foreach (var t in teamValues)
{
    Console.WriteLine($"{t.Club,-20} {t.TotalValue} eEUR");
}

// 5. Csapatok, ahol csak egy játékos van adott poszton
var singlePosition = players
    .GroupBy(p => new { p.Club, p.Position })
    .Where(g => g.Count() == 1)
    .Select(g => $"{g.Key.Club} – {g.Key.Position}");

await File.WriteAllLinesAsync("egyedul_poszton.txt", singlePosition, Encoding.UTF8);
Console.WriteLine("\n5. feladat – Az egyedüliek posztonként mentve: egyedul_poszton.txt");

// 6. Átlag alatti értékű játékosok
double avgValue = players.Average(p => p.Value);
var belowAverage = players
    .Where(p => p.Value <= avgValue)
    .Select(p => p.ToFullString());

await File.WriteAllLinesAsync("atlag_alatt.txt", belowAverage, Encoding.UTF8);
Console.WriteLine("6. feladat – Átlag alatti játékosok mentve: atlag_alatt.txt");

// 7. 18–21 éves magyar játékosok
var youngHungarians = players
    .Where(p => p.Age >= 18 && p.Age <= 21 && p.Hungarian)
    .Select(p => $"{p.FullName} – {p.Club} ({p.Age} éves)");

await File.WriteAllLinesAsync("fiatalok.txt", youngHungarians, Encoding.UTF8);
Console.WriteLine("7. feladat – 18–21 éves magyar játékosok mentve: fiatalok.txt");

// 8. hazai.txt és legios.txt fájlok
var hazai = players.Where(p => p.Hungarian).GroupBy(p => p.Club);
var legios = players.Where(p => p.Foreign).GroupBy(p => p.Club);

using (var writer = new StreamWriter("hazai.txt", false, Encoding.UTF8))
{
    foreach (var group in hazai)
    {
        await writer.WriteLineAsync($"{group.Key}:");
        foreach (var player in group)
        {
            await writer.WriteLineAsync($"\t- {player.FullName} ({player.Position}) – {player.Value} eEUR");
        }
        await writer.WriteLineAsync();
    }
}

using (var writer = new StreamWriter("legios.txt", false, Encoding.UTF8))
{
    foreach (var group in legios)
    {
        await writer.WriteLineAsync($"{group.Key}:");
        foreach (var player in group)
        {
            await writer.WriteLineAsync($"\t- {player.FullName} ({player.Position}) – {player.Value} eEUR");
        }
        await writer.WriteLineAsync();
    }
}


Console.ReadKey();
