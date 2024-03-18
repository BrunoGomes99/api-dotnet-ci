using TesteCI.Models;
using TesteCI.Repository.Interfaces;
using TesteCI.Service.Interfaces;

namespace TesteCI.Service
{
    public class SongService : ISongService
    {
        private readonly ILogger _logger;
        private readonly ISongRepository _songRepository;

        public SongService(ILogger<SongService> logger, ISongRepository songRepository)
        {
            _logger = logger;
            _songRepository = songRepository;
        }

        public List<Song> GetAll()
        {
            _logger.LogInformation("Method GetAll() was started.");

            var songs = _songRepository.GetAll();

            _logger.LogInformation("Method GetAll() was finished.");

            return songs.ToList();
        }

        public Song? GetById(int id)
        {
            _logger.LogInformation($"Method GetAll({id}) was started.");

            var song = _songRepository.GetById(id);

            _logger.LogInformation($"Method GetAll({id}) was finished.");

            return song;
        }
    }
}
