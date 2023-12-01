using System.Security.Cryptography;

namespace BookRental
{
    public class LibraryLogicManager
    {
        private readonly ILibraryRepositoryManager repository;

        public LibraryLogicManager(ILibraryRepositoryManager libraryRepositoryManager)
        {
            this.repository = libraryRepositoryManager;
        }

        // Cerca libro
        public List<Book> SearchBook(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return repository.GetBooks();
            }

            //return (from book in books
            //       where book.Title.Contains(value, StringComparison.InvariantCultureIgnoreCase) || book.Author.Contains(value, StringComparison.InvariantCultureIgnoreCase)
            //       select book).ToList();

            return repository.GetBooks()
                .Where(book => book.Title.Contains(value, StringComparison.InvariantCultureIgnoreCase) 
                || book.Author.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        // Noleggia libro

        public void RentBook(Book book)
        {

            int count = repository.CountBookByID(book.Id);
            if (count == 0)
            {
                throw new KeyNotFoundException();
            }
            repository.DecreaseBookCount(book.Id, 1);
        }


        // Riconsegna libro

        public void ReturnBook(Book book){
            repository.IncreaseBookCount(book.Id, 1);
        }

        // Dona libro
        public void DonateBook(Book book)
        {
            if (repository.GetBooks().Any(b => b.Id == book.Id))
            {
                repository.IncreaseBookCount(book.Id, 1);
            } 
            else
            {
                repository.AddBook(book);
            }

        }
    }
}