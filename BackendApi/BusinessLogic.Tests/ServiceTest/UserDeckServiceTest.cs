using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using Xunit;

namespace BusinessLogic.Tests
{
    public class UserDeckServiceTest
    {
        private readonly UserDeckService service;
        private readonly Mock<IUserDeckRepository> userDeckRepositoryMoq;

        public UserDeckServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userDeckRepositoryMoq = new Mock<IUserDeckRepository>();
            repositoryWrapperMoq.Setup(x => x.UserDeck).Returns(userDeckRepositoryMoq.Object);
            service = new UserDeckService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUserDeck_ShouldThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            userDeckRepositoryMoq.Verify(x => x.Create(It.IsAny<UserDeck>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ValidUserDeck_ShouldCreate()
        {
            var deck = new UserDeck { UserId = 1, DeckName = "My Deck" };
            await service.Create(deck);
            userDeckRepositoryMoq.Verify(x => x.Create(It.IsAny<UserDeck>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetInvalidUserDecks))]
        public async Task CreateAsync_InvalidUserDeck_ShouldNotCreate(UserDeck deck)
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(deck));
            Assert.IsType<ArgumentException>(ex);
            userDeckRepositoryMoq.Verify(x => x.Create(It.IsAny<UserDeck>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_UserDeckWithEmptyName_ShouldNotCreate()
        {
            var deck = new UserDeck { UserId = 1, DeckName = "" };
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(deck));
            Assert.IsType<ArgumentException>(ex);
            userDeckRepositoryMoq.Verify(x => x.Create(It.IsAny<UserDeck>()), Times.Never);
        }

        public static IEnumerable<object[]> GetInvalidUserDecks()
        {
            return new List<object[]>
            {
                new object[] { new UserDeck { UserId = 0, DeckName = "Test" } },
                new object[] { new UserDeck { UserId = 1, DeckName = null! } },
                new object[] { new UserDeck { UserId = 1, DeckName = "" } },
                new object[] { new UserDeck { UserId = -1, DeckName = "Test" } }
            };
        }
    }
}