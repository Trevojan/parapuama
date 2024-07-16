using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Models
{
    public class ModelProjetos : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public int? Proj { get; set; }

        public void OnGet(int id, int proj)
        {
            Id = id;
            Proj = proj;
            if (Proj == 0)
            {

                //Forward
            }
        }
    }
}