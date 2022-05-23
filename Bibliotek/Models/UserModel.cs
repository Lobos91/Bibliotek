namespace Bibliotek.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }

        public List<ProductModel> Products { get; set; }

    }

    public enum Role
    {
        User,
        Admin,
        SuperAdmin
    }



}
