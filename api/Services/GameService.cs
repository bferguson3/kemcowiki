using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class GameService : IGameService
    {
        public async Task<List<Game>> GetAllGames()
        {
            return await Task.FromResult(GameList);
        }

        // replace this with a db call or some other data access
        private List<Game> GameList => new List<Game>
        {
            new Game
            {
                Title = "Asdivine Saga",
                OriginalReleaseDate = new DateTime(2021, 9, 30),
                AveragePlayLength = new TimeSpan(7, 30, 0)
            },
            new Game
            {
                Title = "Ruinverse",
                OriginalReleaseDate = new DateTime(2019, 11, 26),
                AveragePlayLength = new TimeSpan(10, 15, 0)
            },
            new Game
            {
                Title = "Yodanji",
                OriginalReleaseDate = new DateTime(2017, 12, 7),
                AveragePlayLength = new TimeSpan(4, 45, 0)
            },
        };
    }
}