using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
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
            if (!@out.CallDoLogin(Login, Senha))
            {
                Partial("../Pages/Entrar/_ModalEntrar");
                return Page();
            }
            return RedirectToPage("../Portfolio/Portfolio");
        }
    }
}