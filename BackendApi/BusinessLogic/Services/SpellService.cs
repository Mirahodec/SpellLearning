using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class SpellService : ISpellService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SpellService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Spell>> GetAll()
        {
            return await _repositoryWrapper.Spell.FindAll();
        }

        public async Task<Spell> GetById(int id)
        {
            var spell = await _repositoryWrapper.Spell
                .FindByCondition(x => x.SpellId == id);
            return spell.First();
        }

        public async Task Create(Spell model)
        {
            await _repositoryWrapper.Spell.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Spell model)
        {
            _repositoryWrapper.Spell.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var spell = await _repositoryWrapper.Spell
                .FindByCondition(x => x.SpellId == id);

            _repositoryWrapper.Spell.Delete(spell.First());
            _repositoryWrapper.Save();
        }
    }
}

