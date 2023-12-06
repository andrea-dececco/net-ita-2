using SnailRacing.BusinessLogic.Interfaces;
using SnailRacing.Exceptions;

namespace SnailRacing.BusinessLogic
{
    public class RaceLogic : IRaceLogic
    {
        private Race? _race;

        public void CreateRace()
        {
            List<Snail> snails = new()
            {
                new("Pippo", 1),
                new("Franco", 77),
            };

            _race = new(100, snails);
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

        public void ViewRaceStatus()
        {

        }

        public void ViewResults()
        {

        }
    }
}