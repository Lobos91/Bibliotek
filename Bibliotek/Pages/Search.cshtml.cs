using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages
{
    public class SearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public string? SearchKey { get; set; } = string.Empty;
        public ApiManager apiManager { get; set; }
        //public List<BookModel> Books { get; set; } = new();
        //public List<MovieModel> Movies { get; set; } = new();

     

        public async Task OnGet()
        {

        

            if (string.IsNullOrEmpty(SearchKey))
            {
                // return all or null
                apiManager = new();
                //Books = await apiManager.GetBooks();
                //Movies = await apiManager.GetMovies();

            }
            else
            {
                // var allObjects = await apiManager.ReturnAllObjects();
                // Objects = allObjects.Where(x => x.Name.Contains(SearchKey, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
        }
    }
}
