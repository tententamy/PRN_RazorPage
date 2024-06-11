using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly IProductBusiness _business;
        private readonly IVendorBusiness _vendor;

        public IndexModel()
        {
            _business ??= new ProductBusiness();
            _vendor ??= new VendorBusiness();
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var result = await _business.GetAll();

            if (result != null && result.Status > 0 && result.Data != null)
            {
                Product = result.Data as List<Product>;

                // Populate customer names based on CustomerId
                foreach (var product in Product)
                {
                    if (product.VendorId != null)
                    {
                        var productResult = await _vendor.GetById((Guid)product.VendorId);
                        if (productResult != null && productResult.Status > 0 && productResult.Data != null)
                        {
                            var vendor = productResult.Data as Vendor;
                            if (product.Vendor != null)
                            {
                                product.Vendor.VendorName = vendor.VendorName;
                            }
                            else
                            {
                                product.Vendor = vendor;
                            }
                        }
                    }
                }
            }
        }
    }
}
