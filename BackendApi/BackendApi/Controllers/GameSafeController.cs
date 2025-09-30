using System.Text.Json;
using BackendApi.Contracts.GameSafe;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameSafeController : ControllerBase
    {
        private IGameSafeService _GameSafeService;
        public GameSafeController(IGameSafeService GameSafeService)
        {
            _GameSafeService = GameSafeService;
        }
        /// <summary>
        /// Получение данных 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _GameSafeService.GetAll();
            var response = result.Adapt < List<GetGameSafeResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _GameSafeService.GetById(id);
            var response =  result.Adapt<GetGameSafeResponse>();
            
            return Ok(response);
        }
        /// <summary>
        /// Создание/обновление игрового сохранения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /GameSaves
        ///     {
        ///       "userId": 1,
        ///       "level": 25,
        ///       "highScore": 125000,
        ///       "equippedDeckId": 1,
        ///       "saveData": {
        ///         "прогресс": 78,
        ///         "открытые_уровни": [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],
        ///         "завершенные_квесты": [1,2,3,4,5]
        ///       },
        ///       "lastUpdated": "2024-03-20T18:45:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Данные сохранения</param>
        /// <returns>Созданное сохранение</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateGameSafeRequest request)
        {
            var GameSafeDto = request.Adapt<GameSafe>();
            await _GameSafeService.Create(GameSafeDto);
            return Ok();
        }
        /// <summary>
        /// Изменить данные 
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(GetGameSafeResponse request)
        {
            var GameSafeDto = request.Adapt<GameSafe>();
            await _GameSafeService.Update(GameSafeDto);
            return Ok();
        }
        /// <summary>
        /// Удалить данные 
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _GameSafeService.Delete(id);
            return Ok();
        }
    }
}

