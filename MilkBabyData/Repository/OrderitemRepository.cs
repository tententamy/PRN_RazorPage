using Microsoft.EntityFrameworkCore;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBabyData.Repository
{
    public class OrderItemRepository : GenericRepository<OrderItem>
    {
        public OrderItemRepository() { }
        public OrderItemRepository(NET1702_PRN221_MilkBabyContext context) : base(context) => _context = context;

        public async Task<List<OrderItem>> GetByOrderIdAsync(Guid orderId)
        {
            return await _context.OrderItems
                                 .Where(oi => oi.OrderId == orderId)
                                 .ToListAsync();
        }

        public async Task<List<OrderItem>> GetByProductNameAsync(string key)
        {
            return await _context.OrderItems
                                 .Where(oi => oi.Product.ProductName.Contains(key))
                                 .ToListAsync();
        }
    }
}
