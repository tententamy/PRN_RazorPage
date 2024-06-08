using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;

namespace MilkBabyRazorWebApp.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ProductBusiness _productBusiness = new ProductBusiness();
        private readonly VendorBusiness _vendorBusiness = new VendorBusiness();
        public string Message { get; set; } = default;
        [BindProperty]
        public Product Product { get; set; } = default;
        public List<Product> Products { get; set; } = new List<Product>();

        public List<Vendor> Vendors { get; set; } = new List<Vendor>();

        public void OnGet()
        {
            Products = GetProducts();
            Vendors = GetVendors();
        }

        public IActionResult OnPost()
        {
            this.Product.ProductId = Guid.NewGuid();
            SaveProduct();
            Products = GetProducts();
            return Page();
        }

        public IActionResult OnGetUpdate(Guid productId)
        {
            var result = _productBusiness.GetById(productId);
            if (result.Result.Data != null)
            {
                Product = result.Result.Data as Product;
            }
            else
            {
                TempData["ErrorMessage"] = result.Result.Message;
            }
            return new JsonResult(Product);
        }

        public IActionResult OnPostUpdate()
        {
            var existingProduct = GetProductById(Product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = Product.ProductName;
                existingProduct.ProductDescription = Product.ProductDescription;
                existingProduct.ProductPrice = Product.ProductPrice;
                existingProduct.ProductQuantity = Product.ProductQuantity;
                existingProduct.ProductDateStart = Product.ProductDateStart;
                existingProduct.ProductDateEnd = Product.ProductDateEnd;
                existingProduct.ProductCategory = Product.ProductCategory;
                existingProduct.ProductImg = Product.ProductImg;
                UpdateProduct(existingProduct);
            }
            Products = GetProducts();
            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            if (GetProductById(Product.ProductId) != null)
            {
                DeleteProduct(Product.ProductId);
            }
            Products = GetProducts();
            return RedirectToPage();
        }

        public List<Product> GetProducts()
        {
            var productResult = _productBusiness.GetAll();

            if (productResult.Status > 0 && productResult.Result.Data != null)
            {
                var products = (List<Product>)productResult.Result.Data;
                return products;
            }
            return new List<Product>();
        }

        private List<Vendor> GetVendors()
        {
            var vendorResult = _vendorBusiness.GetAll();
            if (vendorResult.Status > 0 && vendorResult.Result.Data != null)
            {
                return (List<Vendor>)vendorResult.Result.Data;
            }
            return new List<Vendor>();
        }

        private void SaveProduct()
        {
            var productResult = _productBusiness.Save(Product);

            if (productResult != null)
            {
                Message = productResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void DeleteProduct(Guid id)
        {
            var productResult = _productBusiness.DeleteById(id);
            if (productResult != null)
            {
                Message = productResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void UpdateProduct(Product updateProduct)
        {
            var productResult = _productBusiness.Update(updateProduct);
            if (productResult != null)
            {
                Message = productResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private Product GetProductById(Guid id)
        {
            var productResult = _productBusiness.GetById(id);
            if (productResult.Status > 0 && productResult.Result.Data != null)
            {
                return (Product)productResult.Result.Data;
            }
            Message = "Product Not Exist!!";
            return null;
        }

        public string GetVendorNameByProductId(Guid productId)
        {
            var product = GetProductById(productId);
            if (product != null && product.VendorId != null)
            {
                var vendorResult = _vendorBusiness.GetById(product.VendorId.Value);
                if (vendorResult.Status > 0 && vendorResult.Result.Data != null)
                {
                    var vendor = (Vendor)vendorResult.Result.Data;
                    if (vendor != null)
                    {
                        return vendor.VendorName;
                    }
                }
            }
            return string.Empty;
        }

        public string GetWelcomeMsg()
        {
            return "Welcome to the Razor Page Web Application";
        }
    }
}