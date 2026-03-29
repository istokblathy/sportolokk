using ConsoleApp1.Services;
using ConsoleApp1.models;

var repo = new AthleteRepository();

while (true)
{
    Console.WriteLine("\n---- SPORTOLÓK KATALÓGUSA ----");
    Console.WriteLine("1 - Új sportoló hozzáadása");
    Console.WriteLine("2 - Lista megjelenítése");
    Console.WriteLine("3 - Keresés név alapján");
    Console.WriteLine("4 - Szűrés sportág szerint");
    Console.WriteLine("5 - CSV Mentés");
    Console.WriteLine("6 - CSV Betöltés");
    Console.WriteLine("7 - HTML export");
    Console.WriteLine("0 - Kilépés");
    Console.Write("Választás: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddAthlete();
            break;

        case "2":
            ListAll();
            break;

        case "3":
            SearchByName();
            break;

        case "4":
            FilterBySport();
            break;

        case "5":
            CsvService.Save("athletes.csv", repo.Athletes);
            Console.WriteLine("CSV fájl mentve: athletes.csv");
            break;

        case "6":
            LoadCsv();
            break;

        case "7":
            ExportHtml();
            break;

        case "0":
            Console.WriteLine("Kilépés...");
            return;

        default:
            Console.WriteLine("Érvénytelen választás.");
            break;
    }
}

void AddAthlete()
{
    Console.Write("Név: ");
    string name = Console.ReadLine()!;

    Console.Write("Sportág: ");
    string sport = Console.ReadLine()!;

    Console.Write("Leírás: ");
    string description = Console.ReadLine()!;

    Console.Write("Életkor: ");
    int age = int.Parse(Console.ReadLine()!);

    Console.Write("Ranglista helyezés: ");
    int ranking = int.Parse(Console.ReadLine()!);

    Console.Write("Kedvenc? (i/n): ");
    bool isFavorite = Console.ReadLine()!.Trim().ToLower() == "i";

    repo.AddAthlete(name, sport, description, age, ranking, isFavorite);

    Console.WriteLine("Sportoló hozzáadva.");
}

void ListAll()
{
    Console.WriteLine("\n--- SPORTOLÓK LISTÁJA ---");
    foreach (var athlete in repo.GetAll())
        Console.WriteLine(athlete);
}

void SearchByName()
{
    Console.Write("Keresett név: ");
    string name = Console.ReadLine()!;

    var result = repo.FindByName(name);

    if (result == null)
        Console.WriteLine("Nincs találat.");
    else
        Console.WriteLine(result);
}

void FilterBySport()
{
    Console.Write("Sportág: ");
    string sport = Console.ReadLine()!;

    var results = repo.FilterBySport(sport);

    Console.WriteLine("\n--- TALÁLATOK ---");
    foreach (var athlete in results)
        Console.WriteLine(athlete);
}

void LoadCsv()
{
    if (!File.Exists("athletes.csv"))
    {
        Console.WriteLine("Nincs CSV fájl a mappában.");
        return;
    }

    var loaded = CsvService.Load("athletes.csv");
    foreach (var a in loaded)
        repo.AddAthlete(a);

    Console.WriteLine("CSV betöltve.");
}

void ExportHtml()
{
    HtmlGenerator.GenerateIndex("template/template_index.html", "index.html", repo.Athletes.ToList());
    HtmlGenerator.GenerateItems("template/template_items.html", "items.html", repo.Athletes.ToList());
    HtmlGenerator.GenerateFavorites("template/template_favorites.html", "favorites.html", repo.Athletes.ToList());

    Console.WriteLine("HTML oldalak elkészültek: index.html, items.html, favorites.html");
}
