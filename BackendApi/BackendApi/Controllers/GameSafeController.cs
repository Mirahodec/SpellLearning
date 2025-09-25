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
        /// Создание данных 
        /// </summary>
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

