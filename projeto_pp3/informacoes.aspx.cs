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
    public partial class informacoes : System.Web.UI.Page
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
                lblErro1.Text = erro.ToString();
                return;
            }
        }

        protected void btnSintoma_Click(object sender, EventArgs e)
        {
            if (txtNomeSintoma.Equals("") || txtDescricaoSintoma.Equals(""))
            {
                lblErro1.Text = "Por favor preencha os campos!";
                return;
            }

            try
            {

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO sintoma VALUES(@nome,@descricao)", conexao);
                cmdInsert.Parameters.AddWithValue("@nome", txtNomeSintoma.Text);
                cmdInsert.Parameters.AddWithValue("@descricao", txtDescricaoSintoma.Text);
                int sucesso = cmdInsert.ExecuteNonQuery();

                if (sucesso == 1)
                {
                    lblSucesso.Text = "Sintoma adicionado com sucesso!";
                    return;
                }
                lblErro1.Text = "Erro na inserção de dados. Por favor confirme-os.";
            }
            catch (Exception erro)
            {
                lblErro1.Text = erro.ToString();
                return;
            }
        }

        protected void btnTratamento_Click(object sender, EventArgs e)
        {
            if (txtNomeTratamento.Equals("") || txtDescricaoTratamento.Equals(""))
            {
                lblErro2.Text = "Por favor preencha os campos!";
                return;
            }

            try
            {

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO tratamento VALUES(@nome,@descricao)", conexao);
                cmdInsert.Parameters.AddWithValue("@nome", txtNomeTratamento.Text);
                cmdInsert.Parameters.AddWithValue("@descricao", txtDescricaoTratamento.Text);
                int sucesso = cmdInsert.ExecuteNonQuery();

                if (sucesso == 1)
                {
                    lblSucesso.Text = "Tratamento adicionado com sucesso!";
                    return;
                }
                lblErro2.Text = "Erro na inserção de dados. Por favor confirme-os.";
            }
            catch (Exception erro)
            {
                lblErro2.Text = erro.ToString();
                return;
            }
        }

        protected void btnRelacao_Click(object sender, EventArgs e)
        {
            if (txtSintoma.Equals("") || txtTratamento.Equals(""))
            {
                lblErro3.Text = "Por favor preencha os campos!";
                return;
            }

            try
            {
                SqlCommand cmdSelect = new SqlCommand("SELECT idSintoma FROM sintoma WHERE nome=@nome", conexao);
                cmdSelect.Parameters.AddWithValue("@nome", txtSintoma.Text);

                int numSintoma;
                try
                {
                    numSintoma = (int)cmdSelect.ExecuteScalar();
                }
                catch(Exception)
                {
                    lblErro3.Text = "Por favor digite um sintoma válido!";
                    return;
                }

                cmdSelect = new SqlCommand("SELECT idTratamento FROM tratamento WHERE nome=@nome", conexao);
                cmdSelect.Parameters.AddWithValue("@nome", txtTratamento.Text);

                int numTratamento;
                try
                {
                    numTratamento = (int)cmdSelect.ExecuteScalar();
                }
                catch (Exception)
                {
                    lblErro3.Text = "Por favor digite um tratamento válido!";
                    return;
                }


                SqlCommand cmdInsert = new SqlCommand("INSERT INTO relacao VALUES(@sintoma,@tratamento)", conexao);
                cmdInsert.Parameters.AddWithValue("@sintoma", numSintoma);
                cmdInsert.Parameters.AddWithValue("@tratamento", numTratamento);
                int sucesso = cmdInsert.ExecuteNonQuery();

                if (sucesso == 1)
                {
                    lblSucesso.Text = "Relação adicionada com sucesso!";
                    return;
                }
                lblErro3.Text = "Erro na inserção da relação. Por favor tente novamente";
            }
            catch (Exception erro)
            {
                lblErro3.Text = erro.ToString();
                return;
            }
        }
    }
}