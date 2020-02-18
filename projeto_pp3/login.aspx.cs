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
    public partial class login : System.Web.UI.Page
    {
        SqlConnection conexao;

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
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM login WHERE email=@email and senha=@senha", conexao);
                cmdSelect.Parameters.AddWithValue("@email", txtEmail.Text);
                cmdSelect.Parameters.AddWithValue("@senha", txtSenha.Text);
                SqlDataReader resposta = cmdSelect.ExecuteReader();

                if (resposta.HasRows)
                {
                    resposta.Read();

                    Session["usuario"] = resposta.GetString(2);
                    Response.Redirect("index.aspx");
                }
                else
                {
                    lblErro.Text = "Usuário/senha incorretos.Não possui conta? Cadastre-se!";
                }

                
                // string nome = (string)Session["usuario"]

                /*
                SqlCommand cmdSelect2 = new SqlCommand("SELECT nome FROM Alunos WHERE codAluno=@CODIGO", conexao);
                cmdSelect.Parameters.AddWithValue("@CODIGO", txtEmail.Text);
                string nome = (string)cmdSelect.ExecuteScalar();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO Alunos VALUES('aa')", conexao);
                cmdSelect.Parameters.AddWithValue("@CODIGO", txtEmail.Text);
                int resp = cmdSelect.ExecuteNonQuery(); */

            }
            catch (Exception erro)
            {
                txtEmail.Text = erro.ToString();
                return;
            }

        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastro.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Remove("usuario");
                Response.Redirect("index.aspx");     
            }
        }
    }
}