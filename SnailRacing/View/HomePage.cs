using SnailRacing.View.Interfaces;

namespace SnailRacing.View
{
    public class HomePage : IHomePage
    {
        private readonly IRacePage _racePage;

        public HomePage(IRacePage racePage)
        {
            _racePage = racePage;
        }

        public void View()
        {
            Dictionary<char, Action> actions = new()
            {
                { '1', GoToRace },
                { '2', GoToStatistics },
            };

            Console.WriteLine("Make your choice:");
            Console.WriteLine("[1] Simulate a race");
            Console.WriteLine("[2] View statistics");
            Console.WriteLine();

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            actions[choice]();
        }

        public void GoToRace()
        {
            _racePage.View();
        }

        public void GoToStatistics()
        {
            throw new NotImplementedException();
        }
    }
}