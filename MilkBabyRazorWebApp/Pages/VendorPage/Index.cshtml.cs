using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.VendorPage
{
    public class IndexModel : PageModel
    {
      //  private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IVendorBusiness business;

        public IndexModel()
        {
            business ??= new VendorBusiness();
        }
  public IList<Vendor> Vendor { get;set; } = default!;


  public async Task OnGetAsync()
        {
            var result = await business.GetAll();
            if(result != null && result.Status > 0 && result.Data != null)
            {
                Vendor =  result.Data as IList<Vendor>;
            } 
          
        }
      
      
    }
}
