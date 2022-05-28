using Bibliotek.Models;

namespace Bibliotek.Data
{
    public static class KalenderManager
    {
        public static List<KalenderModel> Events;

        public static List<KalenderModel> GetEvents()
        {
            if (Events == null || !Events.Any())
            {
                Events = new List<KalenderModel>()
                {

                new KalenderModel()
                {
                    Id = 1,
                    Date = new DateTime(2022, 05, 28),
                    Headline = "Grand Opening!",
                    Message = "We are proud to announce opening of our library on June 9! " +
                    "\nRegistering in our library allow you to borrow materials that are divided into 3 different categories: Books, E-books and Movies. " +
                    "\nFurthermore from time to time we will announce various interesting and valuable events, so chceck this page frequently! \nWelcome!"
                }
                };
            }
            return Events;
        }

        public static void UpdateEvent(KalenderModel Event)
        {
            if(Event != null)
            {
                int index = Events.IndexOf(Events.Where(ev => ev.Id == Event.Id).FirstOrDefault());

                Events[index].Headline = Event.Headline;
                Events[index].Message = Event.Message;
            }
        }

        public static void RemoveEvent(KalenderModel Event)
        {
            if (Event != null)
            {
                int index = Events.IndexOf(Events.Where(ev => ev.Id == Event.Id).FirstOrDefault());

                Events.RemoveAt(index);
            }
        }
    }
}
