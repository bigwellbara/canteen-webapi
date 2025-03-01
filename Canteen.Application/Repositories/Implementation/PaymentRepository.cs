using Canteen.Application.Repositories.Contracts;
using Canteen.DataAccessLayer.Data;
using Canteen.Domain;

namespace Canteen.Application.Repositories.Implementation
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public readonly AppDbContext _db;

        public PaymentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}