using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages
{
    public class rapportModel : PageModel
    {
        public ApiManager apiManager { get; set; } = new ApiManager();
        public List<UserModel> Users { get; set; } = new();
        public List<ProductModel> Products { get; set; } = new();
        public async Task OnGet()
        {   

            var allUsers = await apiManager.GetUsers();
            Users = allUsers.Where(u => u.Products.Count >= 1).ToList();

           var allProducts = await apiManager.GetProducts();
           Products = allProducts.Where(x => x.Lent).ToList();
          

        }
    }
}
