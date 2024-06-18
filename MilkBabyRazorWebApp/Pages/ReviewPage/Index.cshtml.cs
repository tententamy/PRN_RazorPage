using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkBabyRazorWebApp.Pages.ReviewPage
{
    public class IndexModel : PageModel
    {
        private readonly IReviewBusiness _ReviewBusiness;
        private readonly ICustomerBusiness _CustomerBusiness;
        private readonly IProductBusiness _ProductBusiness;

        public IndexModel()
        {
            _ReviewBusiness ??= new ReviewBusiness();
            _CustomerBusiness ??= new CustomerBusiness();
            _ProductBusiness ??= new ProductBusiness();
        }

        public IList<Review> Review { get; set; } = new List<Review>();

        [BindProperty(SupportsGet = true)]
        public string searchCustomer { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchProduct { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 3;

        public int TotalPages { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(searchCustomer) || !string.IsNullOrEmpty(searchProduct) || !string.IsNullOrEmpty(searchTitle))
            {
                await SearchReviewsAsync();
            }
            else
            {
                await LoadReviewsAsync();
            }
        }

        private async Task SearchReviewsAsync()
        {
            var result = await _ReviewBusiness.Search(searchCustomer, searchProduct, searchTitle);
            if (result != null && result.Status > 0 && result.Data != null)
            {
                Review = result.Data as List<Review>;
                /*TotalPages = (int)Math.Ceiling(Review.Count / (double)PageSize);
                Review = Review.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();*/
                foreach (var item in Review)
                {
                    await LoadAssociatedData(item);
                }
                TotalPages = (int)Math.Ceiling(Review.Count / (double)PageSize);
                Review = Review.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
            }
        }

        private async Task LoadReviewsAsync()
        {
            var result = await _ReviewBusiness.GetAll();
            if (result != null && result.Status > 0 && result.Data != null)
            {
                Review = result.Data as List<Review>;
                /*TotalPages = (int)Math.Ceiling(Review.Count / (double)PageSize);
                Review = Review.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();*/
                foreach (var item in Review)
                {
                    await LoadAssociatedData(item);
                }
                TotalPages = (int)Math.Ceiling(Review.Count / (double)PageSize);
                Review = Review.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
            }
        }

        private async Task LoadAssociatedData(Review review)
        {
            var productResult = await _ProductBusiness.GetById((Guid)review.ProductId);
            var customerResult = await _CustomerBusiness.GetById((Guid)review.CustomerId);

            if (productResult != null && productResult.Data != null)
            {
                review.Product = productResult.Data as Product;
            }

            if (customerResult != null && customerResult.Data != null)
            {
                review.Customer = customerResult.Data as Customer;
            }
        }
    }
}
