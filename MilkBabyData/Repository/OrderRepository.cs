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
    }
}
