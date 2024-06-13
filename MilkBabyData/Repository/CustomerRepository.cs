using Microsoft.EntityFrameworkCore;
using MilkBabyData.Models;

namespace MilkBabyData.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository() { }
        public CustomerRepository(NET1702_PRN221_MilkBabyContext context) : base(context) => _context = context;

        ////TO-DO CODE HERE/////////////////
        public async Task<List<Customer>> GetByNameAsync(String key)
        {
            return await _context.Customers
                                 .Where(c => c.CustomerName.Contains(key))
                                 .ToListAsync();
    }
}
}
