using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Models
{
    public class ModelLogin : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public required string Login { get; set; }
        [BindProperty]
        public required string Senha { get; set; }

        public IActionResult OnPost()
        {
            Database.Out @out = new();
            int id;
            bool redr = @out.CallDoLogin(Login, Senha, out id);
            Id = id;
            switch (redr)
            {
                case true:
                    return RedirectToPage($"../Portfolio/portfolio", new { id = Id });
                case false:
                    return RedirectToPage("./LoginErro");
            }
        }
    }
}