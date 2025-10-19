using BackendApi.Contracts.UserUpgrade;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUpgradeController : ControllerBase
    {
        private IUserUpgradeService _UserUpgradeService;
        public UserUpgradeController(IUserUpgradeService UserUpgradeService)
        {
            _UserUpgradeService = UserUpgradeService;
        }
        /// <summary>
        /// Получение данных 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _UserUpgradeService.GetAll();
            var response = result.Adapt<List<GetUserUpgradeResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _UserUpgradeService.GetById(id);
            var response = result.Adapt<GetUserUpgradeResponse>();

            return Ok(response);
        }
        /// <summary>
        /// Создание нового улучшения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /UserUpgrades
        ///     {
        ///       "name": "Базовый кликер",
        ///       "description": "Увеличивает доход за клик на 1",
        ///       "costClick": 50,
        ///       "powerMultiplier": 1.1
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Данные улучшения</param>
        /// <returns>Созданное улучшение</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserUpgradeRequest request)
        {
            var UserUpgradeDto = request.Adapt<UserUpgrade>();
            await _UserUpgradeService.Create(UserUpgradeDto);
            return Ok();
        }
        /// <summary>
        /// Изменить данные 
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(GetUserUpgradeResponse request)
        {
            var UserUpgradeDto = request.Adapt<UserUpgrade>();
            await _UserUpgradeService.Update(UserUpgradeDto);
            return Ok();
        }
        /// <summary>
        /// Удалить данные 
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _UserUpgradeService.Delete(id);
            return Ok();
        }
    }
}