using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.VendorPage
{
    public class EditModel : PageModel
    {
        
        private readonly IVendorBusiness _vendorBusiness;

        public EditModel()
        {
            _vendorBusiness ??= new VendorBusiness();
        }


        [BindProperty]
      
        public Vendor Vendor { get; set; } = new Vendor();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           

			var vendor = await _vendorBusiness.GetById((Guid)id);

            if (vendor == null || vendor.Data == null)
            {
                return NotFound();
            }
            Vendor = vendor.Data as Vendor;
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
			 
			Vendor.VendorUpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
			if (!ModelState.IsValid)
            {
                return Page();
            }
            var existingVendorResult = await _vendorBusiness.GetById(Vendor.VendorId);
            if (existingVendorResult?.Data is Vendor existingVendor)
            {
                existingVendor.VendorId = Vendor.VendorId;
                existingVendor.VendorName = Vendor.VendorName;
                existingVendor.VendorEmail = Vendor.VendorEmail;
                existingVendor.VendorPhone = Vendor.VendorPhone;    
                existingVendor.VendorContactPerson = Vendor.VendorContactPerson;
                existingVendor.VendorWebsite = Vendor.VendorWebsite;
                existingVendor.VendorStatus = Vendor.VendorStatus;
               // existingVendor.VendorCreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
                existingVendor.VendorUpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
                existingVendor.VendorNotes = Vendor.VendorNotes;

				try
				{

					await _vendorBusiness.Update(existingVendor);
				}
				catch (DbUpdateConcurrencyException)
				{

					throw;

				}
			}


           

            return RedirectToPage("./Index");
        }
       
    }
}