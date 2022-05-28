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
        public int ID { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }

        public void OnGet(int id)
        {
        
            EditedEvent = KalenderManager.GetEvents().FirstOrDefault(e => e.Id == id);
        }

        public IActionResult OnPost()
        {
            EditedEvent.Id = ID;
            EditedEvent.Headline = Header;
            EditedEvent.Message = Message;
            KalenderManager.UpdateEvent(EditedEvent);
            return RedirectToPage("/Kalender/Index");
        }
    }
}
