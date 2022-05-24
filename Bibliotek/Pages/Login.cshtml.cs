using Bibliotek.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Bibliotek.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signMeBitch;
        public LoginModel(SignInManager<IdentityUser> signMeBitch) {_signMeBitch = signMeBitch;}

        public string UserName { get; set; }
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var result = await _signMeBitch.PasswordSignInAsync(UserName, Password, false, false);

                if (result.Succeeded)
                {
                    TempData["success"] = "Successfully logged in";
                    return RedirectToPage("/Index");
                }
            }
            TempData["fail"] = "Controll your input and try again";
            return Page();
        }
    }
}
