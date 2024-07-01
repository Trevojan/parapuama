using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controls
{
    public class ControlNovaConta : Controller
    {
        [HttpPost]
        public IActionResult OnPost(ModelNovaConta m)
        {
            Database.Gather g = new();

            if (m.NmLogin != null)
            {
                string lo = m.NmLogin;
                if (m.NmSenha1 != null)
                {
                    string se1 = m.NmSenha1;
                    if (m.NmSenha2 != null)
                    {
                        string se2 = m.NmSenha2;
                        if (m.NmEmail != null)
                        {
                            string em = m.NmEmail;
                            if (m.NmApelido != null)
                            {
                                string ap = m.NmApelido;
                                Console.WriteLine($"lo = {lo}, se = {se1}, em = {em}, ap = {ap}");
                                g.ForwardUsuario(lo, se1, se2, em, ap);
                                return RedirectToRoute("/login");
                            }
                        }
                    }
                }
            }
            return RedirectToRoute("/");
        }
    }
}
