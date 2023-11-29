using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc4
{
    public interface ILibraryRepositoryManager
    {
        public List<Book> GetBooks();
        public void AddBook(Book book);
        public int CountBookByID(Guid id);
        public void IncreaseBookCount(Guid id, int count);
        public void DecreaseBookCount(Guid id, int count);
        
    }
}
