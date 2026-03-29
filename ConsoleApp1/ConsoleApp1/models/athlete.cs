namespace ConsoleApp1.models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public int Ranking { get; set; }
        public bool IsFavorite { get; set; }

        public Athlete() { }

        public Athlete(int id, string name, string sport, string description, int age, int ranking, bool isFavorite)
        {
            Id = id;
            Name = name;
            Sport = sport;
            Description = description;
            Age = age;
            Ranking = ranking;
            IsFavorite = isFavorite;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} ({Sport}) | Age: {Age} | Rank: {Ranking} | Favorite: {IsFavorite}";
        }
    }
}
