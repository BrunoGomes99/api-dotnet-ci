using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;
using TesteCI.Models;
using TesteCI.Repository.Context;
using TesteCI.Repository.Interfaces;
using TesteCI.Service;
using TesteCI.Service.Interfaces;
using Xunit;

namespace TesteCI.Tests.Service
{
    public class SongServiceTests
    {
        private readonly Mock<ISongRepository> _songRepositoryMock;
        private readonly Mock<ILogger<SongService>> _loggerMock;
        private readonly List<Song> _songList;
        private readonly ISongService _songService;
        public SongServiceTests()
        {
            // Arrange
            _songRepositoryMock = new Mock<ISongRepository>();
            _loggerMock = new Mock<ILogger<SongService>>();
            _songService = new SongService(_loggerMock.Object, _songRepositoryMock.Object);

            // Mocking song collection
            _songList = new List<Song>()
            {
                new Song { Id = 1, Title = "Fade Into You", Artists = "Mazzy Star", Album = "So Tonight That I Might See" },
                new Song { Id = 2, Title = "Wet Sand", Artists = "Red Hot Chili Peppers", Album = "Stadium Arcadium" },
                new Song { Id = 3, Title = "I Am the Highway", Artists = "Audioslave", Album = "Audioslave" }
            };

            _songRepositoryMock.Setup(s => s.GetAll()).Returns(_songList);
            _songRepositoryMock.Setup(s => s.GetById(1)).Returns(_songList.FirstOrDefault(x => x.Id == 1));
            _songRepositoryMock.Setup(s => s.GetById(2)).Returns(_songList.FirstOrDefault(x => x.Id == 2));
            _songRepositoryMock.Setup(s => s.GetById(3)).Returns(_songList.FirstOrDefault(x => x.Id == 3));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        //Given_When_Then
        public void ValidIdSong_WhenGetById_ReturnCorrectIdSong(int idSong)
        {
            // Act
            var song = _songService.GetById(idSong);

            // Assert
            Assert.Equal(idSong, song.Id);
            Assert.IsType<Song>(song);
        }

        [Theory]
        [InlineData(2)]        
        //Given_When_Then
        public void ValidIdSong_WhenGetById_ReturnCorrectSongTitle(int idSong)
        {
            // Act
            var song = _songService.GetById(idSong);

            // Assert
            Assert.Equal("Wet Sand", song.Title);
            Assert.IsType<Song>(song);
            Assert.NotNull(song);
        }

        [Theory]
        [InlineData(5)]        
        //Given_When_Then
        public void NonExistentIdSong_WhenGetById_ReturnNull(int idSong)
        {
            // Act
            var song = _songService.GetById(idSong);

            // Assert
            Assert.Null(song);
        }

        [Fact]
        public void AllSongs_WhenGetAll_ReturnCorrectSongs()
        {
            // Act
            var songs = _songService.GetAll();

            // Assert
            Assert.Equal(3, songs.Count());
        }
    }
}
