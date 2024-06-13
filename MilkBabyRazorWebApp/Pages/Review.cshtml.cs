using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;

namespace MilkBabyRazorWebApp.Pages
{
    public class ReviewModel : PageModel
    {
        private readonly ReviewBusiness _reviewBusiness = new ReviewBusiness();
        public string Message { get; set; } = default;
        [BindProperty]
        public Review Review { get; set; } = default;
        public List<Review> Reviews { get; set; } = new List<Review>();

        public void OnGet()
        {
            Reviews = GetReviews();
        }

        public IActionResult OnPost()
        {
            this.Review.ReviewId = Guid.NewGuid();
            this.Review.ReviewCreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
            SaveReview();
            Reviews = GetReviews();
            return Page();
        }

        public IActionResult OnGetUpdate(Guid reviewId)
        {
            var result = _reviewBusiness.GetById(reviewId);
            if (result.Result.Data != null)
            {
                Review = result.Result.Data as Review;
            }
            else
            {
                TempData["ErrorMessage"] = result.Result.Message;
            }
            return new JsonResult(Review);
        }

        public IActionResult OnPostUpdate()
        {
            var existingReview = GetReviewById(Review.ReviewId);
            if (existingReview != null)
            {
                existingReview.ProductId = Review.ProductId;
                existingReview.CustomerId = Review.CustomerId;
                existingReview.Rating = Review.Rating;
                existingReview.ReviewText = Review.ReviewText;
                existingReview.ReviewUpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
                existingReview.ReviewImg = Review.ReviewImg;
                UpdateReview(existingReview);
            }
            Reviews = GetReviews();
            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            if (GetReviewById(Review.ReviewId) != null)
            {
                DeleteReview(Review.ReviewId);
            }
            Reviews = GetReviews();
            return RedirectToPage();
        }

        public List<Review> GetReviews()
        {
            var reviewResult = _reviewBusiness.GetAll();

            if (reviewResult.Status > 0 && reviewResult.Result.Data != null)
            {
                var reviews = (List<Review>)reviewResult.Result.Data;
                return reviews;
            }
            return new List<Review>();
        }

        private void SaveReview()
        {
            var reviewResult = _reviewBusiness.Save(Review);

            if (reviewResult != null)
            {
                Message = reviewResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void DeleteReview(Guid id)
        {
            var reviewResult = _reviewBusiness.DeleteById(id);
            if (reviewResult != null)
            {
                Message = reviewResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void UpdateReview(Review updateReview)
        {
            var reviewResult = _reviewBusiness.Update(updateReview);
            if (reviewResult != null)
            {
                Message = reviewResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private Review GetReviewById(Guid id)
        {
            var reviewResult = _reviewBusiness.GetById(id);
            if (reviewResult.Status > 0 && reviewResult.Result.Data != null)
            {
                return (Review)reviewResult.Result.Data;
            }
            Message = "Review Not Exist!!";
            return null;
        }

        public string GetWelcomeMsg()
        {
            return "Welcome to the Razor Page Web Application";
        }
    }
}
