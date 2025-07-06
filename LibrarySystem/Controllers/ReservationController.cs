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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public ReservationController(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<ReservationDto>>(items);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();

            var dto = _mapper.Map<ReservationDto>(item);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationDto dto)
        {
            var entity = _mapper.Map<Reservation>(dto);
            entity.ReservationId = Guid.NewGuid(); // or let EF generate

            var result = await _repository.CreateAsync(entity);
            var resultDto = _mapper.Map<ReservationDto>(result);

            return CreatedAtAction(nameof(GetById), new { id = result.ReservationId }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReservationDto dto)
        {
            if (id != dto.ReservationId)
                return BadRequest("ID mismatch between URL and body.");

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _mapper.Map(dto, existing);

            var updated = await _repository.UpdateAsync(id, existing);
            var updatedDto = _mapper.Map<ReservationDto>(updated);

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
