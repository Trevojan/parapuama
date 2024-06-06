using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginModel(IHttpContextAccessor httpContextAccessor)
        { _httpContextAccessor = httpContextAccessor; }

        List<int> Session = new List<int>();
        public bool GetLogin(string l, string p)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"SELECT idUsuario FROM tbUsuarios WHERE {l} = colLogin AND {p} = colSenha";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();

                    Session.Add(reader.GetInt32(0));

                    if (reader.Read())
                    { return true; }
                    return false;
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public object CheckLogin(int id)
        {
            if (Session.Contains(id))
            {

            }

            return 0;
        }
    }
}

