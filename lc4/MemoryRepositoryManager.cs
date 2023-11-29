using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc4
{
    public class MemoryRepositoryManager : ILibraryRepositoryManager
    {
        Dictionary<Guid, int> booksDictionary = new()
        {

        };


        private List<Book> books = new() { };
        
        public List<Book> GetBooks()
        {
            return books;
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            booksDictionary[book.Id] = 1;
        }

        public int CountBookByID(Guid id) 
        {
            return booksDictionary.GetValueOrDefault(id);
        }

        public void IncreaseBookCount(Guid id, int count)
        {
            var value = booksDictionary.GetValueOrDefault(id);
            booksDictionary[id] = value + count;
        }

        public void DecreaseBookCount(Guid id, int count)
        {
            var value = booksDictionary.GetValueOrDefault(id);
            booksDictionary[id] = value - count;
        }
    }
}
