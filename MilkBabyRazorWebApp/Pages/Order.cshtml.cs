using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;

namespace MilkBabyRazorWebApp.Pages
{
    public class OrderModel : PageModel
    {
        private readonly OrderBusiness _orderBusiness = new OrderBusiness();
        private readonly OrderItemBusiness _orderItemBusiness = new OrderItemBusiness();
        private readonly ProductBusiness _productBusiness = new ProductBusiness();
        public string Message { get; set; } = default;
        [BindProperty]
        public Order Order { get; set; } = default;
        public List<Order> Orders { get; set; } = new List<Order>();

        public void OnGet()
        {
            Orders = GetOrders();
        }

        public IActionResult OnPostCreate()
        {
            this.Order.OrderId = Guid.NewGuid();
            this.Order.OrderDate = DateOnly.FromDateTime(DateTime.UtcNow);
            SaveOrder();
            Orders = GetOrders();
            return Page();
        }

        public IActionResult OnGetUpdate(Guid orderId)
        {
            var result = _orderBusiness.GetById(orderId);
            if (result.Result.Data != null)
            {
                Order = result.Result.Data as Order;
            }
            else
            {
                TempData["ErrorMessage"] = result.Result.Message;
            }
            return new JsonResult(Order);
        }

        public IActionResult OnPostUpdate()
        {
            var existingOrder = GetOrderById(Order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.CustomerId = Order.CustomerId;
                existingOrder.OrderDate = DateOnly.FromDateTime(DateTime.UtcNow);
                existingOrder.TotalAmount = Order.TotalAmount;
                existingOrder.Voucher = Order.Voucher;
                UpdateOrder(existingOrder);
            }
            Orders = GetOrders();
            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            if (GetOrderById(Order.OrderId) != null)
            {
                DeleteOrder(Order.OrderId);
            }
            Orders = GetOrders();
            return RedirectToPage();
        }

       public IActionResult OnGetDetails(Guid orderId)
{
    var result = _orderBusiness.GetById(orderId);
    if (result.Result.Data != null)
    {
        var order = result.Result.Data as Order;
        var orderItems = _orderItemBusiness.GetByOrderId(orderId).Result.Data as List<OrderItem>;
        var orderItemsWithProducts = new List<Product>();

        foreach (var item in orderItems)
        {
            var productResult = _productBusiness.GetById(item.ProductId.Value);
            if (productResult.Result.Data != null)
            {
                var product = productResult.Result.Data as Product;
                orderItemsWithProducts.Add(product);
            }
        }

        return new JsonResult(new { order, orderItems = orderItemsWithProducts });
    }

    return new JsonResult(null);
}


        public List<Order> GetOrders()
        {
            var orderResult = _orderBusiness.GetAll();
            if (orderResult.Status > 0 && orderResult.Result.Data != null)
            {
                var orders = (List<Order>)orderResult.Result.Data;
                return orders;
            }
            return new List<Order>();
        }

        private void SaveOrder()
        {
            var orderResult = _orderBusiness.Save(Order);
            if (orderResult != null)
            {
                Message = orderResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void DeleteOrder(Guid id)
        {
            var orderResult = _orderBusiness.DeleteById(id);
            if (orderResult != null)
            {
                Message = orderResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void UpdateOrder(Order updateOrder)
        {
            var orderResult = _orderBusiness.Update(updateOrder);
            if (orderResult != null)
            {
                Message = orderResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private Order GetOrderById(Guid id)
        {
            var orderResult = _orderBusiness.GetById(id);
            if (orderResult.Status > 0 && orderResult.Result.Data != null)
            {
                return (Order)orderResult.Result.Data;
            }
            Message = "Order Not Exist!!";
            return null;
        }

        public string GetWelcomeMsg()
        {
            return "Welcome Razor Page Web Application";
        }
    }
}
