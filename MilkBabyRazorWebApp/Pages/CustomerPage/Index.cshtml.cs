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
        private readonly ICustomerBusiness customerBusiness;
       

        public IndexModel()
        {
            customerBusiness ??= new CustomerBusiness();
        }
        [BindProperty(SupportsGet = true)]
        public string SearchKey { get; set; } = default!;
        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (SearchKey != null)
            {
                var result = await customerBusiness.GetByName(SearchKey);
                if (result != null && result.Status > 0 && result.Data != null)
                {
                    Customer = result.Data as List<Customer>;
                }
            }
            else 
            { 
                    var result = await customerBusiness.GetAll();
                    if (result != null && result.Status > 0 && result.Data != null)
                    {
                        Customer = result.Data as List<Customer>;
                    }
            }
        }
    }
}
