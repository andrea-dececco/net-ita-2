using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental
{
    public class WriterRepositoryManager : ILibraryRepositoryManager
    {
        Dictionary<Guid, int> booksDictionary = new()
        {

        };


        private List<Book> books = new() { };
        
        public List<Book> GetBooks()
        {
            Console.WriteLine("scrivo cose");
            return books;
        }

        public void AddBook(Book book)
        {
            Console.WriteLine("scrivo cose");
            books.Add(book);
            booksDictionary[book.Id] = 1;
        }

        public int CountBookByID(Guid id) 
        {
            Console.WriteLine("scrivo cose");
            return booksDictionary.GetValueOrDefault(id);
        }

        public void IncreaseBookCount(Guid id, int count)
        {
            Console.WriteLine("scrivo cose");
            var value = booksDictionary.GetValueOrDefault(id);
            booksDictionary[id] = value + count;
        }

        public void DecreaseBookCount(Guid id, int count)
        {
            Console.WriteLine("scrivo cose");
            var value = booksDictionary.GetValueOrDefault(id);
            booksDictionary[id] = value - count;
        }
    }
}
