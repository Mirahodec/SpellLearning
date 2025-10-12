using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserDeckService : IUserDeckService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserDeckService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserDeck>> GetAll()
        {
            return await _repositoryWrapper.UserDeck.FindAll();
        }

        public async Task<UserDeck> GetById(int id)
        {
            var userDeck = await _repositoryWrapper.UserDeck
                .FindByCondition(x => x.DeckId == id);
            return userDeck.First();
        }

        public async Task Create(UserDeck model)
        {
            await _repositoryWrapper.UserDeck.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(UserDeck model)
        {
            await _repositoryWrapper.UserDeck.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userDeck = await _repositoryWrapper.UserDeck
                .FindByCondition(x => x.DeckId == id);

            await _repositoryWrapper.UserDeck.Delete(userDeck.First());
            await _repositoryWrapper.Save();
        }
    }
}