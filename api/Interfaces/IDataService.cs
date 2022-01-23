using api.Models;

namespace api.Interfaces
{
    public interface IDataService
    {
        Task<List<T>> GetAll<T>()
            where T: IDataModel;

        Task<T?> GetSingle<T>(string id)
            where T: IDataModel;
    }
}