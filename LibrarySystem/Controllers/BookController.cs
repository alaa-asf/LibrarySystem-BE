using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using LibrarySystem.Data.DTOs;
using Data.Models;
using Data.Repositories;
using LibrarySystem.Data.Dtos.Book;

namespace LibrarySystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _repository.GetAllAsync();
            var booksDto = _mapper.Map<List<BookDto>>(books);
            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return NotFound();

            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            book.Id = Guid.NewGuid();
            book.Created = DateTimeOffset.UtcNow;

            var createdBook = await _repository.CreateAsync(book);
            var createdBookDto = _mapper.Map<BookDto>(createdBook);

            return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBookDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto dto)
        {
            if (id != dto.BookId)
                return BadRequest("ID mismatch between URL and body.");

            var existingBook = await _repository.GetByIdAsync(id);
            if (existingBook == null)
                return NotFound();

            _mapper.Map(dto, existingBook);

            var updatedBook = await _repository.UpdateAsync(id, existingBook);
            var updatedBookDto = _mapper.Map<BookDto>(updatedBook);

            return Ok(updatedBookDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
