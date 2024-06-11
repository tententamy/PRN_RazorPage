using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.OrderPage
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderBusiness _business;
        private readonly ICustomerBusiness _customer;

        public DeleteModel()
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
            else
            {
                Order = (Order)order.Data;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _business.GetById((Guid)id);
            if (order != null)
            {
                Order = (Order)order.Data;
                await _business.DeleteById((Guid)id);

            }

            return RedirectToPage("./Index");
        }
    }
}
