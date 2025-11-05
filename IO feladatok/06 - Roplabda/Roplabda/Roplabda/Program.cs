using Roplabda;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

var fileData = await File.ReadAllLinesAsync("adatok.txt", Encoding.UTF7);

var players = new List<Player>();

foreach (var line in fileData)
{
    var data = line.Split('\t');
    players.Add(new Player
    {
        Name = data[0],
        Height = int.Parse(data[1]),
        Post = data[2],
        Nationality = data[3],
        Team = data[4],
        Country = data[5],
    });
}
//1.
Console.WriteLine("Összes adat:");
foreach (var player in players) {
    Console.WriteLine(player);
}

//2.
var hitters = players.Where(x => x.Post == "ütõ").Select(x => x.ToStringPost());

await File.WriteAllLinesAsync("utok.txt", hitters, encoding: Encoding.UTF8);

//3.
var groupedByTeam = players
    .GroupBy(b => b.Team)
    .OrderBy(g => g.Key);

using (var writer = new StreamWriter("csapattagok.txt", false, Encoding.UTF8))
{
    foreach (var group in groupedByTeam)
    {
        await writer.WriteAsync($"{group.Key}: ");
        foreach (var player in group)
        {
            await writer.WriteAsync($"{player.Name}, ");
        }
        await writer.WriteLineAsync();
    }
}

//4.
var highs = players.OrderBy(x => x.Height).Select(x => x.ToString());

await File.WriteAllLinesAsync("magaslatok.txt", highs, encoding: Encoding.UTF8);

// 5.
var groupedByNationality = players
    .GroupBy(b => b.Nationality);

using (var writer = new StreamWriter("nemzetisegek.txt", false, Encoding.UTF8))
{
    foreach (var group in groupedByNationality)
    {
        await writer.WriteLineAsync($"{group.Key}: ");
        foreach (var player in group)
        {
            await writer.WriteLineAsync($"\t - {player.Name} -- {player.Post}");
        }
        await writer.WriteLineAsync();
    }
}

//6.
var sumOfHeights = 0;
var numberOfPlayers = 0;

var averageHeight = players.Average(x => x.Height);

var playersHigherThanAverage = players.Where(x => x.Height >= averageHeight).Select(x => x.ToString());

await File.WriteAllLinesAsync("atlagnalmagasabbak.txt", playersHigherThanAverage, encoding: Encoding.UTF8);

//7.
var groupByPost = players.GroupBy(x => x.Post)
                         .OrderBy(g => g.Key);

foreach (var group in groupByPost) {
    var groupOrder = group.OrderBy(x => x.Height);
    Console.WriteLine($"{group.Key}: ");
    foreach (var player in groupOrder) {
        Console.WriteLine($"\t - {player.Name}, {player.Height}");    
    }
}

//8.
var playersShorterThanAverage = players.Where(x => x.Height < averageHeight).Select(x => x.ToStringDwarves());

await File.WriteAllLinesAsync("alacsonyak.txt", playersShorterThanAverage, encoding: Encoding.UTF8);