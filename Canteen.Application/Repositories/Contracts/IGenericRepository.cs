using Canteen.Application.Responses;

namespace Canteen.Application.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<GeneralResponse> Add(T entity);
        Task<GeneralResponse> Delete(string id); // Change type to string for MongoDB ID
        Task<T> Get(string id); // Change type to string for MongoDB ID
        Task<IReadOnlyList<T>> GetAll();
        Task<GeneralResponse> Update(T entity);
    }
}