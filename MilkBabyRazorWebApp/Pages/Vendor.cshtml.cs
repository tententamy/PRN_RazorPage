using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using System;
using System.Collections.Generic;

namespace MilkBabyRazorWebApp.Pages
{
    public class VendorModel : PageModel
    {
        private readonly VendorBusiness _vendorBusiness = new VendorBusiness();
        public string Message { get; set; } = default;
        [BindProperty]
        public Vendor Vendor { get; set; } = default;
        public List<Vendor> Vendors { get; set; } = new List<Vendor>();

        public void OnGet()
        {
            Vendors = GetVendors();
        }

        public IActionResult OnPost()
        {
            this.Vendor.VendorId = Guid.NewGuid();
            SaveVendor();
            Vendors = GetVendors();
            return Page();
        }

        public IActionResult OnGetUpdate(Guid vendorId)
        {
            var result = _vendorBusiness.GetById(vendorId);
            if (result.Result.Data != null)
            {
                Vendor = result.Result.Data as Vendor;
            }
            else
            {
                TempData["ErrorMessage"] = result.Result.Message;
            }
            return new JsonResult(Vendor);
        }

        public IActionResult OnPostUpdate()
        {
            var existingVendor = GetVendorById(Vendor.VendorId);
            if (existingVendor != null)
            {
                existingVendor.VendorName = Vendor.VendorName;
                existingVendor.VendorAddress = Vendor.VendorAddress;
                existingVendor.VendorPhone = Vendor.VendorPhone;
                existingVendor.VendorEmail = Vendor.VendorEmail;
                UpdateVendor(existingVendor);
            }
            Vendors = GetVendors();
            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            if (GetVendorById(Vendor.VendorId) != null)
            {
                DeleteVendor(Vendor.VendorId);
            }
            Vendors = GetVendors();
            return RedirectToPage();
        }

        public List<Vendor> GetVendors()
        {
            var vendorResult = _vendorBusiness.GetAll();

            if (vendorResult.Status > 0 && vendorResult.Result.Data != null)
            {
                var vendors = (List<Vendor>)vendorResult.Result.Data;
                return vendors;
            }
            return new List<Vendor>();
        }

        private void SaveVendor()
        {
            var vendorResult = _vendorBusiness.Save(Vendor);

            if (vendorResult != null)
            {
                Message = vendorResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void DeleteVendor(Guid id)
        {
            var vendorResult = _vendorBusiness.DeleteById(id);
            if (vendorResult != null)
            {
                Message = vendorResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private void UpdateVendor(Vendor updateVendor)
        {
            var vendorResult = _vendorBusiness.Update(updateVendor);
            if (vendorResult != null)
            {
                Message = vendorResult.Result.Message;
            }
            else
            {
                Message = "Error system";
            }
        }

        private Vendor GetVendorById(Guid id)
        {
            var vendorResult = _vendorBusiness.GetById(id);
            if (vendorResult.Status > 0 && vendorResult.Result.Data != null)
            {
                return (Vendor)vendorResult.Result.Data;
            }
            Message = "Vendor Not Exist!!";
            return null;
        }

        public string GetWelcomeMsg()
        {
            return "Welcome to the Razor Page Web Application";
        }
    }
}
