using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages
{
    public class AddAdminModel : PageModel
    {
        public ApiManager apiManager { get; set; } = new();
        public List<UserModel> Users { get; set; } = new();
        [BindProperty] public UserModel User { get; set; }
        public async Task OnGet()
        {
            Users = await apiManager.GetUsers();
        }

        public async Task<IActionResult> OnPostAdmin()
        {
            User.Role = Role.Admin;
            await apiManager.UpdateUser(User);

            return RedirectToPage("/AddAdmin");
        }

        public async Task<IActionResult> OnPostUser(int id)
        {
            User.Role = Role.User;
            await apiManager.UpdateUser(User);

            return RedirectToPage("/AddAdmin");
        }
    }
}
