using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data.Repositories;
using LibrarySystem.Data.DTOs;
using LibrarySystem.Data.Dtos.Author;  // Assuming DTOs namespace

namespace Generator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _repository.GetAllAsync();
        var dtos = _mapper.Map<List<AuthorDto>>(entities);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound();

        var dto = _mapper.Map<AuthorDto>(entity);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuthorDto dto)
    {
        var entity = _mapper.Map<Author>(dto);
        var result = await _repository.CreateAsync(entity);

        var resultDto = _mapper.Map<AuthorDto>(result);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, resultDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorDto dto)
    {
        if (id != dto.AuthorId)
            return BadRequest("ID mismatch between URL and body.");

        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        _mapper.Map(dto, existing); // Map update DTO onto existing entity

        var updated = await _repository.UpdateAsync(id, existing);
        var updatedDto = _mapper.Map<AuthorDto>(updated);

        return Ok(updatedDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
