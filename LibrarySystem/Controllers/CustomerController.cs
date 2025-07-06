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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<CustomerDto>>(items);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();

            var dto = _mapper.Map<CustomerDto>(item);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            entity.CustomerId = Guid.NewGuid(); // or let EF generate

            var result = await _repository.CreateAsync(entity);
            var resultDto = _mapper.Map<CustomerDto>(result);

            return CreatedAtAction(nameof(GetById), new { id = result.CustomerId }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto dto)
        {
            if (id != dto.CustomerId)
                return BadRequest("ID mismatch between URL and body.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _mapper.Map(dto, existing);

            var updated = await _repository.UpdateAsync(id, existing);
            var updatedDto = _mapper.Map<CustomerDto>(updated);

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
