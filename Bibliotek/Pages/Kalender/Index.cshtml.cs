using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages.Kalender
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public IndexModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public List<KalenderModel> Events { get; set; } = new();
        public UserModel LoggedUser { get; set; } = new();
        public ApiManager apiManager { get; set; } = new();
        public async Task OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var currentUser = await _signInManager.UserManager.GetUserAsync(HttpContext.User);
                var users = await apiManager.GetUsers();
                LoggedUser = users.FirstOrDefault(u => u.UserName == currentUser.UserName);
            }

            Events = await apiManager.GetEvents();
          
        }
    }
}
