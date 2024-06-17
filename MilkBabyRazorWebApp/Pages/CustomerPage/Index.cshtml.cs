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
        public string nameKey { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string emailKey { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string addressKey { get; set; } = default!;
        public IList<Customer> Customer { get; set; } = default!;


        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 2;

        public int TotalPages { get; set; }

        public async Task OnGetAsync()
        {
            if (nameKey == null && emailKey == null && addressKey == null)
            {
                var result = await customerBusiness.GetAll();
                if (result != null && result.Status > 0 && result.Data != null)
                {
                    Customer = result.Data as List<Customer>;
                    TotalPages = (int)Math.Ceiling(Customer.Count / (double)PageSize);
                    Customer = Customer.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
                }
            }
            else 
            {
                var result = await customerBusiness.Search(nameKey,emailKey,addressKey);
                if (result != null && result.Status > 0 && result.Data != null)
                {
                    Customer = result.Data as List<Customer>;
                    TotalPages = (int)Math.Ceiling(Customer.Count / (double)PageSize);
                    Customer = Customer.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
                }
            }
            }
        }
    }

