using BackendAPIRest.Application.DTOs;
using BackendAPIRest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendAPIRest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var properties = await _propertyService.GetAllAsync();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var property = await _propertyService.GetByIdAsync(id);
            if (property == null) return NotFound();
            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyDto propertyDto)
        {
            await _propertyService.CreateAsync(propertyDto);
            return CreatedAtAction(nameof(GetAll), new { }, propertyDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] PropertyDto propertyDto)
        {
            await _propertyService.UpdateAsync(id, propertyDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _propertyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
