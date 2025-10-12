using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using Xunit;

namespace BusinessLogic.Tests
{
    public class DeckSlotServiceTest
    {
        private readonly DeckSlotService service;
        private readonly Mock<IDeckSlotRepository> deckSlotRepositoryMoq;

        public DeckSlotServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            deckSlotRepositoryMoq = new Mock<IDeckSlotRepository>();
            repositoryWrapperMoq.Setup(x => x.DeckSlot).Returns(deckSlotRepositoryMoq.Object);
            service = new DeckSlotService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullDeckSlot_ShouldThrowArgumentNullException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            deckSlotRepositoryMoq.Verify(x => x.Create(It.IsAny<DeckSlot>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ValidDeckSlot_ShouldCreate()
        {
            var slot = new DeckSlot { DeckId = 1, InventoryId = 2, SlotNumber = 1 };
            await service.Create(slot);
            deckSlotRepositoryMoq.Verify(x => x.Create(It.IsAny<DeckSlot>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetInvalidDeckSlots))]
        public async Task CreateAsync_InvalidDeckSlot_ShouldNotCreate(DeckSlot slot)
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(slot));
            Assert.IsType<ArgumentException>(ex);
            deckSlotRepositoryMoq.Verify(x => x.Create(It.IsAny<DeckSlot>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_DeckSlotWithZeroDeckId_ShouldNotCreate()
        {
            var slot = new DeckSlot { DeckId = 0, InventoryId = 1, SlotNumber = 1 };
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(slot));
            Assert.IsType<ArgumentException>(ex);
            deckSlotRepositoryMoq.Verify(x => x.Create(It.IsAny<DeckSlot>()), Times.Never);
        }

        public static IEnumerable<object[]> GetInvalidDeckSlots()
        {
            return new List<object[]>
            {
                new object[] { new DeckSlot { DeckId = -1, InventoryId = 1, SlotNumber = 1 } },
                new object[] { new DeckSlot { DeckId = 1, InventoryId = 0, SlotNumber = 1 } },
                new object[] { new DeckSlot { DeckId = 1, InventoryId = 1, SlotNumber = 0 } },
                new object[] { new DeckSlot { DeckId = 1, InventoryId = 1, SlotNumber = -5 } }
            };
        }
    }
}