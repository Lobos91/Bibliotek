namespace Bibliotek.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
        public List<BookModel>? LentBooks { get; set; }
        public List<EBookModel>? LentEbooks { get; set; }
        public List<MovieModel>? LentMovies { get; set; }

    }

    public enum Role
    {
        User,
        Admin,
        SuperAdmin
    }



}
