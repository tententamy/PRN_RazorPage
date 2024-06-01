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
        public OrderItemRepository(Net1702Prn221MilkBabyContext context) : base(context) => _context = context;
    }
}
