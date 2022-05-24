using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPost(bool logMeOut)
        {
            if (logMeOut)
            {
                await _signInManager.SignOutAsync();
                TempData["success"] = "Successfully logged out";
               
            }

            return RedirectToPage("/Index");


        }
    }
}
