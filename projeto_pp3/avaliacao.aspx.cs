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
    public partial class contato : System.Web.UI.Page
    {

        SqlConnection conexao;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                txtMensagem.Enabled = false;
                txtNota.Enabled = false;
                lblErro.Text = "Por favor faça login antes de avaliar.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
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
                txtMensagem.Text = erro.ToString();
                return;
            }

            try
            {
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO avaliacao VALUES(@data,@nota,@mensagem)", conexao);
                cmdInsert.Parameters.AddWithValue("@data", DateTime.Now);
                cmdInsert.Parameters.AddWithValue("@nota", txtNota.Text);
                cmdInsert.Parameters.AddWithValue("@mensagem", txtMensagem.Text);
                cmdInsert.ExecuteNonQuery();

                lblAgradecimento.Text = "Avaliação enviada! Obrigado";
               

            }
            catch (Exception erro)
            {
                txtMensagem.Text = erro.ToString();
                return;
            }
        }
    }
}