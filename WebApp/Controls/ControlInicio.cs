using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controls
{
    public class ControlInicio : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
