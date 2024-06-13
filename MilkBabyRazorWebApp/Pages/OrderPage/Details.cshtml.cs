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
    public class DetailsModel : PageModel
    {
        private readonly IOrderBusiness _business;
        private readonly ICustomerBusiness _customer;

        public DetailsModel()
        {
            _business ??= new OrderBusiness();
            _customer ??= new CustomerBusiness();
        }

        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _business.GetById((Guid)id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = (Order)order.Data;

                // Retrieve the Vendor object
                if (Order.CustomerId.HasValue)
                {
                    var customer = await _customer.GetById(Order.CustomerId.Value);
                    if (customer != null)
                    {
                        Order.Customer = (Customer)customer.Data;
                    }
                }
            }

            return Page();
        }
    }
}
