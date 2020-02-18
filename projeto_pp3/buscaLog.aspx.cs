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
    public partial class buscaLog : System.Web.UI.Page
    {
        SqlConnection conexao;
        public string printar;

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
                printar += erro.ToString();
                return;
            }

            try
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM logBusca order by quantidade DESC", conexao);
                SqlDataReader resposta = cmdSelect.ExecuteReader();

                while (resposta.Read())
                {
                    printar += "<tr><td>" + resposta.GetInt32(0) + "</td><td>" + resposta.GetString(1) +
                        "</td><td>" + resposta.GetInt32(2) +"</td></tr>";
                }

                resposta.Close();
            }
            catch (Exception erro)
            {
                printar += erro.ToString();
                return;
            }

        }
    }
}