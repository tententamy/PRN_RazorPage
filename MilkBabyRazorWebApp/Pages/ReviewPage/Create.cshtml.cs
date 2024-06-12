using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.ReviewPage
{
    public class CreateModel : PageModel
    {
        private readonly IReviewBusiness _ReviewBusiness;
        private readonly ICustomerBusiness _CustomerBusiness;
        private readonly IProductBusiness _ProductBusiness;

        public CreateModel()
        {
            _ReviewBusiness ??= new ReviewBusiness();
            _CustomerBusiness ??= new CustomerBusiness();
            _ProductBusiness ??= new ProductBusiness(); 
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList((List<Customer>)_CustomerBusiness.GetAll().Result.Data, "CustomerId", "CustomerName");
            ViewData["ProductId"] = new SelectList((List<Product>)_ProductBusiness.GetAll().Result.Data, "ProductId", "ProductName");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if Rating is within the range 1-5
            if (Review.Rating < 1 || Review.Rating > 5)
            {
                ModelState.AddModelError("Review.Rating", "Rating must be between 1 and 5.");
                return Page();
            }



            Review.ReviewDate = DateOnly.FromDateTime(DateTime.UtcNow);
            Review.ReviewId = Guid.NewGuid();
            await _ReviewBusiness.Save(Review);

            return RedirectToPage("./Index");
        }
    }
}
