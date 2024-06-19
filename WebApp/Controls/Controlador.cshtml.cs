using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Database;
using WebApp.Pages;

namespace WebApp.Controls
{
    public class Controlador : Controller
    {
        
        public void ForwardUsuario(string lo, string se1, string se2, string em, string ap)
        {
            Out output = new();
            In input = new();
            ap ??= lo;

            bool checkSe = output.CallPassword(se1, se2);
            if (!checkSe)
            {
                bool checkLo = output.CallUniqueLogin(lo);
                Console.WriteLine("Chamou o login");
                Console.WriteLine("Login: " + lo);
                if (!checkLo)
                {
                    bool checkEm = output.CallUniqueEmail(em);
                    Console.WriteLine("Chamou o e-mail");
                    if (!checkEm)
                    {
                        bool checkAp = output.CallUniqueApelido(ap);
                        Console.WriteLine("Chamou o apelido");
                        if (!checkAp)
                        {
                            input.NovoUsuario(lo, se1, em, ap);
                        }
                    }
                }
            }
        }

        /*public void ForwardProjeto(string lo, string se, string ap)
{
    In input = new();
    input.NovoUsuario(lo, se, ap);
}*/
    }
}