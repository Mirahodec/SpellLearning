using BusinessLogic.Services;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using Xunit;

namespace BusinessLogic.Tests
{
    public class GameSafeServiceTest
    {
        private readonly GameSafeService service;
        private readonly Mock<IGameSafeRepository> gameSafeRepositoryMoq;

        public GameSafeServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            gameSafeRepositoryMoq = new Mock<IGameSafeRepository>();
            repositoryWrapperMoq.Setup(x => x.GameSafe).Returns(gameSafeRepositoryMoq.Object);
            service = new GameSafeService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullGameSafe_ShouldThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            gameSafeRepositoryMoq.Verify(x => x.Create(It.IsAny<GameSafe>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ValidGameSafe_ShouldCreate()
        {
            var Safe = new GameSafe { UserId = 1, Level = 5, HighScore = 1000 };
            await service.Create(Safe);
            gameSafeRepositoryMoq.Verify(x => x.Create(It.IsAny<GameSafe>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetInvalidGameSafes))]
        public async Task CreateAsync_InvalidGameSafe_ShouldNotCreate(GameSafe safe)
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(safe));
            Assert.IsType<ArgumentException>(ex);
            gameSafeRepositoryMoq.Verify(x => x.Create(It.IsAny<GameSafe>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_GameSafeWithZeroUserId_ShouldNotCreate()
        {
            var safe = new GameSafe { UserId = 0 };
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(safe));
            Assert.IsType<ArgumentException>(ex);
            gameSafeRepositoryMoq.Verify(x => x.Create(It.IsAny<GameSafe>()), Times.Never);
        }

        public static IEnumerable<object[]> GetInvalidGameSafes()
        {
            return new List<object[]>
            {
                new object[] { new GameSafe { UserId = -1 } },
                new object[] { new GameSafe { UserId = 0, Level = -5 } }
            };
        }
    }
}