using Moq;
using Xunit;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Tests
{
    public class SpellServiceTest
    {
        private readonly SpellService service;
        private readonly Mock<ISpellRepository> spellRepositoryMoq;

        public SpellServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            spellRepositoryMoq = new Mock<ISpellRepository>();

            repositoryWrapperMoq.Setup(x => x.Spell)
                .Returns(spellRepositoryMoq.Object);

            service = new SpellService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_NullSpell_ShouldThrowArgumentNullException()
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            // assert
            Assert.IsType<ArgumentNullException>(ex);
            spellRepositoryMoq.Verify(x => x.Create(It.IsAny<Spell>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_NewSpell_ShouldCreateNewSpell()
        {
            // arrange
            var newSpell = new Spell()
            {
                Name = "Fireball",
                Description = "A blazing fireball",
                CostCurrency = "Gold",
                Rarity = "Rare",
                CostAmount = 50,
                ImageUrl = "fireball.png",
                GameEffectCode = "DAMAGE:50",
                BaseDamage = 50
            };

            // act
            await service.Create(newSpell);

            // assert
            spellRepositoryMoq.Verify(x => x.Create(It.IsAny<Spell>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectSpells))]
        public async Task CreateAsync_IncorrectSpell_ShouldNotCreate(Spell spell)
        {
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(spell));

            // assert
            spellRepositoryMoq.Verify(x => x.Create(It.IsAny<Spell>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsync_SpellWithEmptyName_ShouldNotCreate()
        {
            // arrange
            var newSpell = new Spell()
            {
                Name = "",
                Description = "Test",
                CostCurrency = "Gold",
                CostAmount = 10
            };

            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newSpell));

            // assert
            spellRepositoryMoq.Verify(x => x.Create(It.IsAny<Spell>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        public static IEnumerable<object[]> GetIncorrectSpells()
        {
            return new List<object[]>
            {
                new object[] { new Spell { Name = "Fireball", CostCurrency = "Gold", CostAmount = null } }
            };
        }
    }
}