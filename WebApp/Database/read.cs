using Microsoft.Data.SqlClient;

namespace WebApp.Database
{
    public class Out
    {
        List<int> Session = new List<int>();

        public bool CallDoLogin(string l, string p)
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

        public bool CallPassword(string p1, string p2)
        {
            if (p1 == p2 && p1 != null)
            {
                return false;
            }
            return true;
        }

        public bool CallLoginCheck(int id)
        {
            if (Session.Contains(id))
            {
                return true;
            }
            
            return false;
        }

        public bool CallLogout(int id) {
            return Session.Contains(id);
        }

        public bool CallUniqueLogin(string lo) {

            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"SELECT idUsuario FROM tbUsuarios WHERE '{lo}' = colLogin";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    { return false; }
                    return true;
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public bool CallUniqueEmail(string em)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"SELECT idUsuario FROM tbUsuarios WHERE {em} = colEmail";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    { return false; }
                    return true;
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public bool CallUniqueApelido(string ap)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"SELECT idUsuario FROM tbUsuarios WHERE {ap} = colApelido";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    { return false; }
                    return true;
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

    }

}

