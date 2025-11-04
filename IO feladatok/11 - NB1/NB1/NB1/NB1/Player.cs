namespace NB1;

public class Player
{
    public string Club { get; set; }
    public int Number { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Hungarian { get; set; }
    public bool Foreign { get; set; }
    public int Value { get; set; }
    public string Position { get; set; }

    public string FullName => $"{FirstName} {LastName}".Trim();

    public int Age => DateTime.Now.Year - BirthDate.Year -
        (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);

    public override string ToString()
    {
        return $"{Club} #{Number}: {FullName} – {Position} ({Value} eEUR)";
    }

    public string ToFullString()
    {
        return $"{Club}\t{Number}\t{FirstName}\t{LastName}\t{BirthDate:yyyy-MM-dd}\t" +
               $"{(Hungarian ? "-1" : "0")}\t{(Foreign ? "-1" : "0")}\t{Value}\t{Position}";
    }
}