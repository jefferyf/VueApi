using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using VueApi.Entities;
using VueApi.Services;

namespace VueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly BooksDbContext _context;

        public class Payload
        {
            public int page { get; set; } = 1;
            public int per_page { get; set; } = 5;
        }

        public BooksController(BooksDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public ActionResult<string> GetBooks([FromBody] Payload payload)
        {
            // Basic pagination...
            int skip = (payload.page - 1) * payload.per_page;

            int total = _context.Books.Count();

            var books = _context.Books
                .OrderBy(b => b.Id)
                .Skip(skip)
                .Take(payload.per_page)
                .ToList();

            return Ok(new {total = total, books = books });
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook([FromRoute] int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}