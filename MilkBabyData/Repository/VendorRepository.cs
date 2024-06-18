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

        public async Task<IEnumerable<Vendor>> SearchAsync(string searchName, string searchCP, string searchWeb)
        {
            return await _context.Vendors
                .Where(v =>
                    (string.IsNullOrEmpty(searchName) || v.VendorName.ToLower().Contains(searchName.ToLower())) &&
                    (string.IsNullOrEmpty(searchCP) || v.VendorContactPerson.ToLower().Contains(searchCP.ToLower())) &&
                    (string.IsNullOrEmpty(searchWeb) || v.VendorWebsite.ToLower().Contains(searchWeb.ToLower())))
                .ToListAsync();
        }
    }
}
