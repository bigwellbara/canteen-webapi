using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.DataAccessLayer.Data;
using MongoDB.Driver;

namespace Canteen.DataAccessLayer.MongoRepositories
{
    public class MongoGenericRepository<T> : IMongoGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoGenericRepository(MongoDbContext mongoDbContext)
        {

            
            var collectionName = typeof(T).Name + "s"; 
            _collection = mongoDbContext.GetCollection<T>(collectionName);
        
        }

        public async Task InsertOneAsync(T entity, CancellationToken cancellationToken = default)
        {
            var options = new InsertOneOptions(); 
            await _collection.InsertOneAsync(entity, options, cancellationToken);
        }


        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _collection.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("_id", id.ToString())).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, T entity, CancellationToken cancellationToken = default)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id.ToString()), entity, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id.ToString()), cancellationToken);
        }
    }
}
