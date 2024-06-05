using Microsoft.Data.SqlClient;
using System.Dynamic;

namespace WebApp.Database
{
    public class Gather
    {
        public string forward(String read)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                string query = read;
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                using (var reader = cmd.ExecuteReader())
                {if (reader.Read())
                    {
                        return "Found database.";
                    }
                }

                System.Diagnostics.Debug.WriteLine(read);
                return read;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }


        public object SetCol(string c,string t)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True");
                string query = "SELECT COUNT(" + c + ") FROM " + t + ";";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    query = "SELECT " + c + " FROM " + t + ";";
                    cmd = new SqlCommand(query, con);
                    reader = cmd.ExecuteReader();

                    string[] val = { };
                    int i = 0;

                    foreach (var item in reader)
                    {val[i] = (string)reader[i];
                     i++;}

                    return val;
                }
                else { return "No value."; }
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        public void SetTables()
        {
            dynamic tbCargos = new ExpandoObject();
                    tbCargos.NewProp = SetCol("idCargo","tbCargos");
                    tbCargos.NewProp = SetCol("colNome", "tbCargos");
                    tbCargos.NewProp = SetCol("colCor", "tbCargos");
            dynamic tbDirecionado = new ExpandoObject();
            dynamic tbEncarregado = new ExpandoObject();
            dynamic tbEnquadrado = new ExpandoObject();
            dynamic tbFerramentas = new ExpandoObject();
            dynamic tbGrupos = new ExpandoObject();
            dynamic tbIdealizacao = new ExpandoObject();
            dynamic tbIdealizado = new ExpandoObject();
            dynamic tbObjetivos = new ExpandoObject();
            dynamic tbParticipantes = new ExpandoObject();
            dynamic tbProjetos = new ExpandoObject();
            dynamic tbQuadros = new ExpandoObject();
            dynamic tbSuper = new ExpandoObject();
            dynamic tbTarefas = new ExpandoObject();
            dynamic tbUsuarios = new ExpandoObject();
            dynamic tbUtilizando = new ExpandoObject();
        }
    }
}