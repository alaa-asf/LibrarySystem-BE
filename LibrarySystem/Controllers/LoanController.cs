using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LibrarySystem.Data.DTOs;
using Data.Models;
using Data.Repositories;

namespace Generator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;

        public LoanController(ILoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<LoanDto>>(items);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();

            var dto = _mapper.Map<LoanDto>(item);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLoanDto dto)
        {
            var entity = _mapper.Map<Loan>(dto);
            entity.LoanId = Guid.NewGuid(); // or let EF generate

            var result = await _repository.CreateAsync(entity);
            var resultDto = _mapper.Map<LoanDto>(result);

            return CreatedAtAction(nameof(GetById), new { id = result.LoanId }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLoanDto dto)
        {
            if (id != dto.LoanId)
                return BadRequest("ID mismatch between URL and body.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _mapper.Map(dto, existing);

            var updated = await _repository.UpdateAsync(id, existing);
            var updatedDto = _mapper.Map<LoanDto>(updated);

            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
