using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.OrdersPage
{
    public class IndexModel : PageModel
    {
        private readonly IOrderBusiness business;
        private readonly ICustomerBusiness _customer;

        public IndexModel()
        {
            business ??= new OrderBusiness();
            _customer ??= new CustomerBusiness();
        }
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 2;

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchKey { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchStatus { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchAddress { get; set; } = default!;
        public string SearchVoucher { get; set; } = default!;
        public IList<Order> Order { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(SearchAddress) && string.IsNullOrEmpty(SearchStatus) && string.IsNullOrEmpty(SearchVoucher))
            {
                var result = await business.GetAll();
                if (result != null && result.Status > 0 && result.Data != null)
                {
                    Order = result.Data as List<Order>;
                    TotalPages = (int)Math.Ceiling(Order.Count / (double)PageSize);
                    Order = Order.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
                }
            }
            else
            {
                var result = await business.Search(SearchAddress, SearchStatus, SearchVoucher);
                if (result != null && result.Status > 0 && result.Data != null)
                {
                    Order = result.Data as List<Order>;
                    TotalPages = (int)Math.Ceiling(Order.Count / (double)PageSize);
                    Order = Order.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
                }
            }
        }
    
}
}
