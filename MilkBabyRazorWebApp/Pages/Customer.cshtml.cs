using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;

namespace MilkBabyRazorWebApp.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly CustomerBusiness _customerBusiness = new CustomerBusiness();
        public string Message { get; set; } = default;
        [BindProperty]
        public Customer Customer { get; set; } = default;
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public void OnGet()
        {
            Customers = GetCustomer();
        }

        public IActionResult OnPost()
        {
            this.Customer.CustomerId = Guid.NewGuid();
            SaveCustomer();
            Customers = GetCustomer();
            return Page();
        }

        public IActionResult OnPostEdit()
        {
            var existingCustomer = GetCustomerById(Customer.CustomerId);
            if (existingCustomer != null)
            {
                UpdateCustomer(Customer);
            }
            Customers = GetCustomer();
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(Guid customerId)
        {
            if (GetCustomerById(customerId) != null)
            {
                DeleteCustomer(customerId);
            }
            Customers = GetCustomer();
            return RedirectToPage();
        }

        public List<Customer> GetCustomer()
        {
            var customerResult = _customerBusiness.GetAll();

            if (customerResult.Status > 0 && customerResult.Result.Data != null)
            {
                var customers = (List<Customer>)customerResult.Result.Data;
                return customers;
            }
            return new List<Customer>();
        }

        private void SaveCustomer()
        {
            var customerResult = _customerBusiness.Save(Customer);

            if (customerResult != null)
            {
                Message = customerResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void DeleteCustomer(Guid id)
        {
            var customerResult = _customerBusiness.DeleteById(id);
            if (customerResult != null)
            {
                Message = customerResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void UpdateCustomer(Customer updateCustomer)
        {
            var customerResult = _customerBusiness.Update(updateCustomer);
            if (customerResult != null)
            {
                Message = customerResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private Customer GetCustomerById(Guid id)
        {
            var customerResult = _customerBusiness.GetById(id);
            if (customerResult.Status > 0 && customerResult.Result.Data != null)
            {
                return (Customer)customerResult.Result.Data;
            }
            Message = "Customer Not Exist!!";
            return null;
        }

        public string GetWelcomeMsg()
        {
            return "Welcome Razor Page Web Application";
        }
    }
}
