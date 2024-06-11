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
    public class DeleteModel : PageModel
    {
        private readonly IProductBusiness _business;

        public DeleteModel()
        {
            _business ??= new ProductBusiness();
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
            else
            {
                Product = (Product)product.Data;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _business.GetById((Guid)id);
            if (product != null)
            {
                Product =   (Product)product.Data;
                await _business.DeleteById((Guid)id);
               
            }

            return RedirectToPage("./Index");
        }
    }
}
