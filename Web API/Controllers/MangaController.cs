using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet] // get method to retrieve data
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> GetBook()
        {
            return Ok(Mangas_Manhwas);
        }

        [HttpGet("{bookId}")] // get method to get data by ID
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> GetBookById(int bookId)
        {
            var book = Mangas_Manhwas.Find(book => book.Id == bookId);
            if (book == null) return BadRequest("Book not found.");

            return Ok(book);
        }

        [HttpPost] // post method to send data
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> AddBook(Web_API.Models.Mangas book)
        {
            Mangas_Manhwas.Add(book);
            return Ok(Mangas_Manhwas);
        }

        [HttpPut]
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> UpdateBook(Web_API.Models.Mangas bookRequest)
        {
            var book = Mangas_Manhwas.Find(book => book.Id == bookRequest.Id);
            if(book == null) return BadRequest("Book not found.");

            book.Title = bookRequest.Title;
            book.Author = bookRequest.Author;
            book.Status = bookRequest.Status;
            book.Rating = bookRequest.Rating;

            return Ok(Mangas_Manhwas);
        }

        [HttpDelete("{bookId}")]
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> DeleteBook(int bookId)
        {
            var book = Mangas_Manhwas.Find(book => book.Id == bookId);
            if (book == null) return BadRequest("Book not found.");

            Mangas_Manhwas.Remove(book);

            return Ok(Mangas_Manhwas);
        }
    }
}
