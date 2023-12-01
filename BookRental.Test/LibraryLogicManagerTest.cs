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

        [Theory]
        [InlineData(2,4)]
        [InlineData(3,6)]
        [InlineData(4,8)]
        public void DoubleNumber_AnyInteger_DoubleResult(int origin, int result)
        {

            Assert.Equal(result, _libraryLogicManager.DoubleNumber(origin));

        }
    }
}
