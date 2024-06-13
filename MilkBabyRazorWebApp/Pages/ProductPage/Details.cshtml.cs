using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.ProductsPage
{
    public class DetailsModel : PageModel
    {
        private readonly IProductBusiness _busniess;
        private readonly IVendorBusiness _vendor;


        public DetailsModel()
        {
            _busniess ??= new ProductBusiness();
            _vendor ??= new VendorBusiness();
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _busniess.GetById((Guid)id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = (Product)product.Data;

                // Retrieve the Vendor object
                if (Product.VendorId.HasValue)
                {
                    var vendor = await _vendor.GetById(Product.VendorId.Value);
                    if (vendor != null)
                    {
                        Product.Vendor = (Vendor)vendor.Data;
                    }
                }
            }

            return Page();
        }
    }
}
