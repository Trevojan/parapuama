using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Models
{
    public class ModelLogin : PageModel
    {
        [BindProperty]
        public required string Login { get; set; }

        [BindProperty]
        public required string Senha { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                
                return new JsonResult(new { loginfail = true });
            }
            return RedirectToPage("/portfolio");
        }
    }
}