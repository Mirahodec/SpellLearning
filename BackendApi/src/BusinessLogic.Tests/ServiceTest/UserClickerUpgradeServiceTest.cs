using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using Xunit;

namespace BusinessLogic.Tests
{
    public class UserClickerUpgradeServiceTest
    {
        private readonly UserClickerUpgradeService service;
        private readonly Mock<IUserClickerUpgradeRepository> userClickerUpgradeRepositoryMoq;

        public UserClickerUpgradeServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userClickerUpgradeRepositoryMoq = new Mock<IUserClickerUpgradeRepository>();
            repositoryWrapperMoq.Setup(x => x.UserClickerUpgrade).Returns(userClickerUpgradeRepositoryMoq.Object);
            service = new UserClickerUpgradeService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUserClickerUpgrade_ShouldThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            userClickerUpgradeRepositoryMoq.Verify(x => x.Create(It.IsAny<UserClickerUpgrade>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ValidUserClickerUpgrade_ShouldCreate()
        {
            var upgrade = new UserClickerUpgrade { UserId = 1, UpgradeId = 2 };
            await service.Create(upgrade);
            userClickerUpgradeRepositoryMoq.Verify(x => x.Create(It.IsAny<UserClickerUpgrade>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetInvalidUserClickerUpgrades))]
        public async Task CreateAsync_InvalidUserClickerUpgrade_ShouldNotCreate(UserClickerUpgrade upgrade)
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(upgrade));
            Assert.IsType<ArgumentException>(ex);
            userClickerUpgradeRepositoryMoq.Verify(x => x.Create(It.IsAny<UserClickerUpgrade>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_UserClickerUpgradeWithZeroUserId_ShouldNotCreate()
        {
            var upgrade = new UserClickerUpgrade { UserId = 0, UpgradeId = 1 };
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(upgrade));
            Assert.IsType<ArgumentException>(ex);
            userClickerUpgradeRepositoryMoq.Verify(x => x.Create(It.IsAny<UserClickerUpgrade>()), Times.Never);
        }

        public static IEnumerable<object[]> GetInvalidUserClickerUpgrades()
        {
            return new List<object[]>
            {
                new object[] { new UserClickerUpgrade { UserId = -1, UpgradeId = 1 } },
                new object[] { new UserClickerUpgrade { UserId = 1, UpgradeId = 0 } },
                new object[] { new UserClickerUpgrade { UserId = 1, UpgradeId = -5 } }
            };
        }
    }
}