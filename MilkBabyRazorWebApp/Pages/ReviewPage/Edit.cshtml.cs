using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.ReviewPage
{
    public class EditModel : PageModel
    {
        private readonly IReviewBusiness _ReviewBusiness;
        private readonly ICustomerBusiness _CustomerBusiness;
        private readonly IProductBusiness _ProductBusiness;

        public EditModel()
        {
            _ReviewBusiness ??= new ReviewBusiness();
            _CustomerBusiness ??= new CustomerBusiness();
            _ProductBusiness ??= new ProductBusiness();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _ReviewBusiness.GetById((Guid)id);

            if (review == null)
            {
                return NotFound();
            }

            Review = review.Data as Review;
            ViewData["CustomerId"] = new SelectList((List<Customer>)_CustomerBusiness.GetAll().Result.Data, "CustomerId", "CustomerName");
            ViewData["ProductId"] = new SelectList((List<Product>)_ProductBusiness.GetAll().Result.Data, "ProductId", "ProductName");
            return Page();
        }

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

            // Ensure ReviewDate is not null and is a valid date
            if (Review.ReviewDate == null || Review.ReviewDate == default)
            {
                ModelState.AddModelError("Review.ReviewDate", "Review Date is required.");
                return Page();
            }

            try
            {
                await _ReviewBusiness.Update(Review);
            }
            catch (Exception ex)
            {
                // Handle exception
            }

            return RedirectToPage("./Index");
        }
    }
}
