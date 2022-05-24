namespace Bibliotek.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }

        public List<ProductModel>? Products { get; set; }

    }

    public enum Role
    {
        Visitor, //Visitor role, needed in order to avoid User role to be default/false one.
        User,
        Admin,
        SuperAdmin
    }



}
