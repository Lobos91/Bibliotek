using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public SignUpModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> usermanager)
        {
            _signInManager = signInManager;
            _userManager = usermanager;
        }

        [BindProperty]
        public SignupModel Signup { get; set; }
        public UserModel NewUser { get; set; } = new();

        //testy
        public ApiManager apiManager { get; set; }

     

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IdentityUser newuser = new IdentityUser();
                newuser.UserName = NewUser.UserName = Signup.Username;
                newuser.Email = Signup.Email;
              
                apiManager = new();
                var users = await apiManager.GetUsers();

                IdentityResult registration = await _userManager.CreateAsync(newuser, Signup.Password);

                if (registration.Succeeded)
                {
                    if (!users.Any())
                    {
                        NewUser.Role = Role.SuperAdmin;
                    }
                    else 
                    {
                        NewUser.Role = Role.User; 
                    }

                    await apiManager.PostUser(NewUser);

                    await _signInManager.PasswordSignInAsync(newuser, Signup.Password, false, false);

                    TempData["success"] = "Account successfully created";
                    return RedirectToPage("/Index");
                }

            }
            
            TempData["fail"] = "Application was unable to create account. Please try again.";
            return Page();

        }
    }

}

