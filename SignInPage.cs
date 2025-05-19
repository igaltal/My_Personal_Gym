using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using NewGymIgalTalProject.App_Code;

namespace NewGymIgalTalProject.Pages
{
    public class SignInPageModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Username and password are required";
                return Page();
            }

            // Use the UserService to validate login
            var userService = new UserService();
            var user = userService.ValidateUser(Username, Password);

            if (user != null)
            {
                // Set session or cookie for user authentication
                return RedirectToPage("/Home");
            }
            else
            {
                ErrorMessage = "Invalid username or password";
                return Page();
            }
        }
    }
}
