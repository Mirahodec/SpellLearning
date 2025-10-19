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
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Name is required.", nameof(model.Name));

            if (string.IsNullOrWhiteSpace(model.CostCurrency))
                throw new ArgumentException("CostCurrency is required.", nameof(model.CostCurrency));

            if (model.CostAmount is null or <= 0)
                throw new ArgumentException("CostAmount must be greater than 0.", nameof(model.CostAmount));

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