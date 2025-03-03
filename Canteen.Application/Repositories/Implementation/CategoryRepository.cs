using Canteen.Application.Repositories.Contracts;
using Canteen.DataAccessLayer.Data;
using Canteen.Domain;
using MongoDB.Driver;

namespace Canteen.Application.Repositories.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
       
            public readonly IMongoCollection<Category> _collection;

            // Modify the constructor to accept IMongoDatabase
            public CategoryRepository(IMongoDatabase database) : base(database)
            {
                _collection = database.GetCollection<Category>("Categories"); // specify the collection name
            }
        
}