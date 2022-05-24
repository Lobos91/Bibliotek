using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bibliotek.Pages
{
    public class SearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public string? SearchKey { get; set; } = string.Empty;
        public ApiManager apiManager { get; set; }

        public List<ProductModel> Products { get; set; } = new();

        public async Task OnGet()
        {
            apiManager = new();
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
