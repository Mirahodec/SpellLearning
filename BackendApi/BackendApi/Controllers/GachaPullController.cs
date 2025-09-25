using System.Text.Json;
using BackendApi.Contracts.GachaPull;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GachaPullController : ControllerBase
    {
        private IGachaPullService _GachaPullService;
        public GachaPullController(IGachaPullService GachaPullService)
        {
            _GachaPullService = GachaPullService;
        }
        /// <summary>
        /// Получение данных 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _GachaPullService.GetAll();
            var response = result.Adapt < List<GetGachaPullResponse>>();

            return Ok(response);
        }
        /// <summary>
        /// Получение данных по ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _GachaPullService.GetById(id);
            var response =  result.Adapt<GetGachaPullResponse>();
            
            return Ok(response);
        }
        /// <summary>
        /// Создание данных 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(CreateGachaPullRequest request)
        {
            var GachaPullDto = request.Adapt<GachaPull>();
            await _GachaPullService.Create(GachaPullDto);
            return Ok();
        }
        /// <summary>
        /// Изменить данные 
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(GetGachaPullResponse request)
        {
            var GachaPullDto = request.Adapt<GachaPull>();
            await _GachaPullService.Update(GachaPullDto);
            return Ok();
        }
        /// <summary>
        /// Удалить данные
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _GachaPullService.Delete(id);
            return Ok();
        }
    }
}

