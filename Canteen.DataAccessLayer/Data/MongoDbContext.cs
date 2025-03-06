using Canteen.Domain.Aggregates.MenuItemAggregate;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Canteen.DataAccessLayer.Data
{
    public class MongoDbContext
    {
        
        private readonly IMongoDatabase _database;

        public MongoDbContext(MongoDbConfig mongoDbConfig)
        {
            _database = mongoDbConfig.Database;
        }

        //public IMongoCollection<UserProfile> UserProfiles => _database.GetCollection<UserProfile>("UserProfiles");
        //public IMongoCollection<MenuItem> MenuItems => _database.GetCollection<MenuItem>("MenuItems");


        //public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");
        //public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
        //public IMongoCollection<OrderItem> OrderItems => _database.GetCollection<OrderItem>("OrderItems");
        //public IMongoCollection<Payment> Payments => _database.GetCollection<Payment>("Payments");
        //public IMongoCollection<Review> Reviews => _database.GetCollection<Review>("Reviews");

        // Generic method to get any collection
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }

 
}


