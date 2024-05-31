using MilkBabyData.Base;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBabyData.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository() 
        {
            
        }

        public ProductRepository(Net1702Prn221MilkBabyContext context) => _context = context;
    }
}
