using BackendApi.Contracts.TraceRequest;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraceController : ControllerBase
    {
        private ITraceService _TraceService;
        public TraceController(ITraceService TraceService)
        {
            _TraceService = TraceService;
        }
        /// <summary>
        /// Получение данных 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _TraceService.GetAll();
            var response = result.Adapt<List<GetTraceResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _TraceService.GetById(id);
            var response = result.Adapt<GetTraceResponse>();

            return Ok(response);
        }
        /// <summary>
        /// Создание предложения обмена
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Traces
        ///     {
        ///       "userIdOffer": 1,
        ///       "userIdReceive": 2,
        ///       "inventoryIdOffer": 5,
        ///       "inventoryIdWant": 11,
        ///       "status": "ожидание",
        ///       "createdAt": "2024-02-05T14:30:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Данные обмена</param>
        /// <returns>Созданный обмен</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTraceRequest request)
        {
            var TraceDto = request.Adapt<Trace>();
            await _TraceService.Create(TraceDto);
            return Ok();
        }
        /// <summary>
        /// Изменить данные 
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(GetTraceResponse request)
        {
            var TraceDto = request.Adapt<Trace>();
            await _TraceService.Update(TraceDto);
            return Ok();
        }
        /// <summary>
        /// Удалить данные 
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _TraceService.Delete(id);
            return Ok();
        }
    }
}