using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApp.Database;

namespace WebApp.Models
{
    public class ModelNovaConta : PageModel
    {
        [BindProperty]
        public required string NmLogin { get; set; }
        [BindProperty]
        public required string NmSenha1 { get; set; }
        [BindProperty]
        public required string NmSenha2 { get; set; }
        [BindProperty]
        [EmailAddress]
        public required string NmEmail { get; set; }
        [BindProperty]
        public required string NmApelido { get; set; }

        public IActionResult OnPost()
        {
            Gather g = new();

            if(g.ForwardUsuario(NmLogin, NmSenha1, NmSenha2, NmEmail, NmApelido))
            {
                return RedirectToPage("../Entrar/Login");
            }

            return Page();
        }
    }
}
