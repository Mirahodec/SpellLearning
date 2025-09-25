using Domain.Models;
using Domain.Interfaces;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SpellLearningContext _repoContext;

        private IUserRepository _user;
        private IUserUpgradeRepository _userUpgrade;
        private IUserClickerUpgradeRepository _userClickerUpgrade;
        private IUserDeckRepository _userDeck;
        private IUserInventoryRepository _userInventory;
        private IDeckSlotRepository _deckSlot;
        private IGachaPullRepository _gachaPull;
        private IGameSafeRepository _gameSafe;
        private ISpellRepository _spell;
        private ITraceRepository _trace;

        public IUserRepository User
        {
            get 
            {
                if (_user == null) {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public IUserUpgradeRepository UserUpgrade
        {
            get
            {
                if (_userUpgrade == null)
                {
                    _userUpgrade = new UserUpgradeRepository(_repoContext);
                }
                return _userUpgrade;
            }
        }
        public IUserClickerUpgradeRepository UserClickerUpgrade
        {
            get
            {
                if (_userClickerUpgrade == null)
                {
                    _userClickerUpgrade = new UserClickerUpgradeRepository(_repoContext);
                }
                return _userClickerUpgrade;
            }
        }
        public IUserDeckRepository UserDeck
        {
            get
            {
                if (_userDeck == null)
                {
                    _userDeck = new UserDeckRepository(_repoContext);
                }
                return _userDeck;
            }
        }
        public IUserInventoryRepository UserInventory
        {
            get
            {
                if (_userInventory == null)
                {
                    _userInventory = new UserInventoryRepository(_repoContext);
                }
                return _userInventory;
            }
        }
        public IDeckSlotRepository DeckSlot
        {
            get
            {
                if (_deckSlot == null)
                {
                    _deckSlot = new DeckSlotRepository(_repoContext);
                }
                return _deckSlot;
            }
        }
        public IGachaPullRepository GachaPull
        {
            get
            {
                if (_gachaPull == null)
                {
                    _gachaPull = new GachaPullRepository(_repoContext);
                }
                return _gachaPull;
            }
        }
        public IGameSafeRepository GameSafe
        {
            get
            {
                if (_gameSafe == null)
                {
                    _gameSafe = new GameSafeRepository(_repoContext);
                }
                return _gameSafe;
            }
        }
        public ISpellRepository Spell
        {
            get
            {
                if (_spell == null)
                {
                    _spell = new SpellRepository(_repoContext);
                }
                return _spell;
            }
        }
        public ITraceRepository Trace
        {
            get
            {
                if (_trace == null)
                {
                    _trace = new TraceRepository(_repoContext);
                }
                return _trace;
            }
        }
        public RepositoryWrapper(SpellLearningContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
