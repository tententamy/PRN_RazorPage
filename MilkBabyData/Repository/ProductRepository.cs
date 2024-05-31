using MilkBabyData.Models;

namespace MilkBabyData.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(){}

        public ProductRepository(Net1702Prn221MilkBabyContext context) : base(context) => _context = context;
    }
}
