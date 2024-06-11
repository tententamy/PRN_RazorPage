using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly IProductBusiness _business;
        private readonly IVendorBusiness _vendor;

        public CreateModel()
        {
            _business ??= new ProductBusiness();
            _vendor ??= new VendorBusiness();
        }

        public IActionResult OnGet()
        {
        ViewData["VendorId"] = new SelectList(_vendor.GetAll().Result.Data as List<Vendor>, "VendorId", "VendorName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product.ProductId = Guid.NewGuid();
            await _business.Save(Product);

            return RedirectToPage("./Index");
        }
    }
}
