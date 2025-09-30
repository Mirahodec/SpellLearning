using System.Text.Json;
using BackendApi.Contracts.UserDeck;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDeckController : ControllerBase
    {
        private IUserDeckService _UserDeckService;
        public UserDeckController(IUserDeckService UserDeckService)
        {
            _UserDeckService = UserDeckService;
        }
        /// <summary>
        /// Получение данных 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _UserDeckService.GetAll();
            var response = result.Adapt < List<GetUserDeckResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _UserDeckService.GetById(id);
            var response =  result.Adapt<GetUserDeckResponse>();
            
            return Ok(response);
        }
        /// <summary>
        /// Создание новой колоды
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /UserDecks
        ///     {
        ///       "userId": 1,
        ///       "deckName": "Основная боевая"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Данные колоды</param>
        /// <returns>Созданная колода</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserDeckRequest request)
        {
            var UserDeckDto = request.Adapt<UserDeck>();
            await _UserDeckService.Create(UserDeckDto);
            return Ok();
        }
        /// <summary>
        /// Изменить данные 
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(GetUserDeckResponse request)
        {
            var UserDeckDto = request.Adapt<UserDeck>();
            await _UserDeckService.Update(UserDeckDto);
            return Ok();
        }
        /// <summary>
        /// Удалить данные 
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _UserDeckService.Delete(id);
            return Ok();
        }
    }
}

