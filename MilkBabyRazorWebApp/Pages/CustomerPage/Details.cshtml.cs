using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.CustomerPage
{
    public class DetailsModel : PageModel
    {
        //private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly ICustomerBusiness _customerBusiness;
        public DetailsModel()
        {
            _customerBusiness ??= new CustomerBusiness();
        }

        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerBusiness.GetById((Guid)id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = (Customer)customer.Data;
            }
            return Page();
        }
    }
}
