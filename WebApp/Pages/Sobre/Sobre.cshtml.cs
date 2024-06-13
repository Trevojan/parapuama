using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class SobreModel : PageModel
    {
        private readonly ILogger<SobreModel> _logger;

        public SobreModel(ILogger<SobreModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
