using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages
{
    public class SearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public string? SearchKey { get; set; } = string.Empty;

        public void OnGet()
        {

            if (string.IsNullOrEmpty(SearchKey))
            {
               // return all or null
            }
            else
            {
                // var allObjects = await apiManager.ReturnAllObjects();
                // Objects = allObjects.Where(x => x.Name.Contains(SearchKey, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
        }
    }
}
