using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IUserUpgradeRepository UserUpgrade { get; }
        IUserClickerUpgradeRepository UserClickerUpgrade { get; }
        IUserDeckRepository UserDeck { get; }
        IUserInventoryRepository UserInventory { get; }
        IDeckSlotRepository DeckSlot { get; }
        IGachaPullRepository GachaPull { get; }
        IGameSafeRepository GameSafe { get; }
        ISpellRepository Spell { get; }
        ITraceRepository Trace { get; }

        Task Save();
    }
}