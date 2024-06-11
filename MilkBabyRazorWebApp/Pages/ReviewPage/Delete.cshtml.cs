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
    public class DeleteModel : PageModel
    {
        private readonly IReviewBusiness business;

        public DeleteModel()
        {
            business ??= new ReviewBusiness();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await business.GetById((Guid)id);

            if (review == null)
            {
                return NotFound();
            }
            else
            {
                Review = (Review)review.Data;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await business.GetById((Guid)id);
            if (review != null)
            {
                Review = (Review)review.Data;
                await business.DeleteById((Guid)id);

            }

            return RedirectToPage("./Index");
        }
    }
}