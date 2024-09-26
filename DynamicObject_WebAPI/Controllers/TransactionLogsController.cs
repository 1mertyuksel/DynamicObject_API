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
    public class TransactionLogsController : ControllerBase
    {
        private readonly IRepository<TransactionLog> _repository;
        private readonly IMapper _mapper;

        public TransactionLogsController(IRepository<TransactionLog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/transactionlog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionLogDTO>>> GetAll()
        {
            var logs = await _repository.GetAllAsync();
            var logDTOs = _mapper.Map<IEnumerable<TransactionLogDTO>>(logs);
            return Ok(logDTOs);
        }

        // GET: api/transactionlog/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionLogDTO>> GetById(int id)
        {
            var log = await _repository.GetByIdAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            var logDTO = _mapper.Map<TransactionLogDTO>(log);
            return Ok(logDTO);
        }

        // POST: api/transactionlog
        [HttpPost]
        public async Task<ActionResult<TransactionLogDTO>> Create([FromBody] TransactionLogDTO transactionLogDTO)
        {
            if (transactionLogDTO == null)
            {
                return BadRequest("TransactionLogDTO cannot be null.");
            }

            var transactionLog = _mapper.Map<TransactionLog>(transactionLogDTO);
            await _repository.AddAsync(transactionLog);
            return CreatedAtAction(nameof(GetById), new { id = transactionLog.Id }, transactionLogDTO);
        }

        // PUT: api/transactionlog/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TransactionLogDTO transactionLogDTO)
        {
            if (id != transactionLogDTO.DynamicObjectId)
            {
                return BadRequest("ID mismatch.");
            }

            var transactionLog = await _repository.GetByIdAsync(id);
            if (transactionLog == null)
            {
                return NotFound();
            }

            _mapper.Map(transactionLogDTO, transactionLog);
            await _repository.UpdateAsync(transactionLog);
            return NoContent();
        }

        // DELETE: api/transactionlog/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionLog = await _repository.GetByIdAsync(id);
            if (transactionLog == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(transactionLog);
            return NoContent();
        }
    }
}
