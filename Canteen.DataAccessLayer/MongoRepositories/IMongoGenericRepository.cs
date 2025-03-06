using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.DataAccessLayer.MongoRepositories
{
    public interface IMongoGenericRepository<T> where T : class
    {
      
        Task InsertOneAsync(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
