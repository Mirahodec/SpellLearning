using Moq;
using Xunit;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;

namespace BusinessLogic.Tests
{
    public class TraceServiceTest
    {
        private readonly TraceService service;
        private readonly Mock<ITraceRepository> TraceRepositoryMoq;

        public TraceServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            TraceRepositoryMoq = new Mock<ITraceRepository>();
            repositoryWrapperMoq.Setup(x => x.Trace).Returns(TraceRepositoryMoq.Object);
            service = new TraceService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullTrace_ShouldThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            TraceRepositoryMoq.Verify(x => x.Create(It.IsAny<Trace>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ValidTrace_ShouldCreate()
        {
            var Trace = new Trace { UserIdOffer = 1, UserIdReceive = 2, InventoryIdOffer = 3, InventoryIdWant = 4 };
            await service.Create(Trace);
            TraceRepositoryMoq.Verify(x => x.Create(It.IsAny<Trace>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetInvalidTraces))]
        public async Task CreateAsync_InvalidTrace_ShouldNotCreate(Trace trace)
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(trace));
            Assert.IsType<ArgumentException>(ex);
            TraceRepositoryMoq.Verify(x => x.Create(It.IsAny<Trace>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_TraceWithZeroUserIdOffer_ShouldNotCreate()
        {
            var trace = new Trace { UserIdOffer = 0, UserIdReceive = 1, InventoryIdOffer = 1, InventoryIdWant = 2 };
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(trace));
            Assert.IsType<ArgumentException>(ex);
            TraceRepositoryMoq.Verify(x => x.Create(It.IsAny<Trace>()), Times.Never);
        }

        public static IEnumerable<object[]> GetInvalidTraces()
        {
            return new List<object[]>
            {
                new object[] { new Trace { UserIdOffer = -1, UserIdReceive = 1, InventoryIdOffer = 1, InventoryIdWant = 1 } },
                new object[] { new Trace { UserIdOffer = 1, UserIdReceive = 0, InventoryIdOffer = 1, InventoryIdWant = 1 } },
                new object[] { new Trace { UserIdOffer = 1, UserIdReceive = 1, InventoryIdOffer = 0, InventoryIdWant = 1 } }
            };
        }
    }
}