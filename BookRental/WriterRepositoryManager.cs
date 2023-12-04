using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRental.Logger;

namespace BookRental
{
    public class WriterRepositoryManager : ILibraryRepositoryManager
    {
        Dictionary<Guid, int> booksDictionary = new()
        {
        };

        private List<Book> books = new() { };

        private readonly IMyLogger _logger;

        public WriterRepositoryManager(IMyLogger logger)
        {
            _logger = logger;
        }

        public List<Book> GetBooks()
        {
            _logger.Log("get booooks");
            return books;
        }

        public void AddBook(Book book)
        {
            _logger.Log("add book");
            books.Add(book);
            booksDictionary[book.Id] = 1;
        }

        public int CountBookByID(Guid id)
        {
            _logger.Log("count book");
            return booksDictionary.GetValueOrDefault(id);
        }

        public void IncreaseBookCount(Guid id, int count)
        {
            _logger.Log("increase");
            var value = booksDictionary.GetValueOrDefault(id);
            booksDictionary[id] = value + count;
        }

        public void DecreaseBookCount(Guid id, int count)
        {
            _logger.Log("decrease");
            var value = booksDictionary.GetValueOrDefault(id);
            booksDictionary[id] = value - count;
        }
    }
}
