using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pract.API.Models;
using Pract.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pract.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;

        }

        [HttpGet]

        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _bookService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if(book == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(book);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Books book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _bookService.CreateAsync(book);
            return Ok(book.id);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, Books booksData)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.UpdateAsync(id, booksData);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.DeleteAsync(book.id);
            return NoContent();
        }
    }
}
