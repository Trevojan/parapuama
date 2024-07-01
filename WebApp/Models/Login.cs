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
            int callId = @out.CallDoLogin(Login, Senha);
            if (callId != 0)
            {
                @out.Id = callId;
                RedirectToPage("../Portfolio/Portfolio");
            }
        }
    }
}