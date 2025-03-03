//using Canteen.Application.Repositories.Contracts;
//using Canteen.Application.Responses;
//using Canteen.DataAccessLayer.Data;
//using Microsoft.EntityFrameworkCore;

//namespace Canteen.Application.Repositories.Implementation
//{
//    public class GenericRepository<T> : IGenericRepository<T> where T : class
//    {
//        private readonly AppDbContext db;

//        public GenericRepository(AppDbContext _db)
//        {
//            db = _db;
//        }

//        public async Task<GeneralResponse> Add(T entity)
//        {
//            db.Set<T>().Add(entity);
//            await db.SaveChangesAsync();
//            return new GeneralResponse(true, "Added");
//        }

//        public async Task<GeneralResponse> Delete(int id)
//        {
//            var model = db.Set<T>().Find(id)!;
//            if (model == null) return new GeneralResponse(false, "not found");
//            db.Set<T>().Remove(model);
//            await db.SaveChangesAsync();
//            return new GeneralResponse(true, "Successfully deleted ");
//        }

//        public T Get(int id)
//        {
//            return db.Set<T>().Find(id)!;
//        }

//        public async Task<IReadOnlyList<T>> GetAll()
//        {
//            return await db.Set<T>().ToListAsync();
//        }

//        public async Task<GeneralResponse> Update(T entity)
//        {
//            db.Set<T>().Update(entity);
//            await db.SaveChangesAsync();// Save changes to the repository

//            return new GeneralResponse(true, "Entity updated successfully"); ;
//        }
//    }
//}


using Canteen.Application.Repositories.Contracts;
using Canteen.Application.Responses;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canteen.Application.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(IMongoDatabase database)
        {
            // Assuming the collection name is the class name, but this can be customized.
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<GeneralResponse> Add(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return new GeneralResponse(true, "Added successfully");
        }

        public async Task<GeneralResponse> Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await _collection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
                return new GeneralResponse(false, "Entity not found");

            return new GeneralResponse(true, "Successfully deleted");
        }

        public async Task<T> Get(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
        }

        public async Task<GeneralResponse> Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", entity.GetType().GetProperty("Id")?.GetValue(entity).ToString());
            var result = await _collection.ReplaceOneAsync(filter, entity);

            if (result.ModifiedCount == 0)
                return new GeneralResponse(false, "No changes were made");

            return new GeneralResponse(true, "Entity updated successfully");
        }
    }
}
