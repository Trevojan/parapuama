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

        public void OnPost()
        {
            Database.Out @out = new();
            if (@out.CallDoLogin(Login, Senha))
            {
                RedirectToPage("../Portfolio/Portfolio");
            }
        }
    }
}