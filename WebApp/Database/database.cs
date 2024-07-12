using Microsoft.AspNetCore.Html;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            Out @out = new();
            In @in = new();
            ap ??= lo;

            bool checkSe = @out.CallPassword(se1, se2);
            if (!checkSe)
            {
                bool checkLo = @out.CallUniqueLogin(lo);
                if (checkLo)
                {
                    bool checkEm = @out.CallUniqueEmail(em);
                    if (checkEm)
                    {
                        bool checkAp = @out.CallUniqueApelido(ap);
                        if (checkAp)
                        {
                            return @in.NovoUsuario(lo, se1, em, ap);
                        }
                    }
                }
            }
            return false;
        }

        public int ForwardOnline(int id)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"SELECT colOnline FROM tbUsuarios WHERE idUsuario = {id}";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                var reader = cmd.ExecuteScalar();
                int online = (byte)reader;

                if (online != 0)
                {
                    return id;
                }
                
                else
                {
                    return 0;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void ForwardOffline(int id)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"UPDATE tbUsuarios SET colOnline = 0 WHERE idUsuario = {id};";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e}");
                throw;
            }
        }

        public HtmlString ForwardFavoritos(int id)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = "SELECT tbUsuarios.idUsuario,tbProjetos.colNome,tbProjetos.colEscopo,tbUsuarios.colApelido " +
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
                List<string> Lider = [];

                while (reader.Read())
                {
                    Nome.Add(reader[1].ToString());
                    Escopo.Add(reader[2].ToString());
                    Lider.Add(reader[3].ToString());
                }
                string @base = "";

                for (int i = 0; i < Nome.Count; i++)
                {
                    @base +=
                        "<tr>" +
                            $"<td>{Nome[i]}</td>" +
                            $"<td>{Escopo[i]}</td>" +
                            $"<td>{Lider[i]}</td>" +
                            "<td>" +
                               "<button class='btn btn-outline-warning'><i class='bi bi-pencil-square'></i></button>" +
                               "<button class='ms-1 btn btn-outline-danger'><i class='bi bi-x'></i></button>" +
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

        /*
           try
            {
               
        */

        public HtmlString ForwardParticipando(int id)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query1 = "SELECT " +
                                "tbParticipantes.idUsuario," +
                                "tbProjetos.colNome," +
                                "tbProjetos.colEscopo," +
                                "tbUsuarios.colApelido, " +
                                "tbProjetos.colEstado," +
                                "tbProjetos.idProjeto " +
                                "FROM tbParticipantes " +
                                "LEFT JOIN tbProjetos " +
                                "ON tbParticipantes.idProjetoP = tbProjetos.idProjeto " +
                                "LEFT JOIN tbUsuarios " +
                                "ON tbParticipantes.idUsuario = tbUsuarios.idUsuario " +
                                "WHERE tbUsuarios.idUsuario = @id;";

                string query2 = "SELECT " +
                                "tbEncarregado.idUsuario, " +
                                "tbCargos.colNome, " +
                                "tbProjetos.idProjeto " +
                                "FROM tbEncarregado " +
                                "LEFT JOIN tbCargos " +
                                "ON tbEncarregado.idEncarregado = tbCargos.idCargo " +
                                "LEFT JOIN tbProjetos " +
                                "ON tbEncarregado.idProjetoC = tbProjetos.idProjeto " +
                                "WHERE tbEncarregado.idUsuario = @id;";

                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query1, con);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                Console.WriteLine($"o reader possui exatamente {reader.FieldCount} colunas");

                List<string> Nome = [];
                List<string> Escopo = [];
                List<string> Lider = [];
                List<string> Cargo = [];
                List<string> Estado = [];

                while (reader.Read())
                {
                    if (!reader.IsDBNull(1))
                    { Nome.Add(item: reader["colNome"].ToString()); }
                    else
                    { Nome.Add("nulo"); }
                    if (!reader.IsDBNull(2))
                    { Escopo.Add(item: reader["colEscopo"].ToString()); }
                    else
                    { Escopo.Add("nulo"); }
                    if (!reader.IsDBNull(3))
                    { Lider.Add(item: reader["colApelido"].ToString()); }
                    else
                    { Lider.Add("nulo"); }
                    if (!reader.IsDBNull(4))
                    { Estado.Add(item: reader["colEstado"].ToString()); }
                    else
                    { Estado.Add("nulo"); }
                }
                                
                reader.Close();

                cmd = new(query2, con);
                cmd.Parameters.AddWithValue("@id", id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(1))
                    { Cargo.Add(item: reader["colNome"].ToString()); }
                    else
                    { Cargo.Add("nulo"); }
                }

                string @base = "";

                for (int i = 0; i < Nome.Count - 1; i++)
                {
                    @base +=
                        "<tr>" +
                            $"<td>{Nome[i]}</td>" +
                            $"<td>{Escopo[i]}</td>" +
                            $"<td>{Lider[i]}</td>" +
                            $"<td>{Cargo[i]}</td>" +
                            $"<td>{Estado[i]}</td>" +
                            "<td>" +
                                "<button class='btn btn-outline-warning'><i class='bi bi-pencil-square'></i></button>" +
                                "<button class='btn btn-outline-danger'><i class='bi bi-x'></i></button>" +
                            "</td>" +
                            "</tr>";
                }

                Console.WriteLine("há exatos: " + Nome.Count + " itens nesta lista");
                    
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