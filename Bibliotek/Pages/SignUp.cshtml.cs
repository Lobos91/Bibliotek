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
        public UserModel User { get; set; } = new();

        //testy
        public List<UserModel> Users { get; set; } = new();
        public ApiManager apiManager { get; set; }

        public async Task OnGet()
        {
            
            //Users = await apiManager.GetUsers();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IdentityUser newuser = new IdentityUser();
                newuser.UserName = User.UserName = Signup.Username;
                newuser.Email = Signup.Email;
                //newuser.Email = Signup.Email;
                apiManager = new();
                var users = await apiManager.GetUsers();

                IdentityResult registration = await _userManager.CreateAsync(newuser, Signup.Password);

                if (registration.Succeeded)
                {
                    if (!users.Any())
                    {
                        User.Role = Role.SuperAdmin;
                    }

                    await apiManager.PostUser(User);

                    await _signInManager.PasswordSignInAsync(newuser, Signup.Password, false, false);

                }

            }

            return RedirectToPage("/Index");

        }
    }

}

