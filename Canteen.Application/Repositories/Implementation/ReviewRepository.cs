using Canteen.Application.Repositories.Contracts;
using Canteen.DataAccessLayer.Data;
using Canteen.Domain;

namespace Canteen.Application.Repositories.Implementation
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public readonly AppDbContext _db;

        public ReviewRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}