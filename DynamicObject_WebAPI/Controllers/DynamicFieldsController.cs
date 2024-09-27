using AutoMapper;
using BusinessLayer_BL_.DTOs;
using DataAccesLayer_DAL_.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicObject_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DynamicFieldsController : ControllerBase
    {
        private readonly IRepository<DynamicField> _repository;
        private readonly IMapper _mapper;

        public DynamicFieldsController(IRepository<DynamicField> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DynamicFieldDTO>>> GetAll()
        {
            var fields = await _repository.GetAllAsync();
            var fieldDTOs = _mapper.Map<IEnumerable<DynamicFieldDTO>>(fields);
            return Ok(fieldDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DynamicFieldDTO>> GetById(int id)
        {
            var field = await _repository.GetByIdAsync(id);
            if (field == null)
            {
                return NotFound();
            }
            var fieldDTO = _mapper.Map<DynamicFieldDTO>(field);
            return Ok(fieldDTO);
        }

        [HttpPost]
        public async Task<ActionResult<DynamicFieldDTO>> CreateDynamicField([FromBody] DynamicFieldDTO dynamicFieldDTO)
        {
            if (dynamicFieldDTO == null)
            {
                return BadRequest("DynamicFieldDTO cannot be null.");
            }

            var dynamicField = _mapper.Map<DynamicField>(dynamicFieldDTO);
            await _repository.AddAsync(dynamicField);
            return CreatedAtAction(nameof(GetById), new { id = dynamicField.Id }, dynamicFieldDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDynamicField(int id, [FromBody] DynamicFieldDTO dynamicFieldDTO)
        {
            if (id != dynamicFieldDTO.DynamicObjectId)
            {
                return BadRequest("ID mismatch.");
            }

            var dynamicField = await _repository.GetByIdAsync(id);
            if (dynamicField == null)
            {
                return NotFound();
            }

            _mapper.Map(dynamicFieldDTO, dynamicField);
            await _repository.UpdateAsync(dynamicField);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDynamicField(int id)
        {
            var dynamicField = await _repository.GetByIdAsync(id);
            if (dynamicField == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(dynamicField);
            return NoContent();
        }
    }
}
