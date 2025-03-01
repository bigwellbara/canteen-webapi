using Canteen.Application.Repositories.Contracts;
using Canteen.DataAccessLayer.Data;
using Canteen.Domain;

namespace Canteen.Application.Repositories.Implementation
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public readonly AppDbContext _db;

        public OrderRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}