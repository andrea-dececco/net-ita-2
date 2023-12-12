using SnailRacing.BusinessLogic.Interfaces;
using SnailRacing.Exceptions;
using SnailRacing.Repository.Interfaces;

namespace SnailRacing.BusinessLogic
{
    public class RaceLogic : IRaceLogic
    {
        private readonly IRaceRepository _raceRepository;
        private Race? _race;

        public RaceLogic(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }

        public void CreateRace()
        {
            List<Snail> snails = new()
            {
                new("Pippo", 1),
                new("Franco", 77),
            };

            _race = new(5, snails, RaceFinishedAsync);
        }

        public string GetRaceDetails()
        {
            if (_race == null)
            {
                throw new RaceNotFoundException();
            }

            string result = $"Race length: {_race.Length}\n";
            result += "Participants:\n";
            result += string.Join("\n", _race.ParticipantSnails.Select(x => $"{x.Name} ({x.Number})"));
            return result;
        }

        public void StartRace()
        {
            if (_race == null)
            {
                throw new RaceNotFoundException();
            }

            _race.Start();
        }

        public Race GetRaceStatus()
        {
            if (_race == null)
            {
                throw new RaceNotFoundException();
            }

            return _race;
        }

        private async Task RaceFinishedAsync(Race race)
        {
            await _raceRepository.AddRaceAsync(race);
            await _raceRepository.SaveChangesAsync();
        }
    }
}