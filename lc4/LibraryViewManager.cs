namespace lc4
{
    public class LibraryViewManager
    {
        private LibraryLogicManager libraryLogic = new();


        public void WelcomeMenu()
        {
            Console.WriteLine("Benvenuto in libreria, cosa vuoi fare?");

            Console.WriteLine("[1] - Cerca");
            Console.WriteLine("[2] - Noleggia");
            Console.WriteLine("[3] - Restituisci");
            Console.WriteLine("[4] - Dona");

            Dictionary<char, Action> welcomeMenuActions = new()
            {
                {'1', SearchBook },
                {'2', RentBook },
                {'3', () => Console.WriteLine("Not implemented yet")},
                {'4', () => Console.WriteLine("Not implemented yet")},
            };

            char selection = Console.ReadKey().KeyChar;

            var action = welcomeMenuActions.GetValueOrDefault(selection) ?? throw new Exception();

            action();
        }

        public void SearchBook()
        {
            Console.WriteLine("Scrivi il titolo o l'autore");
            string? searchValue = Console.ReadLine();
            List<Book> books = libraryLogic.SearchBook(searchValue);

            if (!books.Any())
            {
                Console.WriteLine("Non ci sono libri");
            }
            else
            {
                Console.WriteLine(string.Join(",\n", books));
            }
        }

        public void RentBook()
        {
            Console.WriteLine("Noleggiato");
        }
    }
}