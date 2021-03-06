using api.Models;

namespace api.Interfaces
{
    public interface IDBService
    {
        Task<List<Game>> GetAllGames();
        Task<Game?> GetSingleGame(string id);
        Task<Game?> AddNewGame(Game newGame);

        Task<List<Developer>> GetAllDevelopers();
        Task<Developer?> GetSingleDeveloper(string id);

        Task<List<Series>> GetAllSeries();
        Task<Series?> GetSingleSeries(string id);

        Task<List<Mechanic>> GetAllMechanics();
        Task<Mechanic?> GetSingleMechanic(string id);

        Task<List<OST>> GetAllOSTs();
        Task<OST?> GetSingleOST(string id);

        Task<List<Platform>> GetAllPlatforms();
        Task<Platform?> GetSinglePlatform(string id);

        Task<List<Release>> GetAllReleases();
        Task<Release?> GetSingleRelease(string id);

        Task<List<Staff>> GetAllStaff();
        Task<Staff?> GetSingleStaff(string id);
    }
}