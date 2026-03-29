using ConsoleApp1.models;

namespace ConsoleApp1.Services
{
    public static class HtmlGenerator
    {
        public static void GenerateIndex(string templatePath, string outputPath, List<Athlete> athletes)
        {
            string template = File.ReadAllText(templatePath);

            string stats = $"<p>Sportolók száma: {athletes.Count}</p>" +
                           $"<p>Kedvencek száma: {athletes.Count(a => a.IsFavorite)}</p>";

            string featured = string.Join("\n", athletes.Take(3).Select(a =>
                $"<div class='card'><h3>{a.Name}</h3><p>{a.Sport}</p></div>"
            ));

            template = template.Replace("{{TITLE}}", "Sportolók katalógusa");
            template = template.Replace("{{DESCRIPTION}}", "Sportolók adatbázisa és bemutató oldala.");
            template = template.Replace("{{STATS}}", stats);
            template = template.Replace("{{FEATURED}}", featured);

            File.WriteAllText(outputPath, template);
        }

        public static void GenerateItems(string templatePath, string outputPath, List<Athlete> athletes)
        {
            string template = File.ReadAllText(templatePath);

            string rows = string.Join("\n", athletes.Select(a =>
                $"<tr><td>{a.Name}</td><td>{a.Sport}</td><td>{a.Age}</td><td>{a.Ranking}</td><td>{a.Description}</td></tr>"
            ));

            template = template.Replace("{{ITEMS}}", rows);

            File.WriteAllText(outputPath, template);
        }

        public static void GenerateFavorites(string templatePath, string outputPath, List<Athlete> athletes)
        {
            string template = File.ReadAllText(templatePath);

            string cards = string.Join("\n", athletes.Where(a => a.IsFavorite).Select(a =>
                $"<div class='card fav'><h3>{a.Name}</h3><p>{a.Sport}</p><p>{a.Description}</p></div>"
            ));

            template = template.Replace("{{FAVORITES}}", cards);

            File.WriteAllText(outputPath, template);
        }
    }
}
