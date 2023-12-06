using SnailRacing.BusinessLogic;
using SnailRacing.BusinessLogic.Interfaces;
using SnailRacing.Exceptions;
using SnailRacing.View.Interfaces;

namespace SnailRacing.View
{
    public class RacePage : IRacePage
    {
        private readonly IRaceLogic _raceLogic;

        public RacePage(IRaceLogic raceLogic)
        {
            _raceLogic = raceLogic;
        }

        public void View()
        {
            Console.WriteLine("Creazione gara");
            _raceLogic.CreateRace();

            Console.WriteLine("Dettagli gara");
            Console.WriteLine(_raceLogic.GetRaceDetails());

            Console.WriteLine("Inizio gara");
            _raceLogic.StartRace();

            // visualizzare avanzamento

            // visualizzare risultati
        }
    }
}