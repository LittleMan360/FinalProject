using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteBooksController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public FavoriteBooksController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteBook>>> GetFavoriteBooks()
        {
            return await _context.FavoriteBooks.ToListAsync();
        }

        // GET: api/FavoriteBooks/5
        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<FavoriteBook>>> GetFavoriteBooks(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.FavoriteBooks.Take(5).ToListAsync();
            }

            var favoriteBook = await _context.FavoriteBooks.FindAsync(id);

            if (favoriteBook == null)
            {
                return NotFound();
            }

            return new List<FavoriteBook> { favoriteBook };
        }

        // PUT: api/FavoriteBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteBook(int id, FavoriteBook favoriteBook)
        {
            if (id != favoriteBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteBookExists(id))
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

        // POST: api/FavoriteBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteBook>> PostFavoriteBook(FavoriteBook favoriteBook)
        {
            // Ensure the ID is not set to avoid conflicts with the identity column
            favoriteBook.Id = 0;

            _context.FavoriteBooks.Add(favoriteBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavoriteBooks), new { id = favoriteBook.Id }, favoriteBook);
        }

        // DELETE: api/FavoriteBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteBook(int id)
        {
            var favoriteBook = await _context.FavoriteBooks.FindAsync(id);
            if (favoriteBook == null)
            {
                return NotFound();
            }

            _context.FavoriteBooks.Remove(favoriteBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteBookExists(int id)
        {
            return _context.FavoriteBooks.Any(e => e.Id == id);
        }
    }
}
