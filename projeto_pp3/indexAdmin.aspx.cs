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


namespace projeto_pratica3
{
    public partial class indexAdmin : System.Web.UI.Page
    {
        SqlConnection conexao;
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
                lblMedia.Text = erro.ToString();
                return;
            }

            try
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT avg(nota) FROM avaliacao", conexao);
                lblMedia.Text = cmdSelect.ExecuteScalar().ToString();

                cmdSelect = new SqlCommand("SELECT count(codUsuario) FROM login where desativada=0", conexao);
                lblUsuarios.Text = cmdSelect.ExecuteScalar().ToString();
            }
            catch (Exception erro)
            {
                lblMedia.Text = erro.ToString();
                return;
            }
        }
    }
}