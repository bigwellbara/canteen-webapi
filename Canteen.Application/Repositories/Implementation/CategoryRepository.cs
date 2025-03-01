using Canteen.Application.Repositories.Contracts;
using Canteen.DataAccessLayer.Data;
using Canteen.Domain;

namespace Canteen.Application.Repositories.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}