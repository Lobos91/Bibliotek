using Bibliotek.Data;
using Bibliotek.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bibliotek.Pages
{
    public class RentProductModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public RentProductModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty] public ProductModel ProductToBorrow { get; set; } = new();
        public List<ProductModel> UserProducts { get; set; } = new();
        [BindProperty] public List<ProductModel> AllProducts { get; set; } = new();

        public DateSelector dateSelector { get; set; } = new();
        [BindProperty] public UserModel User { get; set; } = new();



        public IEnumerable<SelectListItem> Days { get; set; } 
        public ApiManager apiManager { get; set; } = new();


        public async Task<IActionResult> OnGetProduct(int id)
        {
            var currentUser = await _signInManager.UserManager.GetUserAsync(HttpContext.User);
            var users = await apiManager.GetUsers();
            User = users.FirstOrDefault(u => u.UserName == currentUser.UserName);

            AllProducts = await apiManager.GetProducts();
            UserProducts = AllProducts.Where(x => x.Lent).Where(p => p.UserId == User.Id).ToList();

             ProductToBorrow = AllProducts[id - 1];

            Days = dateSelector.OptionListDays();



            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //update product
            ProductToBorrow.Lent = true;
            ProductToBorrow.LoanDateTimeStart = DateTime.Now;
            Convert.ToDateTime(ProductToBorrow.LoanDateTimeEnd);

            ProductToBorrow.UserId = User.Id;
       

            if (ModelState.IsValid)
            {
                await apiManager.UpdateProduct(ProductToBorrow);
                TempData["success"] = "Product has been succesfully booked.";
            }

            return RedirectToPage("/Search");
        }


        //Reset product (just for tests)
        public async Task<IActionResult> OnPostReset()
        {
            AllProducts = await apiManager.GetProducts();
         
            foreach (var prod in AllProducts)
            {
                prod.UserId = null;
                prod.Lent = false;
                prod.LoanDateTimeEnd = null;
                prod.LoanDateTimeStart = null;
            }

            await apiManager.ResetProducts(AllProducts);
            return RedirectToPage("/Search");


        }
    }
}
