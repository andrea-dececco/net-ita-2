namespace lc4
{
    public class LibraryLogicManager
    {
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

            List<Book> result = new();

            foreach (var book in books)
            {
                if (book.Title.Contains(value, StringComparison.InvariantCultureIgnoreCase) || book.Author.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        // Noleggia libro

        // Riconsegna libro

        // Dona libro

    }
}