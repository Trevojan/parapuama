using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controls
{
    public class ControlLogin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
