using TesteCI.Models;

namespace TesteCI.Repository.Interfaces
{
    public interface ISongRepository : IRepositoryBase<Song>
    {
        Song? GetById(int id);
    }
}
