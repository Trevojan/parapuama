using Microsoft.AspNetCore.Html;
using Microsoft.Data.SqlClient;

namespace WebApp.Database
{
    public class Gather
    {
        public string Forward(String read)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = read;
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                { return "Database found"; }
                return read;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public bool ForwardUsuario(string lo, string se1, string se2, string em, string ap)
        {
            Console.WriteLine("Forwarded: Usuário");
            Out @out = new();
            In @in = new();
            ap ??= lo;

            bool checkSe = @out.CallPassword(se1, se2);
            if (!checkSe)
            {
                bool checkLo = @out.CallUniqueLogin(lo);
                Console.WriteLine("Chamou o login");
                Console.WriteLine("Login: " + lo);
                if (checkLo)
                {
                    bool checkEm = @out.CallUniqueEmail(em);
                    Console.WriteLine("Chamou o e-mail");
                    if (checkEm)
                    {
                        bool checkAp = @out.CallUniqueApelido(ap);
                        Console.WriteLine("Chamou o apelido");
                        if (checkAp)
                        {
                            return @in.NovoUsuario(lo, se1, em, ap);
                        }
                    }
                }
            }
            return false;
        }

        public void ForwardOnline()
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = "SELECT * FROM tbOnline";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Out @out = new();
                    object[] vals = new object[reader.FieldCount];
                    reader.GetValues(vals);

                    foreach (object val in vals)
                    {
                        if (val != null)
                        {
                            @out.Session.Add(Convert.ToInt32(val));
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public HtmlString ForwardFavoritos(int id)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = "SELECT tbProjetos.colNome,tbProjetos.colEscopo,tbUsuarios.colApelido " +
                               "FROM tbFavoritos " +
                               "INNER JOIN tbProjetos " +
                               "ON tbFavoritos.colProjeto = tbProjetos.idProjeto " +
                               "INNER JOIN tbUsuarios " +
                               "ON tbFavoritos.colUsuario = tbUsuarios.idUsuario " +
                              $"WHERE tbFavoritos.colUsuario = {id}";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                var reader = cmd.ExecuteReader();

                List<string> Nome = [];
                List<string> Escopo = [];
                List<string> Autor = [];

                while (reader.Read())
                {
                    Nome.Add(reader["colNome"].ToString());
                    Escopo.Add(reader["colEscopo"].ToString());
                    Autor.Add(reader["colApelido"].ToString());
                }

                string @base = "";

                for (int i = 0; i < Nome.Count; i++)
                {
                    @base +=
                        "<tr>" +
                            $"<td>{Nome[i]}</td>" +
                            $"<td>{Escopo[i]}</td>" +
                            $"<td>{Autor[i]}</td>" +
                            "<td>" +
                               "<button class='btn btn-outline-warning'><i class='bi bi-pencil-square'></i></button>" +
                               "<button class='btn btn-outline-danger'><i class='bi bi-x'></i></button>" +
                            "</td>" +
                         "</tr>";
                }

                HtmlString str = new(@base);
                return str;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro: " + e);
                throw;
            }
        }
    }
}