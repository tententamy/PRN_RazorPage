using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.VendorPage
{
    public class EditModel : PageModel
    {
        //    private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IVendorBusiness _vendorBusiness;

        public EditModel()
        {
            _vendorBusiness ??= new VendorBusiness();
        }


        [BindProperty]
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
            Vendor = vendor.Data as Vendor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Vendor.VendorUpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //   _context.Attach(Vendor).State = EntityState.Modified;

            try
            {
                await _vendorBusiness.Update(Vendor);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return RedirectToPage("./Index");
        }
        /*
      private bool VendorExists(Guid id)
       {
           return _context.Vendors.Any(e => e.VendorId == id);
        }
        */
    }
}