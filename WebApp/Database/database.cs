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

        public object SetCol(string c, string t)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dbParapuama.mdf;Integrated Security=True;Connect Timeout=10;Encrypt=True";
                string query = $"SELECT COUNT({c}) FROM {t};";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        var reader = cmd.ExecuteReader();
                        int count = 0;
                        while (reader.Read())
                        {
                            count = (int)reader[0];
                        }
                        Console.WriteLine($"Count: {count}");
                        return count;
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        public void SetTables()
        {
            dynamic tbCargos = new ExpandoObject();
                    tbCargos.id = SetCol("idCargo", "tbCargos");
                    tbCargos.nome = SetCol("colNome", "tbCargos");
                    tbCargos.cor = SetCol("colCor", "tbCargos");

            dynamic tbDirecionado = new ExpandoObject();
                    tbDirecionado.projeto = SetCol("idProjetoO", "tbDirecionado");
                    tbDirecionado.id = SetCol("idDirecionado", "tbDirecionado");
                    tbDirecionado.objetivo = SetCol("idObjetivo", "tbDirecionado");

            dynamic tbEncarregado = new ExpandoObject();
                    tbEncarregado.projeto = SetCol("idProjetoC", "tbEncarregado");
                    tbEncarregado.id = SetCol("idEncarregado", "tbEncarregado");
                    tbEncarregado.cargo = SetCol("idCargo", "tbEncarregado");
                    tbEncarregado.usuario = SetCol("idUsuario", "tbEncarregado");
            
            dynamic tbEnquadrado = new ExpandoObject();
                    tbEnquadrado.projeto = SetCol("idProjetoQ", "tbEnquadrado");
                    tbEnquadrado.id = SetCol("idEnquadrado", "tbEnquadrado");
                    tbEnquadrado.quadro = SetCol("idQuadro", "tbEnquadrado");
            
            dynamic tbFerramentas = new ExpandoObject();
                    tbFerramentas.id = SetCol("idFerramenta", "tbFerramentas");
                    tbFerramentas.nome = SetCol("colNome", "tbFerramentas");
                    tbFerramentas.utilidade = SetCol("colUtilidade", "tbFerramentas");
                    tbFerramentas.funcao = SetCol("colFuncao", "tbFerramentas");
                    tbFerramentas.estado = SetCol("colEstado", "tbFerramentas");
            
            dynamic tbGrupos = new ExpandoObject();
                    tbGrupos.id = SetCol("idGrupo", "tbGrupos");
                    tbGrupos.nome = SetCol("colNome", "tbGrupos");
                    tbGrupos.descricao = SetCol("colDescricao", "tbGrupos");
                    tbGrupos.limite = SetCol("colLimite", "tbGrupos");
                    tbGrupos.data = SetCol("colDataCriacao", "tbGrupos");
            
            dynamic tbIdealizacao = new ExpandoObject();
                    tbIdealizacao.id = SetCol("idIdeia", "tbIdealizacao");
                    tbIdealizacao.descricao = SetCol("colDescricao", "tbIdealizacao");
                    tbIdealizacao.estado = SetCol("colEstado", "tbIdealizacao");
                    tbIdealizacao.data = SetCol("colDataCriacao", "tbIdealizacao");
            
            dynamic tbIdealizado = new ExpandoObject();
                    tbIdealizado.projeto = SetCol("idProjetoI", "tbIdealizado");
                    tbIdealizado.id = SetCol("idIdealizado", "tbIdealizado");
                    tbIdealizado.ideia = SetCol("idIdeias", "tbIdealizado");
            
            dynamic tbObjetivos = new ExpandoObject();
                    tbObjetivos.id = SetCol("idObjetivo", "tbObjetivos");
                    tbObjetivos.nome = SetCol("colNome", "tbObjetivos");
                    tbObjetivos.descricao = SetCol("colDescricao", "tbObjetivos");
                    tbObjetivos.estado = SetCol("colEstado", "tbObjetivos");
            
            dynamic tbParticipantes = new ExpandoObject();
                    tbParticipantes.projeto = SetCol("idProjetoP", "tbParticipantes");
                    tbParticipantes.id = SetCol("idParticipante", "tbParticipantes");
                    tbParticipantes.usuario = SetCol("idUsuario", "tbParticipantes");
            
            dynamic tbProjetos = new ExpandoObject();
                    tbProjetos.projeto = SetCol("idProjeto", "tbProjetos");
                    tbProjetos.nome = SetCol("colNome", "tbProjetos");
                    tbProjetos.descricao = SetCol("colDescricao", "tbProjetos");
            
            dynamic tbQuadros = new ExpandoObject();
                    tbQuadros.id = SetCol("idQuadro", "tbQuadros");
                    tbQuadros.nome = SetCol("colNome", "tbQuadros");
            
            dynamic tbSuper = new ExpandoObject();
                    tbSuper.id = SetCol("idSuper", "tbSuper");
                    tbSuper.participantes = SetCol("idParticipantes", "tbSuper");
                    tbSuper.ferramentas = SetCol("idFerramentas", "tbSuper");
                    tbSuper.quadros = SetCol("idQuadros", "tbSuper");
                    tbSuper.objetivos = SetCol("idObjetivos", "tbSuper");
                    tbSuper.ideias = SetCol("idIdealizado", "tbSuper");
            
            dynamic tbTarefas = new ExpandoObject();
                    tbTarefas.id = SetCol("idTarefa", "tbTarefas");
                    tbTarefas.nome = SetCol("colNome", "tbTarefas");
                    tbTarefas.tipo = SetCol("colTipo", "tbTarefas");
                    tbTarefas.estado = SetCol("colEstado", "tbTarefas");
            
            dynamic tbUtilizando = new ExpandoObject();
                    tbUtilizando.projeto = SetCol("idProjetoF", "tbUtilizando");
                    tbUtilizando.idealizado = SetCol("idIdealizado", "tbUtilizando");
                    tbUtilizando.ferramenta = SetCol("idFerramenta", "tbUtilizando");

            dynamic tbUsuarios = new ExpandoObject();
                    tbUsuarios.id = SetCol("idUsuario", "tbUsuarios");
                    tbUsuarios.login = SetCol("colLogin", "tbUsuarios");
                    tbUsuarios.senha = SetCol("colSenha", "tbUsuarios");
                    tbUsuarios.email = SetCol("colEmail", "tbUsuarios");
                    tbUsuarios.apelido = SetCol("colApelido", "tbUsuarios");
                    tbUsuarios.biografia = SetCol("colBiografia", "tbUsuarios");
        }
    }
}