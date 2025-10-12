using BackendApi.Contracts.DeckSlot;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckSlotController : ControllerBase
    {
        private IDeckSlotService _DeckSlotService;
        public DeckSlotController(IDeckSlotService DeckSlotService)
        {
            _DeckSlotService = DeckSlotService;
        }
        /// <summary>
        /// Получение данных 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _DeckSlotService.GetAll();
            var response = result.Adapt<List<GetDeckSlotResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _DeckSlotService.GetById(id);
            var response = result.Adapt<GetDeckSlotResponse>();

            return Ok(response);
        }
        /// <summary>
        /// Добавление заклинания в слот колоды
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /DeckSlots
        ///     {
        ///       "deckId": 1,
        ///       "inventoryId": 3,
        ///       "slotNumber": 2
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Данные слота колоды</param>
        /// <returns>Созданный слот</returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateDeckSlotRequest request)
        {
            var DeckSlotDto = request.Adapt<DeckSlot>();
            await _DeckSlotService.Create(DeckSlotDto);
            return Ok();
        }
        /// <summary>
        /// Изменить данные
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(GetDeckSlotResponse request)
        {
            var DeckSlotDto = request.Adapt<DeckSlot>();
            await _DeckSlotService.Update(DeckSlotDto);
            return Ok();
        }
        /// <summary>
        /// Удалить данные
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _DeckSlotService.Delete(id);
            return Ok();
        }
    }
}