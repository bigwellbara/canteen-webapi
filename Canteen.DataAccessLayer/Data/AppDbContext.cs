using Canteen.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Canteen.DataAccessLayer.Data
{
    public class AppDbContext
    {
        //    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //    {
        //    }

        //    public DbSet<Category> Categories { get; set; }
        //    public DbSet<MenuItem> MenuItems { get; set; }
        //    public DbSet<Order> Orders { get; set; }
        //    public DbSet<OrderItem> OrderItems { get; set; }
        //    public DbSet<Payment> Payments { get; set; }
        //    public DbSet<Review> Reviews { get; set; }


        private readonly IMongoDatabase _database;

        public AppDbContext(MongoDbConfig mongoDbConfig)
        {
            _database = mongoDbConfig.Database;
        }

        public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");
        public IMongoCollection<MenuItem> MenuItems => _database.GetCollection<MenuItem>("MenuItems");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
        public IMongoCollection<OrderItem> OrderItems => _database.GetCollection<OrderItem>("OrderItems");
        public IMongoCollection<Payment> Payments => _database.GetCollection<Payment>("Payments");
        public IMongoCollection<Review> Reviews => _database.GetCollection<Review>("Reviews");


    }

 
}


