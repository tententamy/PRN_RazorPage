using Microsoft.EntityFrameworkCore;
using MilkBabyData.Models;

namespace MilkBabyData.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(){}

        public ProductRepository(NET1702_PRN221_MilkBabyContext context) : base(context) => _context = context;

        public async Task<List<Product>> SearchAsync(string nameKey, string desKey, string cateKey)
        {
            return await _context.Products
                                 .Where(p => (string.IsNullOrEmpty(nameKey) || p.ProductName.Contains(nameKey)) &&
                                             (string.IsNullOrEmpty(desKey) || p.ProductDescription.Contains(desKey)) &&
                                             (string.IsNullOrEmpty(cateKey) || p.ProductCategory.Contains(cateKey)))
                                 .ToListAsync();
        }
    }
}
