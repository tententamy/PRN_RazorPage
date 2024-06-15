using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.VendorPage
{
    public class CreateModel : PageModel
    {
        
        private readonly IVendorBusiness _vendorBusiness;
      

        public CreateModel()
        {

            _vendorBusiness = new VendorBusiness();
        }

        public IActionResult OnGet()
        {

            return Page();
        }

        [BindProperty]
        public Vendor Vendor { get; set; } = default!;
         
        public async Task<IActionResult> OnPostAsync()
        {
            Vendor.VendorId = Guid.NewGuid();
            Vendor.VendorCreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
           
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _vendorBusiness.Save(Vendor);
           

            return RedirectToPage("./Index");
        }
    }
}