using System.Security.Cryptography;

namespace lc4
{
    public class LibraryLogicManager
    {
        Dictionary<Guid, int> booksDictionary = new()
        {

        };


        private List<Book> books = new()
        {
            new("Harry Potter 1", "JKR"),
            new("Harry Potter 2", "JKR"),
            new("Le avventure di Pippo Franco", "Mario"),
        };

        // Cerca libro
        public List<Book> SearchBook(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return books;
            }

            //return (from book in books
            //       where book.Title.Contains(value, StringComparison.InvariantCultureIgnoreCase) || book.Author.Contains(value, StringComparison.InvariantCultureIgnoreCase)
            //       select book).ToList();

            return books
                .Where(book => book.Title.Contains(value, StringComparison.InvariantCultureIgnoreCase) 
                || book.Author.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        // Noleggia libro

       public void RentBook(Book book){
        int count = booksDictionary.GetValueOrDefault(book.Id);
        if( count  == 0){
            throw new KeyNotFoundException();
        } 
        booksDictionary[book.Id] = count--;
       }


        // Riconsegna libro

        public void ReturnBook(Book book){
            int count = booksDictionary.GetValueOrDefault(book.Id);
                    booksDictionary[book.Id] = count++;
        }

        // Dona libro
        public void DonateBook(Book book)
        {
            int count;
            if (books.Any(b => b.Id == book.Id))
            {
                count = booksDictionary.GetValueOrDefault(book.Id);
                
            } 
            else
            {
                count = 0;
                books.Add(book);
            }

            booksDictionary[book.Id] = count++;
        }
    }
}