using api.Interfaces;
using api.Models;
using static Program;
using Microsoft.Azure.Cosmos;

namespace api.Services
{
    public class GameService : IGameService
    {
        public async Task<List<Game>> GetAllGames()
        {   
            return await TestAsync("*");
        }

        public async Task<Game?> GetSingleGame(string gameId)
        {
            //var matchingGame = GameList
            //    .FirstOrDefault(g => g.Id.Equals(gameId, StringComparison.InvariantCultureIgnoreCase));

            //return await Task.FromResult(matchingGame);
            return await TestAsyncSingle("0001");
        }

        public async Task<List<Game>> TestAsync(string sel)
        {
            db.containerId = "games";
            db.partitionKey = "/games";
            db.selectKey = sel;
            QueryDefinition q = await db.TestQueryAsync();
            //PrintQuery(q);
            FeedIterator<Game> queryResultsIter = db.container.GetItemQueryIterator<Game>(q);
            List<Game> rs = new List<Game>();
            while(queryResultsIter.HasMoreResults)
            {
                FeedResponse<Game> curResSet = await queryResultsIter.ReadNextAsync();
                foreach (Game r in curResSet)
                    rs.Add(r);
            }
            return rs;
        }

        public async Task<Game?> TestAsyncSingle(string sel)
        {
            db.containerId = "games";
            db.partitionKey = "/games";
            db.selectKey = sel;
            QueryDefinition q = await db.TestQueryAsync();
            //PrintQuery(q);
            FeedIterator<Game> queryResultsIter = db.container.GetItemQueryIterator<Game>(q);
            Game r = new Game();
            while(queryResultsIter.HasMoreResults)
            {
                FeedResponse<Game> curResSet = await queryResultsIter.ReadNextAsync();
                foreach (Game g in curResSet)
                    r = g;
            }
            return r;
        }
        
        private async Task PrintQuery(QueryDefinition queryDefinition)
        {
            /* Only for debugging 
            FeedIterator<Game> queryResultSetIterator = this.container.GetItemQueryIterator<Game>(queryDefinition);
            List<Game> games = new List<Game>();
            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Game> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Game Game in currentResultSet)
                {
                    games.Add(Game);
                    Console.WriteLine("\tFound game {0}\n", Game.Id);
                }
            }
            */
            int modelType = 0;
            switch(modelType)
            {
                case 0:
                    Console.WriteLine("Query type: Releases");
                    FeedIterator<Release> queryResultSetIterator = db.container.GetItemQueryIterator<Release>(queryDefinition);
                    List<Release> objects = new List<Release>();
                    while (queryResultSetIterator.HasMoreResults)
                    {
                        FeedResponse<Release> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                        foreach (Release r in currentResultSet)
                        {
                            objects.Add(r);
                            Console.WriteLine("Found release Id: {0}\nRomanizedName: {1}\n\n", r.Id, r.RomanizedName);
                        }
                    }
                    break;
            }
        }
        
        // replace this with a db call or some other data access
        private List<Game> GameList => new List<Game>
        {
            new Game
            {
                Id = "asdivine-saga",
                Title = "Asdivine Saga",
                //OriginalReleaseDate = new DateTime(2021, 9, 30),
                AveragePlayLength = new TimeSpan(7, 30, 0)
            },
            new Game
            {
                Id = "ruinverse",
                Title = "Ruinverse",
                //OriginalReleaseDate = new DateTime(2019, 11, 26),
                AveragePlayLength = new TimeSpan(10, 15, 0)
            },
            new Game
            {
                Id = "yodanji",
                Title = "Yodanji",
                //OriginalReleaseDate = new DateTime(2017, 12, 7),
                AveragePlayLength = new TimeSpan(4, 45, 0)
            },
        };
    }
}