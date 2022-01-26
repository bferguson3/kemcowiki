using Microsoft.Azure.Cosmos;

namespace api.Interfaces
{
    public interface IDbService
    {
         Task<QueryDefinition> TestQueryAsync();
    }
}