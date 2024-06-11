using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.ReviewPage
{
    public class IndexModel : PageModel
    {
        //private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IReviewBusiness business;
        public IndexModel()
        {
            business ??= new ReviewBusiness();
        }

        public IList<Review> Review { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var result = await business.GetAll();
            if (result != null && result.Status > 0 && result.Data != null)
            {
                Review = result.Data as List<Review>;
            }
        }
    }
}
