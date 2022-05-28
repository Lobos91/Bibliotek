using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bibliotek.Pages.Kalender
{
    public class DeleteModel : PageModel
    {
        [BindProperty] public KalenderModel EventToDelete { get; set; } = new();
        public int ID { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }

        public void OnGet(int id)
        {

            EventToDelete = KalenderManager.GetEvents().FirstOrDefault(e => e.Id == id);
        }
        public IActionResult OnPost()
        {
            KalenderManager.RemoveEvent(EventToDelete);
            return RedirectToPage("/Kalender/Index");
        }

    }
}
