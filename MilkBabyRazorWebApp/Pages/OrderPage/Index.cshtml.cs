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
        public string SearchKey { get; set; } = default!;
        public IList<Order> Order { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (SearchKey != null)
            {
                var result = await business.GetByNameCustomer(SearchKey);

                if (result != null && result.Status > 0 && result.Data != null)
                {
                    Order = result.Data as List<Order>;

                    // Populate customer names based on CustomerId
                    foreach (var order in Order)
                    {
                        if (order.CustomerId != null)
                        {
                            var customerResult = await _customer.GetById((Guid)order.CustomerId);
                            if (customerResult != null && customerResult.Status > 0 && customerResult.Data != null)
                            {
                                var customer = customerResult.Data as Customer;
                                if (order.Customer != null)
                                {
                                    order.Customer.CustomerName = customer.CustomerName;
                                }
                                else
                                {
                                    order.Customer = customer;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                var result = await business.GetAll();

                if (result != null && result.Status > 0 && result.Data != null)
                {
                    Order = result.Data as List<Order>;

                    // Populate customer names based on CustomerId
                    foreach (var order in Order)
                    {
                        if (order.CustomerId != null)
                        {
                            var customerResult = await _customer.GetById((Guid)order.CustomerId);
                            if (customerResult != null && customerResult.Status > 0 && customerResult.Data != null)
                            {
                                var customer = customerResult.Data as Customer;
                                if (order.Customer != null)
                                {
                                    order.Customer.CustomerName = customer.CustomerName;
                                }
                                else
                                {
                                    order.Customer = customer;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
