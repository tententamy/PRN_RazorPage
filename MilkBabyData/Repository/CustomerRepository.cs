using Microsoft.EntityFrameworkCore;
using MilkBabyData.Models;

namespace MilkBabyData.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository() { }
        public CustomerRepository(NET1702_PRN221_MilkBabyContext context) : base(context) => _context = context;

        ////TO-DO CODE HERE/////////////////
        public async Task<List<Customer>> GetByMultipleCriteriaAsync(string nameKey, string emailKey, string addressKey)
        {
            return await _context.Customers
                                 .Where(c => (string.IsNullOrEmpty(nameKey) || c.CustomerName.Contains(nameKey)) &&
                                             (string.IsNullOrEmpty(emailKey) || c.CustomerEmail.Contains(emailKey)) &&
                                             (string.IsNullOrEmpty(addressKey) || c.CustomerAddress.Contains(addressKey)))
                                 .ToListAsync();
        }
    }
}

