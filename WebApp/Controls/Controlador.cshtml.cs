using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Controls
{
    public class Controlador : PageModel
    {
        public Controlador(ILogger<Controlador> logger) => _logger = logger;
        private readonly ILogger<Controlador> _logger;

        public string TituloEscopo(string t)
        {
            switch (t)
            {
                case "devsoft":
                    t = "Desenvolvimento de Software";
                    break;
                case "palestra":
                    t = "Palestra ao Vivo";
                    break;
                case "market":
                    t = "Campanha de Marketing";
                    break;
                case "aula":
                    t = "Sala de Aula";
                    break;
                case "stats":
                    t = "Apresentação de Estatísticas";
                    break;
            }
            return t;
        }

        public string ConteudoEscopo(string t)
        {
            switch (t)
            {
                case "devsoft":
                    t = "Um projeto com quadro para brainstorming seguido da organização da equipe. Feito para um início rápido e interação contínua entre os membros da equipe.";
                    break;
                case "palestra":
                    t = "Quadros organizados para acelerar o processo base de uma palestra ao vivo, com aquecimento, roteiro e score de apresentação.";
                    break;
                case "market":
                    t = "Escopo feito para organizar sua campanha de marketing a longo prazo, com todos os detalhes necessários.";
                    break;
                case "aula":
                    t = "Monte sua aula a partir dos quadros iniciais e desenvolva seu material ao longo do prazo estipulado.";
                    break;
                case "stats":
                    t = "Para apresentações de negócios, com design minimalista e direto. Gráficos e dados podem ser acessados com praticidade.";
                    break;
            }
            return t;
        }


    }
}