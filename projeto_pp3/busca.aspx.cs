using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using projeto_pp3.App_Start;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace projeto_pp3
{
    public partial class busca : System.Web.UI.Page
    {
        SqlConnection conexao;
        SqlConnection conexao2;
        public string printar;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            String conString = WebConfigurationManager.ConnectionStrings["regulus.PR3"].ConnectionString; //System.NullReferenceException

            // instanciar a classe conexaoBD
            try
            {
                conexaoBD acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();
                conexao = acessoBD.getConexao();
                conexaoBD acessoBD2 = new conexaoBD();
                acessoBD2.Connection(conString);
                acessoBD2.AbrirConexao();
                conexao2 = acessoBD2.getConexao();
            }
            catch (Exception erro)
            {
                txtBusca.Text = erro.ToString();
                return;
            }

            try
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM logBusca WHERE termo=@termo", conexao);
                cmdSelect.Parameters.AddWithValue("@termo", txtBusca.Text);
                SqlDataReader resposta = cmdSelect.ExecuteReader();

                SqlCommand cmdInsert;

                if (resposta.HasRows)
                {
                    resposta.Close();
                    cmdInsert = new SqlCommand("UPDATE logBusca SET quantidade = quantidade + 1 WHERE termo=@termo", conexao);
                    cmdInsert.Parameters.AddWithValue("@termo", txtBusca.Text);
                    cmdInsert.ExecuteNonQuery();
                }
                else
                {
                    resposta.Close();
                    cmdInsert = new SqlCommand("INSERT INTO logBusca VALUES(@termo,1)", conexao);
                    cmdInsert.Parameters.AddWithValue("@termo", txtBusca.Text);
                    cmdInsert.ExecuteNonQuery();
                }


                cmdSelect = new SqlCommand("SELECT * FROM sintoma WHERE nome=@termo", conexao);
                cmdSelect.Parameters.AddWithValue("@termo", txtBusca.Text);
                resposta = cmdSelect.ExecuteReader();

                if (!resposta.HasRows)
                {
                    printar = "<h1 style='color:red;'>Sintoma não encontrado! </h1>";
                    return;
                }

                resposta.Read();
                int codSintoma = resposta.GetInt32(0);
                printar = "<h2><b>" + txtBusca.Text + " :</b> " + resposta.GetString(2) + "</h2> <h3><u>Possíveis tratamentos : </u></h3>";
                resposta.Close();

                cmdSelect = new SqlCommand("SELECT * FROM relacao WHERE idSintoma=@cod", conexao);
                cmdSelect.Parameters.AddWithValue("@cod", codSintoma);
                resposta = cmdSelect.ExecuteReader();

                SqlDataReader resposta2;
                while (resposta.Read())
                {
                    int a = resposta.GetInt32(2);
                    SqlCommand segundoSelect = new SqlCommand("SELECT * FROM tratamento WHERE idTratamento=@termo", conexao2);
                    segundoSelect.Parameters.AddWithValue("@termo", resposta.GetInt32(2));
                    resposta2 = segundoSelect.ExecuteReader(); //TEM QUE CRIAR UMA OUTRA CONEXAO AO BANCO PARA ISSO FUNCIONAR
                    // ELE NAO PERMITE TER  DOIS DATA READERS SIMULTANEOS NA MESMA CONEXAO

                    resposta2.Read();
                    printar += "<h4><b>" + resposta2.GetString(1) + " :</b> " + resposta2.GetString(2);
                    resposta2.Close();
                }
            }
            catch (Exception erro)
            {
                txtBusca.Text = erro.ToString();
                return;
            }
        }
    }
}