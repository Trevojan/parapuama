using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public required string NmEmail { get; set; }
        [BindProperty]
        public required string NmApelido { get; set; }
    }
}
