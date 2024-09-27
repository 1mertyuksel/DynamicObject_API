using AutoMapper;
using BusinessLayer_BL_.Concrete;
using BusinessLayer_BL_.DTOs;
using DataAccesLayer_DAL_.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DynamicObject_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DynamicObjectController : ControllerBase
    {
        private readonly DynamicObjectService<DynamicObject> _dynamicObjectRepository;
        private readonly IMapper _mapper;

        public DynamicObjectController(DynamicObjectService<DynamicObject> dynamicObjectRepository, IMapper mapper)
        {
            _dynamicObjectRepository = dynamicObjectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dynamicObjects = await _dynamicObjectRepository.GetAllAsync();
            var dynamicObjectDTOs = _mapper.Map<IEnumerable<DynamicObjectDTO>>(dynamicObjects);
            return Ok(dynamicObjectDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dynamicObject = await _dynamicObjectRepository.GetByIdAsync(id);
            if (dynamicObject == null)
            {
                return NotFound();
            }
            var dynamicObjectDTO = _mapper.Map<DynamicObjectDTO>(dynamicObject);
            return Ok(dynamicObjectDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDynamicObject(DynamicObjectDTO dynamicObjectDTO)
        {
            var dynamicObject = _mapper.Map<DynamicObject>(dynamicObjectDTO);
            await _dynamicObjectRepository.AddAsync(dynamicObject);
            return CreatedAtAction(nameof(GetById), new { id = dynamicObject.Id }, dynamicObjectDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDynamicObject(int id, DynamicObjectDTO dynamicObjectDTO)
        {
            var existingDynamicObject = await _dynamicObjectRepository.GetByIdAsync(id);
            if (existingDynamicObject == null)
            {
                return NotFound();
            }

            _mapper.Map(dynamicObjectDTO, existingDynamicObject);  
            await _dynamicObjectRepository.UpdateAsync(existingDynamicObject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDynamicObject(int id)
        {
            var dynamicObject = await _dynamicObjectRepository.GetByIdAsync(id);
            if (dynamicObject == null)
            {
                return NotFound();
            }

            await _dynamicObjectRepository.DeleteAsync(dynamicObject);
            return NoContent();
        }
    }
}
