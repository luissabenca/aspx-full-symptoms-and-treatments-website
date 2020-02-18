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
    public partial class desativar : System.Web.UI.Page
    {
        SqlConnection conexao;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioAdmin"] == null)
                Response.Redirect("loginAdmin.aspx");

            String conString = WebConfigurationManager.ConnectionStrings["regulus.PR3"].ConnectionString; //System.NullReferenceException

            try
            {
                conexaoBD acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();
                conexao = acessoBD.getConexao();
            }
            catch (Exception erro)
            {
                Label1.Text = erro.ToString();
                return;
            }

            try
            {

                SqlCommand cmdSelect = new SqlCommand("update login set desativada=@acao where codUsuario=@codUsuario", conexao);
                cmdSelect.Parameters.AddWithValue("@codUsuario", Request.QueryString["cod"]);
                cmdSelect.Parameters.AddWithValue("@acao", Request.QueryString["acao"]);

                //Label1.Text = Request.QueryString["cod"] + Request.QueryString["acao"];

                cmdSelect.ExecuteNonQuery();
                Response.Redirect("usuarios.aspx");



            }
            catch (Exception erro)
            {
                Label1.Text += erro.ToString();
                return;
            }
        }
    }
}