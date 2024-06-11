using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.OrderItemPage
{
    public class DeleteModel : PageModel
    {
        //private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IOrderItemBusiness _orderItemBusiness;
        public DeleteModel()
        {
            _orderItemBusiness = new OrderItemBusiness();
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem = await _orderItemBusiness.GetById((Guid)id);

            if (orderitem == null)
            {
                return NotFound();
            }
            else
            {
                OrderItem = (OrderItem)orderitem.Data;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem = await _orderItemBusiness.GetById((Guid)id);
            if (orderitem != null)
            {
                OrderItem = (OrderItem)orderitem.Data;
                await _orderItemBusiness.DeleteById((Guid)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
