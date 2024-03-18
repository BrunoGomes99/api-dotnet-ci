using Microsoft.EntityFrameworkCore;
using TesteCI.Models;

namespace TesteCI.Repository.Context
{
    public class RadioDbContext : DbContext
    {
        public RadioDbContext(DbContextOptions<RadioDbContext> options) : base(options)
        {
        }

        // Setting the in-memory database and naming it
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "RadioDb");
        }
        public DbSet<Song> Songs => Set<Song>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Song>()
                .HasData(
                new Song { Id = 1, Title = "Nutshell", Artists = "Alice In Chains", Album = "Jar of Flies" },
                new Song { Id = 2, Title = "Interstate Love Song", Artists = "Stone Temple Pilots", Album = "Purple" },
                new Song { Id = 3, Title = "Far Behind", Artists = "Candlebox", Album = "Candlebox" },
                new Song { Id = 4, Title = "About a Girl", Artists = "Nirvana", Album = "Bleach" }
                );
        }
    }
}
