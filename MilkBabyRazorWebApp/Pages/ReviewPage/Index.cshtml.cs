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
    public class IndexModel : PageModel
    {
        //private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IReviewBusiness _ReviewBusiness;
        private readonly ICustomerBusiness _CustomerBusiness;
        private readonly IProductBusiness _ProductBusiness;
        public IndexModel()
        {
            _ReviewBusiness ??= new ReviewBusiness();
            _CustomerBusiness ??= new CustomerBusiness();
            _ProductBusiness ??= new ProductBusiness();
        }

        public IList<Review> Review { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var result = await _ReviewBusiness.GetAll();
            if (result != null && result.Status > 0 && result.Data != null)
            {
                Review = result.Data as List<Review>;
                foreach (var item in Review)
                {
                    var productResult = await _ProductBusiness.GetById((Guid)item.ProductId);
                    var customerResult = await _CustomerBusiness.GetById((Guid)item.CustomerId);
                    //if (productResult != null ) 
                    //{
                    item.Product = productResult.Data as Product;
                    item.Customer = customerResult.Data as Customer;
                    //}
                }
            }
        }
    }
}
