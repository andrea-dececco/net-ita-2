using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental.Test
{
    public class LibraryLogicManagerTest
    {
        private readonly LibraryLogicManager _libraryLogicManager;
        private readonly Mock<ILibraryRepositoryManager> _libraryRepositoryManagerMock = new();
        public LibraryLogicManagerTest()
        {
            _libraryLogicManager = new(_libraryRepositoryManagerMock.Object);
        }

        [Fact]
        public void DonateBook_ExistentBook_CallsIncrementation()
        {
            Book book = new Book(string.Empty, string.Empty);
            _libraryRepositoryManagerMock.Setup(r => r.GetBooks()).Returns(() => new List<Book>() { book });

            _libraryLogicManager.DonateBook(book);
            _libraryRepositoryManagerMock.Verify(r => r.IncreaseBookCount(book.Id,1),Times.Once);
            _libraryRepositoryManagerMock.Verify(f => f.AddBook(It.IsAny<Book>()), Times.Never);    // in alternativa  _libraryRepositoryManagerMock.VerifyNoOtherCalls;
           
        }

        [Fact]
        public void DonateBook_NewBook_CallsAddBook()
        {
            Book book = new Book(string.Empty, string.Empty);
            _libraryRepositoryManagerMock.Setup(r => r.GetBooks()).Returns(() => new List<Book>() { new Book(string.Empty,string.Empty) });

            _libraryLogicManager.DonateBook(book);
            _libraryRepositoryManagerMock.Verify(r => r.IncreaseBookCount(It.IsAny<Guid>(), It.IsAny<int>()), Times.Never);
            _libraryRepositoryManagerMock.Verify(f => f.AddBook(book), Times.Once);    

        }
    }
}
