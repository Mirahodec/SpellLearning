using System.Text.Json;
using BackendApi.Contracts.UserClickerUpgrade;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClickerUpgradeController : ControllerBase
    {
        private IUserClickerUpgradeService _UserClickerUpgradeService;
        public UserClickerUpgradeController(IUserClickerUpgradeService UserClickerUpgradeService)
        {
            _UserClickerUpgradeService = UserClickerUpgradeService;
        }
        /// <summary>
        /// Получение данных 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _UserClickerUpgradeService.GetAll();
            var response = result.Adapt < List<GetUserClickerUpgradeResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _UserClickerUpgradeService.GetById(id);
            var response =  result.Adapt<GetUserClickerUpgradeResponse>();
            
            return Ok(response);
        }
        /// <summary>
        /// Создание данных 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserClickerUpgradeRequest request)
        {
            var UserClickerUpgradeDto = request.Adapt<UserClickerUpgrade>();
            await _UserClickerUpgradeService.Create(UserClickerUpgradeDto);
            return Ok();
        }
        /// <summary>
        /// Изменить данные 
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(GetUserClickerUpgradeResponse request)
        {
            var UserClickerUpgradeDto = request.Adapt<UserClickerUpgrade>();
            await _UserClickerUpgradeService.Update(UserClickerUpgradeDto);
            return Ok();
        }
        /// <summary>
        /// Удалить данные 
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _UserClickerUpgradeService.Delete(id);
            return Ok();
        }
    }
}

