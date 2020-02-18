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
    public partial class usuario : System.Web.UI.Page
    {

        SqlConnection conexao;
        public string printar;
        public string printar2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioAdmin"] == null)
                Response.Redirect("loginAdmin.aspx");

            String conString = WebConfigurationManager.ConnectionStrings["regulus.PR3"].ConnectionString; //System.NullReferenceException

            // instanciar a classe conexaoBD
            try
            {
                conexaoBD acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();
                conexao = acessoBD.getConexao();
            }
            catch (Exception erro)
            {
                return;
            }

            try
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM login WHERE desativada=0", conexao);
                SqlDataReader resposta = cmdSelect.ExecuteReader();

                while(resposta.Read())
                {
                    printar += "<tr><td>" + resposta.GetInt32(0) + "</td><td>" + resposta.GetString(2) + 
                        "</td><td>" + resposta.GetString(1) + "</td><td><a href='gerenciamentoUsuarios.aspx?cod="+resposta.GetInt32(0)+
                        "&acao=1'>Desativar</a></td</tr>";
                }

                resposta.Close();

                cmdSelect = new SqlCommand("SELECT * FROM login WHERE desativada=1", conexao);
                resposta = cmdSelect.ExecuteReader();

                while (resposta.Read())
                {
                    printar2 += "<tr><td>" + resposta.GetInt32(0) + "</td><td>" + resposta.GetString(2) +
                        "</td><td>" + resposta.GetString(1) + "</td><td><a href='gerenciamentoUsuarios.aspx?cod=" + resposta.GetInt32(0) +
                        "&acao=0'>Ativar</a></td</tr>";
                }


            }
            catch (Exception erro)
            {
                return;
            }
        }
    }
}