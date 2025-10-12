using Moq;
using Xunit;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Tests
{
    public class UserUpgradeServiceTest
    {
        private readonly UserUpgradeService service;
        private readonly Mock<IUserUpgradeRepository> userUpgradeRepositoryMoq;

        public UserUpgradeServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userUpgradeRepositoryMoq = new Mock<IUserUpgradeRepository>();
            repositoryWrapperMoq.Setup(x => x.UserUpgrade).Returns(userUpgradeRepositoryMoq.Object);
            service = new UserUpgradeService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUserUpgrade_ShouldThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            userUpgradeRepositoryMoq.Verify(x => x.Create(It.IsAny<UserUpgrade>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ValidUserUpgrade_ShouldCreate()
        {
            var upgrade = new UserUpgrade { Name = "Damage Boost", CostClick = 100 };
            await service.Create(upgrade);
            userUpgradeRepositoryMoq.Verify(x => x.Create(It.IsAny<UserUpgrade>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetInvalidUserUpgrades))]
        public async Task CreateAsync_InvalidUserUpgrade_ShouldNotCreate(UserUpgrade upgrade)
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(upgrade));
            Assert.IsType<ArgumentException>(ex);
            userUpgradeRepositoryMoq.Verify(x => x.Create(It.IsAny<UserUpgrade>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_UserUpgradeWithEmptyName_ShouldNotCreate()
        {
            var upgrade = new UserUpgrade { Name = "", CostClick = 100 };
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(upgrade));
            Assert.IsType<ArgumentException>(ex);
            userUpgradeRepositoryMoq.Verify(x => x.Create(It.IsAny<UserUpgrade>()), Times.Never);
        }

        public static IEnumerable<object[]> GetInvalidUserUpgrades()
        {
            return new List<object[]>
            {
                new object[] { new UserUpgrade { Name = null!, CostClick = 100 } },
                new object[] { new UserUpgrade { Name = "", CostClick = 100 } },
                new object[] { new UserUpgrade { Name = "Boost", CostClick = -10 } }
            };
        }
    }
}