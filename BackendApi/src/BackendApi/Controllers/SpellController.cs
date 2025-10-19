using BackendApi.Contracts.SpellRequest;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellController : ControllerBase
    {
        private ISpellService _SpellService;
        public SpellController(ISpellService SpellService)
        {
            _SpellService = SpellService;
        }
        /// <summary>
        /// Получение данных 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _SpellService.GetAll();
            var response = result.Adapt<List<GetSpellResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _SpellService.GetById(id);
            var response = result.Adapt<GetSpellResponse>();

            return Ok(response);
        }
        /// <summary>
        /// Создание нового заклинания
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Spells
        ///     {
        ///       "name": "Огненный шар",
        ///       "description": "Базовое огненное заклинание, наносит умеренный урон",
        ///       "costCurrency": "game",
        ///       "rarity": "обычная",
        ///       "costAmount": 5,
        ///       "baseDamage": 15,
        ///       "gameEffectCode": "damage_fire_single"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Данные заклинания</param>
        /// <returns>Созданное заклинание</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateSpellRequest request)
        {
            var SpellDto = request.Adapt<Spell>();
            await _SpellService.Create(SpellDto);
            return Ok();
        }
        /// <summary>
        /// Изменить данные 
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(GetSpellResponse request)
        {
            var SpellDto = request.Adapt<Spell>();
            await _SpellService.Update(SpellDto);
            return Ok();
        }
        /// <summary>
        /// Удалить данные 
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _SpellService.Delete(id);
            return Ok();
        }
    }
}