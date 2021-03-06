using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages.Kalender
{
    public class CreateModel : PageModel
    {
       [BindProperty] public KalenderModel NewEvent { get; set; } = new();
        public ApiManager apiManager { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            await apiManager.CreateEvent(NewEvent);
            return RedirectToPage("/Kalender/Index");
        }
    }
}
