using ConsoleApp1.models;

namespace ConsoleApp1.Services
{
    public static class CsvService
    {
        public static void Save(string path, IEnumerable<Athlete> athletes)
        {
            using var writer = new StreamWriter(path);
            foreach (var a in athletes)
            {
                writer.WriteLine($"{a.Id};{a.Name};{a.Sport};{a.Description};{a.Age};{a.Ranking};{a.IsFavorite}");
            }
        }

        public static List<Athlete> Load(string path)
        {
            var list = new List<Athlete>();

            foreach (var line in File.ReadAllLines(path))
            {
                var p = line.Split(';');
                list.Add(new Athlete(
                    int.Parse(p[0]),
                    p[1],
                    p[2],
                    p[3],
                    int.Parse(p[4]),
                    int.Parse(p[5]),
                    bool.Parse(p[6])
                ));
            }

            return list;
        }
    }
}
