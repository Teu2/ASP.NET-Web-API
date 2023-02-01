using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private static List<Web_API.Models.Mangas> Mangas_Manhwas = new ()
        {
            new Web_API.Models.Mangas
            {
                Id = 10,
                Author = "Akira Toriyama",
                Rating = "5/5",
                Status = "Ongoing",
                Title = "Dragon Ball Super"
            },

            new Web_API.Models.Mangas
            {
                Id = 12,
                Author = "Takahashi Yoshiyuki - Kuro Ouji",
                Rating = "5/5",
                Status = "Ongoing",
                Title = "I Was Dismissed From The Hero’S Party Because They Don’T Need My Training Skills, So I Strengthened My [Fief] Which I Got As A Replacement For My Retirement Money."
            }
        };

        private readonly DataContext _context;
        public MangaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // get method to retrieve data
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> GetBook()
        {
            return Ok(await _context.MangasManhwas.ToListAsync());
        }

        [HttpGet("{bookId}")] // get method to get data by ID
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> GetBookById(int bookId)
        {
            var book = await _context.MangasManhwas.FindAsync(bookId);
            if (book == null) return BadRequest("Book not found.");

            return Ok(book);
        }

        [HttpPost] // post method to send data
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> AddBook(Web_API.Models.Mangas book)
        {
            _context.MangasManhwas.Add(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.MangasManhwas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> UpdateBook(Web_API.Models.Mangas bookRequest)
        {
            var dbBook = await _context.MangasManhwas.FindAsync(bookRequest.Id);
            if (dbBook == null) return BadRequest("Book not found.");

            dbBook.Title = bookRequest.Title;
            dbBook.Author = bookRequest.Author;
            dbBook.Status = bookRequest.Status;
            dbBook.Rating = bookRequest.Rating;

            await _context.SaveChangesAsync();

            return Ok(await _context.MangasManhwas.ToListAsync());
        }

        [HttpDelete("{bookId}")]
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> DeleteBook(int bookId)
        {
            var dbBook = await _context.MangasManhwas.FindAsync(bookId);
            if (dbBook == null) return BadRequest("Book not found.");


            _context.MangasManhwas.Remove(dbBook);
            await _context.SaveChangesAsync();

            return Ok(await _context.MangasManhwas.ToListAsync());
        }
    }
}
