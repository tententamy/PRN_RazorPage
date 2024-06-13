using Microsoft.EntityFrameworkCore;
using MilkBabyData.Models;

namespace MilkBabyData.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(){}

        public ProductRepository(NET1702_PRN221_MilkBabyContext context) : base(context) => _context = context;

        public async Task<List<Product>> GetByProductNameAsync(String key)
        {
            return await _context.Products
                                 .Where(c => c.ProductName.Contains(key))
                                 .ToListAsync();
        }
    }
}
