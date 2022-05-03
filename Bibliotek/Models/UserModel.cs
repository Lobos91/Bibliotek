namespace Bibliotek.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<BookModel> LentBooks { get; set; }
    }

    public enum Role
    {
        User,
        Admin,
        SuperAdmin
    }
}
