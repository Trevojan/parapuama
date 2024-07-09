using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controls
{
    public class ControlInicio : Controller
    {
        [BindProperty]
        public int Id { get; set; }

        public IActionResult Index()
        {
            Id = 0;
            return View();
        }
    }
}
