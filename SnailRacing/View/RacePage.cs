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

            while (true)
            {
                Console.WriteLine("Press any key to view details, press 'e' to exit");
                Console.WriteLine();
                var c = Console.ReadKey().KeyChar;
                if (c == 'e')
                {
                    break;
                }

                Race race = _raceLogic.GetRaceStatus();
                foreach (var dict in race.GetCurrentRaceProgression())
                {
                    Console.WriteLine($"{dict.Key.Name} ({dict.Key.Number}): {dict.Value}/{race.Length}");
                }
            }




            // visualizzare risultati
        }
    }
}