using System;
using System.Collections.Generic;
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
        public Review Review { get; set; } = new Review();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewResult = await _ReviewBusiness.GetById((Guid)id);
            if (reviewResult == null || reviewResult.Data == null)
            {
                return NotFound();
            }

            Review = reviewResult.Data as Review;
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

            if (Review.Rating < 1 || Review.Rating > 5)
            {
                ModelState.AddModelError("Review.Rating", "Rating must be between 1 and 5.");
                return Page();
            }

            if (Review.ReviewHelpfulCount < 0)
            {
                ModelState.AddModelError("Review.ReviewHelpfulCount", "ReviewHelpfulCount cannot be negative.");
                return Page();
            }

            if (Review.ReviewNotHelpfulCount < 0)
            {
                ModelState.AddModelError("Review.ReviewNotHelpfulCount", "ReviewNotHelpfulCount cannot be negative.");
                return Page();
            }

            var existingReviewResult = await _ReviewBusiness.GetById(Review.ReviewId);
            if (existingReviewResult?.Data is Review existingReview)
            {
                existingReview.CustomerId = Review.CustomerId;
                existingReview.ProductId = Review.ProductId;
                existingReview.Rating = Review.Rating;
                existingReview.ReviewText = Review.ReviewText;
                existingReview.ReviewImg = Review.ReviewImg;
                existingReview.ReviewTitle = Review.ReviewTitle;
                existingReview.ReviewHelpfulCount = Review.ReviewHelpfulCount;
                existingReview.ReviewNotHelpfulCount = Review.ReviewNotHelpfulCount;

                existingReview.ReviewUpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow);

                try
                {
                    await _ReviewBusiness.Update(existingReview);
                }
                catch (Exception ex)
                {
                    // Handle exception
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
