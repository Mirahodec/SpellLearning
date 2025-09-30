using System.Text.Json;
using BackendApi.Contracts.UserInventory;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInventoryController : ControllerBase
    {
        private IUserInventoryService _UserInventoryService;
        public UserInventoryController(IUserInventoryService UserInventoryService)
        {
            _UserInventoryService = UserInventoryService;
        }
        /// <summary>
        /// Получение данных 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _UserInventoryService.GetAll();
            var response = result.Adapt < List<GetUserInventoryResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _UserInventoryService.GetById(id);
            var response =  result.Adapt<GetUserInventoryResponse>();
            
            return Ok(response);
        }
        /// <summary>
        /// Добавление заклинания в инвентарь пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /UserInventory
        ///     {
        ///       "userId": 1,
        ///       "spellId": 3,
        ///       "obtainedAt": "2024-01-20T09:15:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Данные инвентаря</param>
        /// <returns>Запись в инвентаре</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserInventoryRequest request)
        {
            var UserInventoryDto = request.Adapt<UserInventory>();
            await _UserInventoryService.Create(UserInventoryDto);
            return Ok();
        }
        /// <summary>
        /// Изменить данные пользователя
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(GetUserInventoryResponse request)
        {
            var UserInventoryDto = request.Adapt<UserInventory>();
            await _UserInventoryService.Update(UserInventoryDto);
            return Ok();
        }
        /// <summary>
        /// Удалить данные пользователя
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _UserInventoryService.Delete(id);
            return Ok();
        }
    }
}

