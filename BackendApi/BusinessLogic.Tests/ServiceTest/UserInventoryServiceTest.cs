using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using Xunit;

namespace BusinessLogic.Tests
{
    public class UserInventoryServiceTest
    {
        private readonly UserInventoryService service;
        private readonly Mock<IUserInventoryRepository> userInventoryRepositoryMoq;

        public UserInventoryServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userInventoryRepositoryMoq = new Mock<IUserInventoryRepository>();
            repositoryWrapperMoq.Setup(x => x.UserInventory).Returns(userInventoryRepositoryMoq.Object);
            service = new UserInventoryService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUserInventory_ShouldThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            userInventoryRepositoryMoq.Verify(x => x.Create(It.IsAny<UserInventory>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ValidUserInventory_ShouldCreate()
        {
            var inv = new UserInventory { UserId = 1, SpellId = 2 };
            await service.Create(inv);
            userInventoryRepositoryMoq.Verify(x => x.Create(It.IsAny<UserInventory>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetInvalidUserInventories))]
        public async Task CreateAsync_InvalidUserInventory_ShouldNotCreate(UserInventory inv)
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(inv));
            Assert.IsType<ArgumentException>(ex);
            userInventoryRepositoryMoq.Verify(x => x.Create(It.IsAny<UserInventory>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_UserInventoryWithZeroUserId_ShouldNotCreate()
        {
            var inv = new UserInventory { UserId = 0, SpellId = 1 };
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(inv));
            Assert.IsType<ArgumentException>(ex);
            userInventoryRepositoryMoq.Verify(x => x.Create(It.IsAny<UserInventory>()), Times.Never);
        }

        public static IEnumerable<object[]> GetInvalidUserInventories()
        {
            return new List<object[]>
            {
                new object[] { new UserInventory { UserId = -1, SpellId = 1 } },
                new object[] { new UserInventory { UserId = 1, SpellId = 0 } },
                new object[] { new UserInventory { UserId = 1, SpellId = -5 } }
            };
        }
    }
}