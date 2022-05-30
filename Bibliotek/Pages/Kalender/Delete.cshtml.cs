using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages.Kalender
{
    public class DeleteModel : PageModel
    {
        [BindProperty] public KalenderModel EventToDelete { get; set; } = new();
        public ApiManager apiManager { get; set; } = new();
        public string Header { get; set; }
        public string Message { get; set; }

        public async Task OnGet(int id)
        {
            var allEvents = await apiManager.GetEvents();
            EventToDelete = allEvents.FirstOrDefault(ev => ev.Id == id);

        }
        public async Task<IActionResult> OnPost()
        {
            await apiManager.DeleteEvent(EventToDelete.Id);
            return RedirectToPage("/Kalender/Index");
        }

    }
}
