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
       //  private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IVendorBusiness _vendorBusiness;
        /*
        public CreateModel(MilkBabyData.Models.Net1702Prn221MilkBabyContext context)
        {
            _context = context;
        } */
   
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
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Vendor.VendorId = Guid.NewGuid();
    //        Vendor.VendorId = Guid.NewGuid();
            if (!ModelState.IsValid)
            {
                return Page();
            }

           await _vendorBusiness.Save(Vendor);
           // await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
