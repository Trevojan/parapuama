using Microsoft.Data.SqlClient;

namespace WebApp.Database
{
    public class Out
    {
        public List<int> Session = [];
        //public int Id { get; set; }

        public bool CallDoLogin(string lo, string se)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"SELECT idUsuario FROM tbUsuarios WHERE '{lo}' = colLogin AND '{se}' = colSenha";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int log = reader.GetInt32(0);
                    reader.Close();

                    query = $"INSERT INTO tbOnline VALUES({log},{1})";
                    cmd = new(query, con);
                    cmd.ExecuteNonQuery();

                    query = $"SELECT idOnline FROM tbOnline WHERE colLogado = {log}";
                    cmd = new(query, con);
                    reader = cmd.ExecuteReader();
                    if (reader.Read()) { Session.Add(reader.GetInt32(0)); }

                    return true;
                }
                return false;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro: " + e);
                throw;
            }
        }

        public bool CallPassword(string se1, string se2)
        {
            if (se1 == se2)
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

        public bool CallLogout(int id)
        {
            return Session.Contains(id);
        }

        public bool CallUniqueLogin(string lo)
        {

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
                string query = $"SELECT idUsuario FROM tbUsuarios WHERE '{em}' = colEmail";
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
                string query = $"SELECT idUsuario FROM tbUsuarios WHERE '{ap}' = colApelido";
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

