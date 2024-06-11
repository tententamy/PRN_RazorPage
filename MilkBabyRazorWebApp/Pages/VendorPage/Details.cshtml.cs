using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.VendorPage
{
    public class DetailsModel : PageModel
    {
    //    private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IVendorBusiness _vendorBusiness;
     public DetailsModel()
        {
            _vendorBusiness ??= new VendorBusiness();
        }
        public Vendor Vendor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _vendorBusiness.GetById((Guid)id);
            if (vendor == null)
            {
                return NotFound();
            }
            else
            {
                Vendor = (Vendor)vendor.Data;    
            }
            return Page();
        }
    }
}
