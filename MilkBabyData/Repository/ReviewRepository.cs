using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBabyData.Repository
{
    public class ReviewRepository : GenericRepository<Review>
    {
        ReviewRepository() { }

        public ReviewRepository(NET1702_PRN221_MilkBabyContext context) : base(context) => _context = context;
        public async Task<IEnumerable<Review>> SearchAsync(string searchTerm)
        {
            return await Task.Run(() =>
                _context.Reviews.Where(r =>
                    r.Customer.CustomerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    r.Product.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    r.ReviewTitle.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    r.ReviewText.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList()
            );
        }
    }
}
