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
    public partial class loginAdmin : System.Web.UI.Page
    {
        SqlConnection conexao;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioAdmin"] != null)
                Session.Remove("usuarioAdmin");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
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
                txtEmail.Text = erro.ToString();
                return;
            }

            try
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM login_admin WHERE email=@email and senha=@senha", conexao);
                cmdSelect.Parameters.AddWithValue("@email", txtEmail.Text);
                cmdSelect.Parameters.AddWithValue("@senha", txtSenha.Text);
                SqlDataReader resposta = cmdSelect.ExecuteReader();

                if (resposta.HasRows)
                {
                    Session["usuarioAdmin"] = "logado";
                    Response.Redirect("indexAdmin.aspx");
                }
                else
                {
                    lblErro.Text = "Usuário/senha incorretos";
                }
            }
            catch (Exception erro)
            {
                txtEmail.Text = erro.ToString();
                return;
            }

        }
    }
}