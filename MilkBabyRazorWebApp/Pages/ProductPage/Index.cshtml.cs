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
    public class IndexModel : PageModel
    {
        private readonly IProductBusiness _business;
        private readonly IVendorBusiness _vendor;

        public IndexModel()
        {
            _business ??= new ProductBusiness();
            _vendor ??= new VendorBusiness();
        }

        [BindProperty(SupportsGet = true)]
        public string nameKey { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string desKey { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string cateKey { get; set; } = default!;
        public IList<Product> Product { get; set; } = default!;


        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 2;

        public int TotalPages { get; set; }

        public async Task OnGetAsync()
        {
            if (nameKey == null && desKey == null && cateKey == null)
            {
                var result = await _business.GetAll();
                if (result != null && result.Status > 0 && result.Data != null)
                {
                    Product = result.Data as List<Product>;
                    TotalPages = (int)Math.Ceiling(Product.Count / (double)PageSize);
                    Product = Product.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
                }
            }
            else
            {
                var result = await _business.Search(nameKey, desKey, cateKey);
                if (result != null && result.Status > 0 && result.Data != null)
                {
                    Product = result.Data as List<Product>;
                    TotalPages = (int)Math.Ceiling(Product.Count / (double)PageSize);
                    Product = Product.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
                }
            }
        }
    }
 }


        


      