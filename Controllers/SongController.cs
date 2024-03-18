using Microsoft.AspNetCore.Mvc;
using TesteCI.Models;
using TesteCI.Service.Interfaces;

namespace TesteCI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ILogger<SongController> _logger;
        private readonly ISongService _songService;
        public SongController(ILogger<SongController> logger, ISongService songService)
        {
            _logger = logger;
            _songService = songService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Method Get() was started.");

            List<Song> songs = new List<Song>();

            try
            {
                songs = _songService.GetAll();
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem("An unexpected error has occurred. Please, try again.");
            }

            _logger.LogInformation("Method Get() was finished.");

            return Ok(songs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"Method Get({id}) was started.");

            Song? song = new Song();

            try
            {
                song = _songService.GetById(id);

                if (song == null)
                {
                    return NotFound("The song was not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem("An unexpected error has occurred. Please, try again.");
            }

            _logger.LogInformation($"Method Get({id}) was finished.");

            return Ok(song);
        }
    }
}
