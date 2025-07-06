using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data.Dtos.Category;
using LibrarySystem.Data.DTOs;
using Data.Repositories;
using Data.Models;
using System.ComponentModel.DataAnnotations;
using Data;

namespace Generator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public CategoryController(ICategoryRepository repository, IMapper mapper, ApplicationDbContext context)
    {
        _repository = repository;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet("{id}", Name = "GetCategoryById")]
    public async Task<ActionResult<CategoryDto>> GetAsync([FromRoute] Guid id)
    {
        var query = _repository.Query()
            .Include(c => c.SubCategories)
            .Include(c => c.Books)
            .Where(c => c.Id == id);

        var category = await query.FirstOrDefaultAsync();

        if (category == null)
            return NotFound();

        var dto = _mapper.Map<CategoryDto>(category);
        return Ok(dto);
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllAsync()
    {
        var categories = await _repository.Query()
            .Where(c => c.ParentCategoryId == null)
            .Include(c => c.SubCategories)
            .Include(c => c.Books)
            .ToListAsync();

        var dtoList = _mapper.Map<List<CategoryDto>>(categories);
        return Ok(dtoList);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
    {
        var entity = _mapper.Map<Category>(dto);
        entity.Id = Guid.NewGuid();
        entity.Created = DateTimeOffset.UtcNow;

        await _repository.AddAsync(entity);
        return CreatedAtRoute("GetCategoryById", new { id = entity.Id }, _mapper.Map<CategoryDto>(entity));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryDto dto)
    {
        if (id != dto.CategoryId)
            return BadRequest("ID mismatch between URL and body.");

        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        _mapper.Map(dto, existing);
        await _repository.UpdateAsync(id, existing);

        return Ok(_mapper.Map<CategoryDto>(existing));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
