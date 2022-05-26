using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bibliotek.Pages
{
    public class RentProductModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public RentProductModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public ProductModel ProductToBorrow { get; set; } = new();
        public List<ProductModel> UserProducts { get; set; } = new();
        public List<SelectListItem> Days { get; set; } = new();
        public ApiManager apiManager { get; set; } = new();


        public async Task<IActionResult> OnGetProduct(int id)
        {
            var currentUser = await _signInManager.UserManager.GetUserAsync(HttpContext.User);
            var users = await apiManager.GetUsers();
            var user = users.FirstOrDefault(u => u.UserName == currentUser.UserName);

            var products = await apiManager.GetProducts();
            UserProducts = products.Where(x => x.Lent).Where(u => u.Id == user.Id).ToList();

            ProductToBorrow = products[id];

            Days.Add(new SelectListItem() { Text = "Choose your period", Disabled = true });
            Days.Add(new SelectListItem() { Text = "7 Days" , Value = "1"});
            Days.Add(new SelectListItem() { Text = "14 Days", Value = "2" });
            Days.Add(new SelectListItem() { Text = "30 Days", Value = "3" });


            return Page();
        }
    }
}
