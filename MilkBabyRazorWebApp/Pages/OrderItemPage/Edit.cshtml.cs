using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.OrderItemPage
{
    public class EditModel : PageModel
    {
        //private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IOrderItemBusiness _orderItemBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IOrderBusiness _orderBusiness;

        public EditModel()
        {
            _orderItemBusiness = new OrderItemBusiness();
            _productBusiness = new ProductBusiness();
            _orderBusiness = new OrderBusiness();
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
            OrderItem = (OrderItem)orderitem.Data;
            var orders = _orderBusiness.GetAll();
            var products = _productBusiness.GetAll();

            // Assign orders to the OrderId dropdown list
            ViewData["OrderId"] = new SelectList((List<Order>)orders.Result.Data, "OrderId", "OrderId");

            // Assign products to the ProductId dropdown list, displaying the product name
            ViewData["ProductId"] = new SelectList((List<Product>)products.Result.Data, "ProductId", "ProductName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(OrderItem).State = EntityState.Modified;

            try
            {
                OrderItem.OrderItemUpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
                await _orderItemBusiness.Update(OrderItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                /*if (!OrderItemExists(OrderItem.OrderItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }*/
                throw;
            }

            return RedirectToPage("./Index");
        }

        /*  private bool OrderItemExists(Guid id)
          {
              return _context.OrderItems.Any(e => e.OrderItemId == id);
          }*/
    }
}
