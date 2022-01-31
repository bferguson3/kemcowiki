using api.Models;

namespace api.Interfaces
{
    public interface IDBService
    {
        Task<List<Game>> GetAllGames();
        Task<Game?> GetSingleGame(string id);

        Task<List<Developer>> GetAllDevelopers();
        Task<Developer?> GetSingleDeveloper(string id);
    }
}