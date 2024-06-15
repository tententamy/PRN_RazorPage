using Microsoft.EntityFrameworkCore;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBabyData.Repository
{
    public class VendorRepository : GenericRepository<Vendor>
    {
        public VendorRepository() { }

        public VendorRepository(NET1702_PRN221_MilkBabyContext context) : base(context) => _context = context;

        public async Task<IEnumerable<Vendor>> SearchAsync(string searchTerm)
        {
            var lowerCaseSearchTerm = searchTerm.ToLower();
            return await _context.Vendors
                .Where(r =>
                    r.VendorName.ToLower().Contains(lowerCaseSearchTerm) ||
                    r.VendorContactPerson.ToLower().Contains(lowerCaseSearchTerm) ||
                    r.VendorEmail.ToLower().Contains(lowerCaseSearchTerm))
                .ToListAsync();
        }
    }
}

