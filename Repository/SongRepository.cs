using TesteCI.Models;
using TesteCI.Repository.Context;
using TesteCI.Repository.Interfaces;

namespace TesteCI.Repository
{
    public class SongRepository : RepositoryBase<Song>, ISongRepository
    {
        public SongRepository(RadioDbContext dbContext) : base (dbContext) { }

        public Song? GetById(int id)
        {
            return DbSet.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
