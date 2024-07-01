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
            Database.Out @out = new();
            bool redr = @out.CallDoLogin(Login, Senha);
            switch (redr)
            {
                case true:
                    return RedirectToPage("../Portfolio/Portfolio");
                case false:
                    return RedirectToPage("./LoginErro");
            }
        }
    }
}