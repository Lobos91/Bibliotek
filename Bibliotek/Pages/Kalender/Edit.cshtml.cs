using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages.Kalender
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public KalenderModel EditedEvent { get; set; } = new();
        public ApiManager apiManager { get; set; } = new();

        public int ID { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }

        public async Task OnGet(int id)
        {
            var allEvents = await apiManager.GetEvents();
            EditedEvent = allEvents.FirstOrDefault(ev => ev.Id == id);
           
        }

        public async Task<IActionResult> OnPost()
        {
            EditedEvent.Headline = Header;
            EditedEvent.Message = Message;

            await apiManager.UpdateEvent(EditedEvent);
            return RedirectToPage("/Kalender/Index");
        }
    }
}
