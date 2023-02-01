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
            }
        };

        [HttpGet] // get method to retrieve data
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> GetMangas_Manhwas()
        {
            return Ok(Mangas_Manhwas);
        }

        [HttpPost] // post method to send data
        public async Task<ActionResult<List<Web_API.Models.Mangas>>> AddMangas_Manhwas(Web_API.Models.Mangas book)
        {
            return Ok(Mangas_Manhwas);
        }
    }
}
