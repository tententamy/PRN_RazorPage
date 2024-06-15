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
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                await LoadReviewsAsync();
            }
            else
            {
                await SearchReviewsAsync(SearchTerm);
            }
        }

        private async Task LoadReviewsAsync()
        {
            var result = await _ReviewBusiness.GetAll();
            if (result != null && result.Status > 0 && result.Data != null)
            {
                Review = result.Data as List<Review>;
                foreach (var item in Review)
                {
                    await LoadAssociatedData(item);
                }
            }
        }

        private async Task SearchReviewsAsync(string searchTerm)
        {
            var result = await _ReviewBusiness.Search(searchTerm);
            if (result != null && result.Status > 0 && result.Data != null)
            {
                Review = result.Data as List<Review>;
                foreach (var item in Review)
                {
                    await LoadAssociatedData(item);
                }
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
