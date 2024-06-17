using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Database;
using WebApp.Pages;

namespace WebApp.Controls
{
    public class Controlador : PageModel
    {
        public string NmLogin { get; set; }
        public string NmSenha1 { get; set; }
        public string NmSenha2 { get; set; }
        public string NmEmail { get; set; }
        public string NmApelido { get; set; }

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

        public string ConteudoEscopo(string c)
        {
            switch (c)
            {
                case "devsoft":
                    c = "Um projeto com quadro para brainstorming seguido da organização da equipe. Feito para um início rápido e interação contínua entre os membros da equipe.";
                    break;
                case "palestra":
                    c = "Quadros organizados para acelerar o processo base de uma palestra ao vivo, com aquecimento, roteiro e score de apresentação.";
                    break;
                case "market":
                    c = "Escopo feito para organizar sua campanha de marketing a longo prazo, com todos os detalhes necessários.";
                    break;
                case "aula":
                    c = "Monte sua aula a partir dos quadros iniciais e desenvolva seu material ao longo do prazo estipulado.";
                    break;
                case "stats":
                    c = "Para apresentações de negócios, com design minimalista e direto. Gráficos e dados podem ser acessados com praticidade.";
                    break;
            }
            return c;
        }

        public string ConteudoNovidade(string t)
        {
            switch(t)
            {
                case "boasvindas":
                    return "";
                case "futuro":
                    return t;
                case "prototipo":
                    return "Bom dia, planejadores! As ideias do protótipo estão fervilhando e logo logo terão resultado. Fiquem atentos para testar o site assim que o lançamento ocorrer 10 de julho!";
                case "design":
                    return "Bom dia, exploradores! Gostaria de compartilhar algo sobre as ideias de design. Primeiramente, bordas em azul e todo o tema remetendo a água está diretamente ligado ao título, mas isto está para mudar! Futuramente, amarelo e verde estão para chegar.";
                case "lancamento":
                    return "Bom dia, visitantes! Espero que vossas expectativas sejam tão grandes quanto as minhas. O desenvolvimento do Parapuãma está em andamento há poucos dias, mas conforme o projeto avança, posso confirmar que caminhamos apra um site completo com muitas funcionalidades a serem exploradas. Acompanhem as atualizações por aqui!";
            }
            return t;
        }
        
        public string TituloNovidade(string c)
        {

            switch (c)
            {
                case "boasvindas":
                    return "Boas-vindas!";
                case "futuro":
                    return "Onde deságua esse rio?";
                case "prototipo":
                    return "Protótipo";
                case "design":
                    return "Insights de desenvolvimento!";
                case "lancamento":
                    return "Data de lançamento anunciada!";
            }
            return c;
        }

        public string SubNovidade(string s)
        {
            switch (s)
            {
                case "boasvindas":
                    return "app está no ar em você pode senti-lo";
                case "futuro":
                    return "o que espero com o projeto e além";
                case "prototipo":
                    return "começa a tomar forma";
                case "design":
                    return "novos estilos estão por vir";
                case "lancamento":
                    return "web app estará disponível no final do 1º semestre de 2024";
                default:
                    break;
            }
            return s;
        }

        public void ForwardUsuario(string lo, string se, string em, string ap)
        {
            In input = new();
            if (ap == null)
            {
                ap = lo;
                input.NovoUsuario(lo, se, em, ap);
            }
            else
            {
                input.NovoUsuario(lo, se, em, ap);
            }
        }

        /*public void ForwardProjeto(string lo, string se, string ap)
{
    In input = new();
    input.NovoUsuario(lo, se, ap);
}*/
    }
}