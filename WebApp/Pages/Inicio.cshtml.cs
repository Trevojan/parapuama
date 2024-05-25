using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class InicioModel : PageModel
    {
        private readonly ILogger<InicioModel> _logger;

        public InicioModel(ILogger<InicioModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
