using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

    public string TituloEscopo(string t)
    {
        switch (t)
        {
            case "devsoft":
                t = "a";
            break;
            case "palestra":
                t = "s";
            break;
            case "market":
                t = "d";
            break;
            case "aula":
                t = "f";
            break;
            case "stats":
                t = "g";
            break;
        }
        return t;
    }

        public string ConteudoEscopo(string t)
        {
            switch (t)
            {
                case "devsoft":
                    t = "hcjhgc";
                    break;
                case "palestra":
                    t = "jhgcjhgcs";
                    break;
                case "market":
                    t = "djhcjhgchjgc";
                    break;
                case "aula":
                    t = "fjhgcjhgcjhgcjhgc";
                    break;
                case "stats":
                    t = "ghjcjhgcjhgcjhgcjhgcjhgc";
                    break;
            }
            return t;
        }


    }
    }