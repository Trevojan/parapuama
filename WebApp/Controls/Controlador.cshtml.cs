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
                    t = "Apresenta��o de Estat�sticas";
                    break;
            }
            return t;
        }

        public string ConteudoEscopo(string t)
        {
            switch (t)
            {
                case "devsoft":
                    t = "Um projeto com quadro para brainstorming seguido da organiza��o da equipe. Feito para um in�cio r�pido e intera��o cont�nua entre os membros da equipe.";
                    break;
                case "palestra":
                    t = "Quadros organizados para acelerar o processo base de uma palestra ao vivo, com aquecimento, roteiro e score de apresenta��o.";
                    break;
                case "market":
                    t = "Escopo feito para organizar sua campanha de marketing a longo prazo, com todos os detalhes necess�rios.";
                    break;
                case "aula":
                    t = "Monte sua aula a partir dos quadros iniciais e desenvolva seu material ao longo do prazo estipulado.";
                    break;
                case "stats":
                    t = "Para apresenta��es de neg�cios, com design minimalista e direto. Gr�ficos e dados podem ser acessados com praticidade.";
                    break;
            }
            return t;
        }


    }
}