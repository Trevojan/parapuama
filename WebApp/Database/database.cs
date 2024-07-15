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

        public HtmlString ForwardParticipando(int id)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string queryNome = "SELECT tbParticipantes.idUsuario, tbProjetos.colNome FROM tbParticipantes LEFT JOIN tbProjetos ON tbProjetos.idProjeto = tbParticipantes.idProjetoP LEFT JOIN tbUsuarios ON tbParticipantes.idUsuario = tbUsuarios.idUsuario WHERE tbParticipantes.idUsuario = @id1;";
                string queryEscopo = "SELECT tbParticipantes.idUsuario, tbProjetos.colEscopo FROM tbParticipantes LEFT JOIN tbProjetos ON tbProjetos.idProjeto = tbParticipantes.idProjetoP LEFT JOIN tbUsuarios ON tbParticipantes.idUsuario = tbUsuarios.idUsuario WHERE tbParticipantes.idUsuario = @id2;";
                string queryLider = "SELECT tbParticipantes.idUsuario, tbUsuarios.colApelido FROM tbParticipantes LEFT JOIN tbUsuarios ON tbParticipantes.idUsuario = tbUsuarios.idUsuario WHERE tbParticipantes.idUsuario = @id3;";
                string queryCargo = "SELECT tbEncarregado.idUsuario, tbCargos.colNome FROM tbEncarregado LEFT JOIN tbCargos ON tbCargos.idCargo = tbEncarregado.idCargo LEFT JOIN tbUsuarios ON tbencarregado.idUsuario = tbUsuarios.idUsuario WHERE tbEncarregado.idUsuario = @id4;";
                string queryEstado = "SELECT tbParticipantes.idUsuario, tbProjetos.colEstado FROM tbParticipantes LEFT JOIN tbProjetos ON tbProjetos.idProjeto = tbParticipantes.idProjetoP LEFT JOIN tbUsuarios ON tbParticipantes.idUsuario = tbUsuarios.idUsuario WHERE tbParticipantes.idUsuario = @id5;";

                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new();
                cmd.Connection = con;
                
                cmd.CommandText = queryNome;
                cmd.Parameters.AddWithValue("@id1", id);
                var reader = cmd.ExecuteReader();

                List<string> Nome = [];
                while (reader.Read())
                {
                    if (!reader.IsDBNull(1))
                    { Nome.Add(item: reader["colNome"].ToString()); }
                    else
                    { Nome.Add("nulo"); }
                }
                reader.Close();

                cmd.CommandText = queryEscopo;
                cmd.Parameters.AddWithValue("@id2", id);
                reader = cmd.ExecuteReader();

                List<string> Escopo = [];
                while (reader.Read())
                {
                    if (!reader.IsDBNull(1))
                    { Escopo.Add(item: reader["colEscopo"].ToString()); }
                    else
                    { Escopo.Add("nulo"); }
                }
                reader.Close();

                cmd.CommandText = queryLider;
                cmd.Parameters.AddWithValue("@id3", id);
                reader = cmd.ExecuteReader();

                List<string> Lider = [];
                while (reader.Read())
                {
                    if (!reader.IsDBNull(1))
                    { Lider.Add(item: reader["colApelido"].ToString()); }
                    else
                    { Lider.Add("nulo"); }
                }
                reader.Close();

                cmd.CommandText = queryCargo;
                cmd.Parameters.AddWithValue("@id4", id);
                reader = cmd.ExecuteReader();

                List<string> Cargo = [];
                while (reader.Read())
                {
                    if (!reader.IsDBNull(1))
                    { Cargo.Add(item: reader["colNome"].ToString()); }
                    else
                    { Cargo.Add("nulo"); }
                }
                reader.Close();

                cmd.CommandText = queryEstado;
                cmd.Parameters.AddWithValue("@id5", id);
                reader = cmd.ExecuteReader();

                List<string> Estado = [];
                while (reader.Read())
                {
                    if (!reader.IsDBNull(1))
                    { Estado.Add(item: reader["colEstado"].ToString()); }
                    else
                    { Estado.Add("nulo"); }
                }
                reader.Close();

                string @base = "";

                for (int i = 0; i < Nome.Count; i++)
                {
                    var n = ""; var e = ""; var l = ""; var c = ""; var s = "";

                    if (i > Nome.Count) { n = "..."; }
                    else { n = Nome[i].ToString(); }
                    if (i > Escopo.Count) { e = "..."; }
                    else { e = Escopo[i].ToString(); }
                    if (i > Lider.Count) { l = "..."; }
                    else { l = Lider[i].ToString(); }
                    if (i > Cargo.Count) { c = "..."; }
                    else { c = Cargo[i].ToString(); }
                    if (i > Estado.Count) { s = "..."; }
                    else { s = Estado[i].ToString(); }
                    switch (s)
                    {
                        case "1": s = "Aberto"; break;
                        case "0": s = "Fechado"; break;
                    }

                    @base +=
                        "<tr>" +
                            $"<td>{n}</td>" +
                            $"<td>{e}</td>" +
                            $"<td>{l}</td>" +
                            $"<td>{c}</td>" +
                            $"<td>{s}</td>" +
                            "<td>" +
                                "<button class='btn btn-outline-warning me-1'><i class='bi bi-pencil-square'></i></button>" +
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