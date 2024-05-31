using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkBabyBusiness;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;

namespace MilkBabyRazorWebApp.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductBusiness _productBusiness = new ProductBusiness();
        public string Message { get; set; } = default;
        [BindProperty]
        public Product product { get; set; } = default;
        public List<Product> Products { get; set; } = new List<Product>();

        public void OnGet()
        {
            Products = this.GetProducts();
        }

        public IActionResult OnPost()
        {
            this.SaveProduct();
            Products = GetProducts();
            return Page();
        }

        public IActionResult OnPostDelete(Guid id)
        {
            this.DeleteProduct(id);
            Products = GetProducts();
            return RedirectToPage();  // Redirect to clear the form data
        }

        public IActionResult OnGetEdit(Guid id)
        {
            product = this.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            this.UpdateProduct();
            Products = GetProducts();
            return Page();
        }

        private List<Product> GetProducts()
        {
            var productResult = _productBusiness.GetAll();

            if (productResult.Status > 0 && productResult.Result.Data != null)
            {
                var products = (List<Product>)productResult.Result.Data;
                return products;
            }
            return new List<Product>();
        }

        private Product GetProductById(Guid id)
        {
            var productResult = _productBusiness.GetById(id);

            if (productResult.Status > 0 && productResult.Result.Data != null)
            {
                return (Product)productResult.Result.Data;
            }
            return null;
        }

        private void SaveProduct()
        {
            var productResult = _productBusiness.Save(this.product);

            if (productResult != null)
            {
                this.Message = productResult.Result.Message;
            }
            else
            {
                this.Message = "Error system";
            }
        }

        private void UpdateProduct()
        {
            var productResult = _productBusiness.Update(this.product);

            if (productResult != null)
            {
                this.Message = productResult.Result.Message;
            }
            else
            {
                this.Message = "Error system";
            }
        }

        private void DeleteProduct(Guid id)
        {
            var productResult = _productBusiness.DeleteById(id);

            if (productResult != null)
            {
                this.Message = productResult.Result.Message;
            }
            else
            {
                this.Message = "Error system";
            }
        }

        public string GetWelcomeMsg()
        {
            return "Welcome Razor Page Web Application";
        }
    }
}
