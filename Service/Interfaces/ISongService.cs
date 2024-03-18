using TesteCI.Models;

namespace TesteCI.Service.Interfaces
{
    public interface ISongService
    {
        List<Song> GetAll();
        Song? GetById(int id);
    }
}
