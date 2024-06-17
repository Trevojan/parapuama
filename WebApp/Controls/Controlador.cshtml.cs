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
                    t = "Apresenta��o de Estat�sticas";
                    break;
            }
            return t;
        }

        public string ConteudoEscopo(string c)
        {
            switch (c)
            {
                case "devsoft":
                    c = "Um projeto com quadro para brainstorming seguido da organiza��o da equipe. Feito para um in�cio r�pido e intera��o cont�nua entre os membros da equipe.";
                    break;
                case "palestra":
                    c = "Quadros organizados para acelerar o processo base de uma palestra ao vivo, com aquecimento, roteiro e score de apresenta��o.";
                    break;
                case "market":
                    c = "Escopo feito para organizar sua campanha de marketing a longo prazo, com todos os detalhes necess�rios.";
                    break;
                case "aula":
                    c = "Monte sua aula a partir dos quadros iniciais e desenvolva seu material ao longo do prazo estipulado.";
                    break;
                case "stats":
                    c = "Para apresenta��es de neg�cios, com design minimalista e direto. Gr�ficos e dados podem ser acessados com praticidade.";
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
                    return "Bom dia, planejadores! As ideias do prot�tipo est�o fervilhando e logo logo ter�o resultado. Fiquem atentos para testar o site assim que o lan�amento ocorrer 10 de julho!";
                case "design":
                    return "Bom dia, exploradores! Gostaria de compartilhar algo sobre as ideias de design. Primeiramente, bordas em azul e todo o tema remetendo a �gua est� diretamente ligado ao t�tulo, mas isto est� para mudar! Futuramente, amarelo e verde est�o para chegar.";
                case "lancamento":
                    return "Bom dia, visitantes! Espero que vossas expectativas sejam t�o grandes quanto as minhas. O desenvolvimento do Parapu�ma est� em andamento h� poucos dias, mas conforme o projeto avan�a, posso confirmar que caminhamos apra um site completo com muitas funcionalidades a serem exploradas. Acompanhem as atualiza��es por aqui!";
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
                    return "Onde des�gua esse rio?";
                case "prototipo":
                    return "Prot�tipo";
                case "design":
                    return "Insights de desenvolvimento!";
                case "lancamento":
                    return "Data de lan�amento anunciada!";
            }
            return c;
        }

        public string SubNovidade(string s)
        {
            switch (s)
            {
                case "boasvindas":
                    return "app est� no ar em voc� pode senti-lo";
                case "futuro":
                    return "o que espero com o projeto e al�m";
                case "prototipo":
                    return "come�a a tomar forma";
                case "design":
                    return "novos estilos est�o por vir";
                case "lancamento":
                    return "web app estar� dispon�vel no final do 1� semestre de 2024";
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