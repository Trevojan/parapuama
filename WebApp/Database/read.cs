using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Database
{
    public class Out
    {
        public List<int> Session = [];

        public bool CallDoLogin(string lo, string se, out int id)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"SELECT idUsuario FROM tbUsuarios WHERE colLogin = '{lo}' AND colSenha = '{se}';";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                    reader.Close();

                    query = $"UPDATE tbUsuarios SET colOnline = 1 WHERE idUsuario = {id};";
                    cmd = new(query, con);
                    cmd.ExecuteNonQuery();

                    return true;
                }

                id = 0;
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

        public IActionResult CallLogout(int id)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"UPDATE tbUsuarios SET colOnline = 0 WHERE idUsuario = @id";

                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                return new RedirectToPageResult("/");
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
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
                string query = $"SELECT idUsuario FROM tbUsuarios WHERE colApelido = '{ap}';";
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

        public object[] CallFavoritos(int id)
        {
            object[] obj = [];
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"SELECT idFavorito FROM tbFavoritos WHERE idUsuario = {id}";
                using SqlConnection con = new(connectionString);
                con.Open();
                SqlCommand cmd = new(query, con);
                var reader = cmd.ExecuteReader();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    obj.Append(reader.GetValue(i));
                }
                return obj;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro: " + e);
                throw;
            }

        }
    }
}