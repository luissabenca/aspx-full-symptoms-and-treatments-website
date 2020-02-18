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
    public partial class cadastro : System.Web.UI.Page
    {
        SqlConnection conexao;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
                Response.Redirect("index.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!txtSenha.Text.Equals(txtConfirmaSenha.Text))
                lblErro.Text = "As senhas inseridas são diferentes!";
            else
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
                    txtNome.Text = erro.ToString();
                    return;
                }

                try
                {
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM login WHERE email=@email", conexao);
                    cmdSelect.Parameters.AddWithValue("@email", txtEmail.Text);
                    SqlDataReader resposta = cmdSelect.ExecuteReader();

                    if (resposta.HasRows)
                        lblErro.Text = "Email já utilizado!";
                    else
                    {
                        resposta.Close();
                        SqlCommand cmdInsert = new SqlCommand("INSERT INTO LOGIN VALUES(@email,@nome,@senha,@dataNascimento,0)", conexao);
                        cmdInsert.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmdInsert.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmdInsert.Parameters.AddWithValue("@senha", txtSenha.Text);
                        cmdInsert.Parameters.AddWithValue("@dataNascimento", txtDataNascimento.Text);
                        int sucesso = cmdInsert.ExecuteNonQuery();

                        if (sucesso == 1)
                        {
                            txtEmail.Text = "";
                            txtNome.Text = "";
                            txtSenha.Text = "";
                            txtConfirmaSenha.Text = "";
                            txtDataNascimento.Text = "";
                            lblErro.ForeColor = System.Drawing.Color.Green;
                            lblErro.Text = "Usuário cadastrado com sucesso!";
                        }
                        else
                            lblErro.Text = "Erro na inserção de dados. Por favor confirme-os.";
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
}