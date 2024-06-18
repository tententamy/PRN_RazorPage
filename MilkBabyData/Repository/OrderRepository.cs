using Microsoft.EntityFrameworkCore;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBabyData.Repository
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository() { }
        public OrderRepository(NET1702_PRN221_MilkBabyContext context) : base(context) => _context = context;

        public async Task<List<Order>> GetByCustomerNameAsync(string key)
        {
            return await _context.Orders
                                 .Where(c => c.Customer.CustomerName.Contains(key))
                                 .ToListAsync();
        }

        public async Task<List<Order>> GetByMultipleCriteriaAsync(string addressKey, string statusKey, string voucherKey)
        {
            return await _context.Orders
                                 .Where(o => (string.IsNullOrEmpty(addressKey) || o.OrderShippingAddress.Contains(addressKey)) &&
                                             (string.IsNullOrEmpty(statusKey) || o.OrderStatus.Contains(statusKey)) &&
                                             (string.IsNullOrEmpty(voucherKey) || o.Voucher.Contains(voucherKey)))
                                 .ToListAsync();
        }

    }
}
