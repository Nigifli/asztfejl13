using Konyvek;
using System.Net.Http.Headers;
using System.Text;

var fileData = await File.ReadAllLinesAsync("adatok.txt", Encoding.UTF7);

var books = new List<Book>();

foreach (var line in fileData) 
{ 
    var data = line.Split('\t');
    books.Add(new Book
    {
        FirstName = data[0],
        LastName = data[1],
        Birthday = DateTime.Parse(data[2]),
        Title = data[3],
        ISBN = data[4],
        Publisher = data[5],
        PublishYear = int.Parse(data[6]),
        Price = int.Parse(data[7]),
        Theme = data[8],
        PageNumber = int.Parse(data[9]),
        Honorarium = int.Parse(data[10])
    });
}

// Írjuk ki a képernyőre az össz adatot
Console.WriteLine($"1. Feladat: ");
foreach (var book in books) {
    Console.WriteLine(book);
}

// Keressük ki az informatika témajú könyveket és mentsük el őket az informatika.txt állományba
Console.WriteLine($"2. Feladat: ");
var informaticBooks = fileData.Where(x => x.Contains("informatika"));
await File.WriteAllLinesAsync("informatika.txt", informaticBooks, Encoding.UTF8);


// Az 1900.txt állományba mentsük el azokat a könyveket amelyek az 1900-as években íródtak
Console.WriteLine($"3. Feladat: ");
var booksPublishedIn20Century = books.Where(x => x.PublishYear >= 1900)
                                     .Where(x => x.PublishYear < 2000)
                                     .Select(x => x.ToFullString());
await File.WriteAllLinesAsync("1900.txt", booksPublishedIn20Century, Encoding.UTF8);

Console.ReadKey();