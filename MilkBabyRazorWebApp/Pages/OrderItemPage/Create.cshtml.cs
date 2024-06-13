using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages.OrderItemPage
{
    public class CreateModel : PageModel
    {
        //private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;

        private readonly IOrderItemBusiness _orderItemBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IOrderBusiness _orderBusiness;

        public CreateModel()
        {
            _orderItemBusiness = new OrderItemBusiness();
            _productBusiness = new ProductBusiness();
            _orderBusiness = new OrderBusiness();
        }

        public IActionResult OnGet()
        {
            var orders = _orderBusiness.GetAll();
            var products = _productBusiness.GetAll();

            // Assign orders to the OrderId dropdown list
            ViewData["OrderId"] = new SelectList((List<Order>)orders.Result.Data, "OrderId", "OrderId");

            // Assign products to the ProductId dropdown list, displaying the product name
            ViewData["ProductId"] = new SelectList((List<Product>)products.Result.Data, "ProductId", "ProductName");

            // Return the page to be rendered
            return Page();
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            OrderItem.OrderItemCreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
            OrderItem.OrderItemId = Guid.NewGuid();
            await _orderItemBusiness.Save(OrderItem);

            return RedirectToPage("./Index");
        }
    }
}
