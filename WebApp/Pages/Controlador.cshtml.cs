using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Common;

namespace WebApp.Pages
{
    public class InicioModel : PageModel
    {
        public InicioModel(ILogger<InicioModel> logger) => _logger = logger;
        private readonly ILogger<InicioModel> _logger;

        //"Server=.;Database=dbParapuama;Trusted_Connection=True;"


        


        public void OnGet() { }

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

        public static void Initialize(IServiceProvider serviceProvider)
        {
            /*var dados = new DbContext.();
            if (context.Cargos.Any())
            {
                return;
            }
            else
            {
                context.Cargos.AddRange(
                    new
                    {
                        colNome = "Líder de Projeto",
                        colCor = "Dourado"
                    },
                    new
                    {
                        colNome = "Líder de Design",
                        colCor = "Roxo"
                    },
                    new
                    {
                        colNome = "Líder de Desenvolvimento",
                        colCor = "Azul"
                    },
                    new
                    {
                        colNome = "Observador",
                        colCor = "Verde"
                    },
                    new
                    {
                        colNome = "Designer",
                        colCor = "Azul"
                    },
                    new
                    {
                        colNome = "Agilizador",
                        colCor = "Laranja"
                    },
                    new
                    {
                        colNome = "Cliente",
                        colCor = "Branco"
                    }
                );
                context.SaveChanges();
            }*/
        }
    }   
}