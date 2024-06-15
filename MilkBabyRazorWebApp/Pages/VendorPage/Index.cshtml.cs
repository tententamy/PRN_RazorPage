using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkBabyBusiness.Category;
using MilkBabyData.Models;
using MilkBabyData.Repository;

namespace MilkBabyRazorWebApp.Pages.VendorPage
{
	public class IndexModel : PageModel
	{
		//  private readonly MilkBabyData.Models.Net1702Prn221MilkBabyContext _context;
		private readonly IVendorBusiness _VendorBusiness;




		public IndexModel()
		{
			_VendorBusiness ??= new VendorBusiness();
		}


		//   public IList<Vendor> Vendor { get; set; } = default!;
		public IList<Vendor> Vendor { get; set; } = new List<Vendor>();


		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }



		public async Task OnGetAsync()
		{
			if (string.IsNullOrEmpty(SearchTerm))
			{
				await LoadVendorAsync();
			}
			else
			{
				await SearchVendorsAsync(SearchTerm);
			}
		}

		private async Task LoadVendorAsync()
		{
			var result = await _VendorBusiness.GetAll();
			if (result != null && result.Status > 0 && result.Data != null)
			{
				Vendor = result.Data as List<Vendor>;
				  foreach (var item in Vendor)
				{
					await LoadAssociatedData(item);
				}
			}
		}

		private async Task SearchVendorsAsync(string searchTerm)
		{
			var result = await _VendorBusiness.Search(searchTerm);
			if (result != null && result.Status > 0 && result.Data != null)
			{
				Vendor = result.Data as List<Vendor>;
				foreach (var item in Vendor)
				{
					await LoadAssociatedData(item);
				}
			}
		}

		private async Task LoadAssociatedData(Vendor vendor)
		{
			var vendorResult = await _VendorBusiness.GetById((Guid)vendor.VendorId);


			if (vendorResult != null && vendorResult.Data != null)
			{
				vendor = vendorResult.Data as Vendor;

			}

		}

		//public void OnGet()
		//      {
		//          Vendor = (IList<Vendor>)vendorRepository.SearchAsync(SearchTerm);



		//}

		//public async Task OnGetAsync()
		//{
		//    var result = await business.GetAll();
		//    if (result != null && result.Status > 0 && result.Data != null)
		//    {
		//        Vendor = result.Data as IList<Vendor>;
		//    }

		//}


	}
}