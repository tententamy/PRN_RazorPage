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

namespace MilkBabyRazorWebApp.Pages.ProductsPage
{
    public class EditModel : PageModel
    {
        private readonly IProductBusiness _business;
        private readonly IVendorBusiness vendorBusiness;

        public EditModel()
        {
            _business ??= new ProductBusiness();
            vendorBusiness ??= new VendorBusiness();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _business.GetById((Guid)id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product.Data as Product;
            ViewData["VendorId"] = new SelectList(vendorBusiness.GetAll().Result.Data as List<Vendor>, "VendorId", "VendorName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            try
            {
                Product.ProductUpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
                await _business.Update(Product);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Index");
        }

        /* private async bool ProductExists(Guid id)
         {
             return await _business.GetById((Guid) id);
         }*/
    }
}
