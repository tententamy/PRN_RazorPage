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
    public class DetailsModel : PageModel
    {
        //private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IOrderItemBusiness _orderItemBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IOrderBusiness _orderBusiness;

        public DetailsModel()
        {
            _orderItemBusiness = new OrderItemBusiness();
            _productBusiness = new ProductBusiness();
            _orderBusiness = new OrderBusiness();
        }

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
                var productResult = await _productBusiness.GetById((Guid)OrderItem.ProductId);
                var orderResult = await _orderBusiness.GetById((Guid)OrderItem.OrderId);

                OrderItem.Product = productResult.Data as Product;
                OrderItem.Order = orderResult.Data as Order;
            }
            return Page();
        }
    }
}
