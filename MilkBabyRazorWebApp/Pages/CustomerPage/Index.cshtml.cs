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
    public class IndexModel : PageModel
    {
        //private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly ICustomerBusiness customerBusiness;

        public IndexModel()
        {
            customerBusiness ??= new CustomerBusiness();
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
           var result = await customerBusiness.GetAll();
            if(result != null && result.Status > 0 && result.Data != null) 
            {
                Customer = result.Data as List<Customer>;
            }
        }
    }
}
