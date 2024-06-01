using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;

namespace MilkBabyRazorWebApp.Pages
{
    public class OrderItemModel : PageModel
    {
        private readonly OrderItemBusiness _orderItemBusiness = new OrderItemBusiness();
        public string Message { get; set; } = default;
        [BindProperty]
        public OrderItem OrderItem { get; set; } = default;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public void OnGet()
        {
            OrderItems = GetOrderItems();
        }

        public IActionResult OnPost()
        {
            this.OrderItem.OrderItemId = Guid.NewGuid();
            SaveOrderItem();
            OrderItems = GetOrderItems();
            return Page();
        }

        public IActionResult OnGetUpdate(Guid orderItemId)
        {
            var result = _orderItemBusiness.GetById(orderItemId);
            if (result.Result.Data != null)
            {
                OrderItem = result.Result.Data as OrderItem;

            }
            else
            {
                TempData["ErrorMessage"] = result.Result.Message;
            }
            return new JsonResult(OrderItem);
        }

        public IActionResult OnPostUpdate()
        {
            var existingOrderItem = GetOrderItemById(OrderItem.OrderItemId);
            if (existingOrderItem != null)
            {
                existingOrderItem.OrderId = OrderItem.OrderId;
                existingOrderItem.ProductId = OrderItem.ProductId;
                existingOrderItem.Quantity = OrderItem.Quantity;
                existingOrderItem.Price = OrderItem.Price;
                UpdateOrderItem(existingOrderItem);
            }
            OrderItems = GetOrderItems();
            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            if (GetOrderItemById(OrderItem.OrderItemId) != null)
            {
                DeleteOrderItem(OrderItem.OrderItemId);
            }
            OrderItems = GetOrderItems();
            return RedirectToPage();
        }

        public List<OrderItem> GetOrderItems()
        {
            var orderItemResult = _orderItemBusiness.GetAll();

            if (orderItemResult.Status > 0 && orderItemResult.Result.Data != null)
            {
                var orderItems = (List<OrderItem>)orderItemResult.Result.Data;
                return orderItems;
            }
            return new List<OrderItem>();
        }

        private void SaveOrderItem()
        {
            var orderItemResult = _orderItemBusiness.Save(OrderItem);

            if (orderItemResult != null)
            {
                Message = orderItemResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }
        private void DeleteOrderItem(Guid id)
        {
            var orderItemResult = _orderItemBusiness.DeleteById(id);
            if (orderItemResult != null)
            {
                Message = orderItemResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void UpdateOrderItem(OrderItem updateOrderItem)
        {
            var orderItemResult = _orderItemBusiness.Update(updateOrderItem);
            if (orderItemResult != null)
            {
                Message = orderItemResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private OrderItem GetOrderItemById(Guid id)
        {
            var orderItemResult = _orderItemBusiness.GetById(id);
            if (orderItemResult.Status > 0 && orderItemResult.Result.Data != null)
            {
                return (OrderItem)orderItemResult.Result.Data;
            }
            Message = "Order Item Not Exist!!";
            return null;
        }

        public string GetWelcomeMsg()
        {
            return "Welcome to the Razor Page Web Application for Order Items";
        }
    }
}

