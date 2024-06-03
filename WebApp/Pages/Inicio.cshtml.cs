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

        private class Escopos()
        {
            public String TituloEscopo(string t)
            {
                switch (t)
                {
                    case "devsoft":
                        return "a";
                    case "palestra":
                        return "s";
                    case "market":
                        return "d";
                    case "aula":
                        return "f";
                    case "stats":
                        return "g";
                }
                return "";
            }

            public String ConteudoEscopo(String t)
            {
                switch (t)
                {
                    case "devsoft":
                        return "a";
                    case "palestra":
                        return "s";
                    case "market":
                        return "d";
                    case "aula":
                        return "f";
                    case "stats":
                        return "g";
                }
                return "";
            }
        }
    }
}
