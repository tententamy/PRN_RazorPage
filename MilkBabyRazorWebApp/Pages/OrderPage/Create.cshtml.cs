using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.OrdersPage
{
    public class CreateModel : PageModel
    {
        private readonly IOrderBusiness _business;
        private readonly ICustomerBusiness _customer;

        public CreateModel()
        {
            _business ??= new OrderBusiness();
            _customer ??= new CustomerBusiness();
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_customer.GetAll().Result.Data as List<Customer>, "CustomerId", "CustomerName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.OrderId = Guid.NewGuid();
            Order.OrderDate = DateOnly.FromDateTime(DateTime.UtcNow);
            Order.OrderUpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
            
            await _business.Save(Order);

            return RedirectToPage("./Index");
        }
    }
}
