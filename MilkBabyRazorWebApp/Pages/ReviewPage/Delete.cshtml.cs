using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.ReviewPage
{
    public class DeleteModel : PageModel
    {
        private readonly IReviewBusiness _reviewBusiness;
        private readonly ICustomerBusiness _CustomerBusiness;
        private readonly IProductBusiness _ProductBusiness;

        public DeleteModel()
        {
            _reviewBusiness ??= new ReviewBusiness();
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

            var review = await _reviewBusiness.GetById((Guid)id);

            if (review == null)
            {
                return NotFound();
            }
            else
            {
                Review = (Review)review.Data;
                var customer = await _CustomerBusiness.GetById((Guid)Review.CustomerId);
                var product = await _ProductBusiness.GetById((Guid)Review.ProductId);
                Review.Customer = (Customer)customer.Data;
                Review.Product = (Product)product.Data;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviewBusiness.GetById((Guid)id);
            if (review != null)
            {
                Review = (Review)review.Data;
                await _reviewBusiness.DeleteById((Guid)id);

            }

            return RedirectToPage("./Index");
        }
    }
}