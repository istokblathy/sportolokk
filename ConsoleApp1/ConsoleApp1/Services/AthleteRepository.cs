using ConsoleApp1.models;

namespace ConsoleApp1.Services
{
    public class AthleteRepository
    {
        private List<Athlete> _athletes = new();
        private int _nextId = 1;

        public IReadOnlyList<Athlete> Athletes => _athletes;

        public void AddAthlete(string name, string sport, string description, int age, int ranking, bool isFavorite)
        {
            var athlete = new Athlete(_nextId++, name, sport, description, age, ranking, isFavorite);
            _athletes.Add(athlete);
        }

        public void AddAthlete(Athlete athlete)
        {
            if (athlete.Id == 0)
                athlete.Id = _nextId++;

            _nextId = Math.Max(_nextId, athlete.Id + 1);
            _athletes.Add(athlete);
        }

        public IEnumerable<Athlete> GetAll() => _athletes.OrderBy(a => a.Name);

        public Athlete? FindByName(string name) =>
            _athletes.FirstOrDefault(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Athlete> FilterBySport(string sport) =>
            _athletes.Where(a => a.Sport.Equals(sport, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Athlete> GetFavorites() =>
            _athletes.Where(a => a.IsFavorite);

        public IEnumerable<Athlete> SortByRanking() =>
            _athletes.OrderBy(a => a.Ranking);
    }
}
