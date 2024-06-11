using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.ReviewPage
{
    public class DetailsModel : PageModel
    {
        private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;

        public DetailsModel(MilkBabyData.Models.Net1702Prn221MilkBabyContext context)
        {
            _context = context;
        }

        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }
            else
            {
                Review = review;
            }
            return Page();
        }
    }
}
