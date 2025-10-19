using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using Xunit;

namespace BusinessLogic.Tests
{
    public class GachaPullServiceTest
    {
        private readonly GachaPullService service;
        private readonly Mock<IGachaPullRepository> gachaPullRepositoryMoq;

        public GachaPullServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            gachaPullRepositoryMoq = new Mock<IGachaPullRepository>();
            repositoryWrapperMoq.Setup(x => x.GachaPull).Returns(gachaPullRepositoryMoq.Object);
            service = new GachaPullService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullGachaPull_ShouldThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            gachaPullRepositoryMoq.Verify(x => x.Create(It.IsAny<GachaPull>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ValidGachaPull_ShouldCreate()
        {
            var pull = new GachaPull { SpellId = 1, UserId = 2 };
            await service.Create(pull);
            gachaPullRepositoryMoq.Verify(x => x.Create(It.IsAny<GachaPull>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetInvalidGachaPulls))]
        public async Task CreateAsync_InvalidGachaPull_ShouldNotCreate(GachaPull pull)
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(pull));
            Assert.IsType<ArgumentException>(ex);
            gachaPullRepositoryMoq.Verify(x => x.Create(It.IsAny<GachaPull>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_GachaPullWithZeroUserId_ShouldNotCreate()
        {
            var pull = new GachaPull { SpellId = 1, UserId = 0 };
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(pull));
            Assert.IsType<ArgumentException>(ex);
            gachaPullRepositoryMoq.Verify(x => x.Create(It.IsAny<GachaPull>()), Times.Never);
        }

        public static IEnumerable<object[]> GetInvalidGachaPulls()
        {
            return new List<object[]>
            {
                new object[] { new GachaPull { SpellId = 0, UserId = 1 } },
                new object[] { new GachaPull { SpellId = -1, UserId = 1 } },
                new object[] { new GachaPull { SpellId = 1, UserId = -5 } }
            };
        }
    }
}