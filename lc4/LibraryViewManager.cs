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
            List<Book> books = FindBooksByTitle();

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
            List<Book> books = FindBooksByTitle();
            if (!books.Any())
            {
                Console.WriteLine("Non ci sono libri");
                return;
            } 
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"[{i}]-{books[i]}");

            }
            Console.WriteLine("Scegli un libro digitando l'indice");
            string scelta = Console.ReadLine();
            int numero = int.Parse(scelta);
            Book book = books[numero];

            Console.WriteLine($"Noleggiato {book}");                               
           
        }

        private List<Book> FindBooksByTitle()
        {
            Console.WriteLine("Scrivi il titolo o l'autore");
            string? searchValue = Console.ReadLine();
            List<Book> books = libraryLogic.SearchBook(searchValue);
            return books;
        }

    }
}