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

		private readonly IVendorBusiness _VendorBusiness;

		public IndexModel()
		{
			_VendorBusiness ??= new VendorBusiness();
		}
		public IList<Vendor> Vendor { get; set; } = default!;

		[BindProperty(SupportsGet = true)]
		public string SearchName { get; set; } = default!;


		[BindProperty(SupportsGet = true)]
		public string SearchCP { get; set; } = default!;


		[BindProperty(SupportsGet = true)]
		public string SearchWeb { get; set; } = default!;


		[BindProperty(SupportsGet = true)]
		public int PageNumber { get; set; } = 1;

		public int PageSize { get; set; } = 3;

		public int TotalPages { get; set; }

		public async Task OnGetAsync()
		{

			if (SearchName == null && SearchCP == null && SearchWeb == null)
			{
				var result = await _VendorBusiness.GetAll();
				if (result != null && result.Status > 0 && result.Data != null)
				{
					Vendor = result.Data as List<Vendor>;
					TotalPages = (int)Math.Ceiling(Vendor.Count / (double)PageSize);
					Vendor = Vendor.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
				}
			}
			else
			{
				var result = await _VendorBusiness.Search(SearchName, SearchCP, SearchWeb);
				if (result != null && result.Status > 0 && result.Data != null)
				{
					Vendor = result.Data as List<Vendor>;
					TotalPages = (int)Math.Ceiling(Vendor.Count / (double)PageSize);
					Vendor = Vendor.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();

				}
			}

		}

	}
}
