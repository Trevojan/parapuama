using Microsoft.Data.SqlClient;

namespace WebApp.Database
{
    public class In
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
        public void NovoCargo(string ca, string co)
        {
            try
            {
                string query = $"INSERT INTO tbCargos VALUES({ca},{co})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void NovoQuadro(string ca)
        {
            try
            {
                string query = $"INSERT INTO tbQuadros VALUES({ca})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void NovaTarefa(string no, string ti, string es)
        {
            try
            {
                string query = $"INSERT INTO tbTarefas VALUES({no},{ti},{es})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void NovaFerramenta(string no, string ut, string fu, string es)
        {
            try
            {
                string query = $"INSERT INTO tbFerramentas VALUES({no},{ut},{fu},{es})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void NovaIdeia(string de, string es, string da)
        {
            try
            {
                string query = $"INSERT INTO tbIdealizacao VALUES({de},{es},{da})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void NovoGrupo(string no, string de, string li, string da)
        {
            try
            {
                string query = $"INSERT INTO tbFerramentas VALUES({no},{de},{li},{da})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void NovoObjetivo(string no, string des, string es)
        {
            try
            {
                string query = $"INSERT INTO tbObjetivos VALUES({no},{des},{es})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void NovoUsuario(string lo, string se, string ap)
        {
            try
            {
                string query = $"INSERT INTO tbUsuarios VALUES({lo},{se},{ap})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

    }

    public class Tie
    { 
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
        public void Encarregar(string ca, string us, string pr)
        {
            try
            {
                string query = $"INSERT INTO tbEncarregado VALUES({ca},{us},{pr})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void Enquadrar(string qu, string pr)
        {
            try
            {
                string query = $"INSERT INTO tbEnquadrado VALUES({qu},{pr})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void Idealizar(string id, string pr)
        {
            try
            {
                string query = $"INSERT INTO tbIdealizado VALUES({id},{pr})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void Participar(string us, string pr)
        {
            try
            {
                string query = $"INSERT INTO tbParticipando VALUES({us},{pr})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void Utilizar(string fe, string pr)
        {
            try
            {
                string query = $"INSERT INTO tbUtilizando VALUES({fe},{pr})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void Designar(string qu, string ta)
        {
            try
            {
                string query = $"INSERT INTO tbDesignado VALUES({qu},{ta})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void Direcionar(string ob, string pr)
        {
            try
            {
                string query = $"INSERT INTO tbDirecionado VALUES({ob},{pr})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public void Agrupar(string no, string des, string es)
        {
            try
            {
                string query = $"INSERT INTO tbAgrupamentos VALUES({no},{des},{es})";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }
    }
}
