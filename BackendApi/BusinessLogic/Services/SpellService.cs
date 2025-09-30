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
            await _repositoryWrapper.Save();
        }

        public async Task Update(Spell model)
        {
            await _repositoryWrapper.Spell.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var spell = await _repositoryWrapper.Spell
                .FindByCondition(x => x.SpellId == id);

            await _repositoryWrapper.Spell.Delete(spell.First());
            await _repositoryWrapper.Save();
        }
    }
}

