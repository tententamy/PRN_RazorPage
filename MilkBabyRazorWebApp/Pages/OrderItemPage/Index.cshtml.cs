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
    public class IndexModel : PageModel
    {
        //private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
        private readonly IOrderItemBusiness _orderItemBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IOrderBusiness _orderBusiness;

        public IndexModel()
        {
            _orderItemBusiness ??= new OrderItemBusiness();
            _productBusiness ??= new ProductBusiness();
            _orderBusiness = new OrderBusiness();
        }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 2;

        public int TotalPages { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchKey { get; set; } = default!;
		[BindProperty(SupportsGet = true)]
		public string SearchProductName { get; set; }
		[BindProperty(SupportsGet = true)]
		public int? SearchQuantity { get; set; }
		[BindProperty(SupportsGet = true)]
		public decimal? SearchPrice { get; set; }
		[BindProperty(SupportsGet = true)]
		public decimal? SearchDiscount { get; set; }
		public IList<OrderItem> OrderItem { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (SearchProductName == null && SearchDiscount == null && SearchQuantity== null && SearchPrice == null)
            {
                var result = await _orderItemBusiness.GetAll();

                if (result != null && result.Status > 0 && result.Data != null)
                {
                    OrderItem = (List<OrderItem>)result.Data;
                    foreach (var item in OrderItem)
                    {
                        var productResult = await _productBusiness.GetById((Guid)item.ProductId);
                        var orderResult = await _orderBusiness.GetById((Guid)item.OrderId);
                        item.Product = productResult.Data as Product;
                        item.Order = orderResult.Data as Order;
                    }
                    TotalPages = (int)Math.Ceiling(OrderItem.Count / (double)PageSize);
                    OrderItem = OrderItem.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
                }
            }
            else
            {
                var result = await _orderItemBusiness.Search(SearchProductName, SearchQuantity, SearchPrice, SearchDiscount);

                if (result != null && result.Status > 0 && result.Data != null)
                {
                    OrderItem = (List<OrderItem>)result.Data;
                    foreach (var item in OrderItem)
                    {
                        var productResult = await _productBusiness.GetById((Guid)item.ProductId);
                        var orderResult = await _orderBusiness.GetById((Guid)item.OrderId);
                        item.Product = productResult.Data as Product;
                        item.Order = orderResult.Data as Order;
                    }
                    TotalPages = (int)Math.Ceiling(OrderItem.Count / (double)PageSize);
                    OrderItem = OrderItem.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
                }
            }
            
        }
    }
}
