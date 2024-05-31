using MilkBabyData.Models;

namespace MilkBabyData.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository() { }
        public CustomerRepository(Net1702Prn221MilkBabyContext context) : base(context) => _context = context;

        ////TO-DO CODE HERE/////////////////
    }
}
