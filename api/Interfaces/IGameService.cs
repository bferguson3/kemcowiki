using api.Models;

namespace api.Interfaces
{
    public interface IGameService
    {
         Task<List<Game>> GetAllGames();

         Task<Game?> GetSingleGame(string gameId);
    }
}