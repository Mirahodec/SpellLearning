using System.Text.Json;
using BackendApi.Contracts.Trace;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

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
            var response = result.Adapt < List<GetTraceResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _TraceService.GetById(id);
            var response =  result.Adapt<GetTraceResponse>();
            
            return Ok(response);
        }
        /// <summary>
        /// Создание данных 
        /// </summary>
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

