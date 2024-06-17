using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MilkBabyRazorWebApp.Pages.Login
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string username, string password)
        {
            if (username == "Admin" && password == "123")
            {
                HttpContext.Session.SetString("User", "Admin");
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return Page();
        }
    }
}
