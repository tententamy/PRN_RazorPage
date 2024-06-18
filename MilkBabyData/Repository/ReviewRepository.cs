using Microsoft.EntityFrameworkCore;
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


        public async Task<IEnumerable<Review>> SearchAsync(string searchCustomer, string searchProduct, string searchTitle)
        {
            return await _context.Reviews
                .Where(r =>
                    (string.IsNullOrEmpty(searchCustomer) || r.Customer.CustomerName.ToLower().Contains(searchCustomer.ToLower())) &&
                    (string.IsNullOrEmpty(searchProduct) || r.Product.ProductName.ToLower().Contains(searchProduct.ToLower())) &&
                    (string.IsNullOrEmpty(searchTitle) || r.ReviewTitle.ToLower().Contains(searchTitle.ToLower())))
                .ToListAsync();
        }


    }
}
