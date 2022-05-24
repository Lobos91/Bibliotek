using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace Bibliotek.Pages
{
    public class SearchModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public SearchModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty(SupportsGet = true)] public string? SearchKey { get; set; } = string.Empty;
        public ApiManager apiManager { get; set; } = new();
        public List<ProductModel> Products { get; set; } = new();
        public UserModel LoggedUser { get; set; } = new();

        public async Task OnGet()
        {
            if(_signInManager.IsSignedIn(User))
            {
                var currentUser = await _signInManager.UserManager.GetUserAsync(HttpContext.User);
                var users = await apiManager.GetUsers();
                LoggedUser = users.FirstOrDefault(u => u.UserName == currentUser.UserName);
            }
               
            

            if (string.IsNullOrEmpty(SearchKey))
            {
                // return all or null
                Products = await apiManager.GetProducts();
            }
            else
            {
                var allObjects = await apiManager.GetProducts();
                Products = allObjects.Where(x => x.Release.Title.Contains(SearchKey, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
        }
    }
}
