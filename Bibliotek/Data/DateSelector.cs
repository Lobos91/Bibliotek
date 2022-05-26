using Bibliotek.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bibliotek.Data
{
    public class DateSelector
    {
     
        public List<SelectListItem> OptionListDays()
        {
            var LoanStart = DateTime.Now;
      

            List<SelectListItem> days = new List<SelectListItem>();
            days.Add(new SelectListItem { Value = LoanStart.AddDays(7).ToString(), Text = "7 days" });
            days.Add(new SelectListItem { Value = LoanStart.AddDays(14).ToString(), Text = "14 days" });
            days.Add(new SelectListItem { Value = LoanStart.AddDays(30).ToString(), Text = "30 days" });

            return days;
        }
    }
}
