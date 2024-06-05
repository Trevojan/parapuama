using Microsoft.Data.SqlClient;
using System.Dynamic;

namespace WebApp.Database
{
    public class Gather
    {
        public void forward()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Users\eros_benkert\Documents\GitHub\parapuama\WebApp\Database\dbParapuama.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
                string query = "SELECT * FROM INFORMATION_SCHEMA.TABLES;";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Erro: " + e);
                throw;
            }
        }

        public static void getTables()
        {
            dynamic tbCargos = new ExpandoObject();
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