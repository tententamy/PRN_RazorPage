using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.OrderPage
{
    public class EditModel : PageModel
    {
        private readonly IOrderBusiness _business;
        private readonly ICustomerBusiness _customer;

        public EditModel()
        {
            _business ??= new OrderBusiness();
            _customer ??= new CustomerBusiness();
        }

        [BindProperty]
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
            Order = order.Data as Order;
            ViewData["CustomerId"] = new SelectList(_customer.GetAll().Result.Data as List<Customer>, "CustomerId", "CustomerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            try
            {
                await _business.Update(Order);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Index");
        }

     
    }
}
