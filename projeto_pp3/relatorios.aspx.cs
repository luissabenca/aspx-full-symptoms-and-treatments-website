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
    public partial class relatorios : System.Web.UI.Page
    {
        SqlConnection conexao;
        public string nomes;
        public string dados;
        public string cores;
        public string coresBordas;


        /*lógica abaixo horrível
         * me causa repulsas
         * mas nao estou com cabeça para pensar
         * então é o que tem pra hoje
         * */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioAdmin"] == null)
                Response.Redirect("loginAdmin.aspx");

            String conString = WebConfigurationManager.ConnectionStrings["regulus.PR3"].ConnectionString; //System.NullReferenceException


            conexaoBD acessoBD = new conexaoBD();
            acessoBD.Connection(conString);
            acessoBD.AbrirConexao();
            conexao = acessoBD.getConexao();

            SqlCommand cmdSelect = new SqlCommand("SELECT count(cod) FROM logBusca", conexao);
            int quantos = (int)cmdSelect.ExecuteScalar();
            string[] termos = new string[quantos];
            int[] quantidades = new int[quantos];

            cmdSelect = new SqlCommand("SELECT * FROM logBusca order by quantidade DESC", conexao);
            SqlDataReader resposta = cmdSelect.ExecuteReader();

            int cont = 0;
            while (resposta.Read())
            {
                termos[cont] = resposta.GetString(1);
                quantidades[cont] = resposta.GetInt32(2);
                cont++;
            }
            resposta.Close();
            cont--;

            for (int i = 0; i < cont; i++)
            {
                nomes += "'" + termos[i] + "',";
            }
            nomes += "'" + termos[cont] + "'";

            for (int i = 0; i < cont; i++)
            {
                dados += quantidades[i] + ",";
            }
            dados += "" + quantidades[cont] + "";

            int aleatorio1;
            int aleatorio2;
            int aleatorio3;
            Random aleatorio = new Random();
            for (int i = 0; i < cont; i++)
            {
                aleatorio1 = aleatorio.Next(0, 255);
                aleatorio2 = aleatorio.Next(0, 255);
                aleatorio3 = aleatorio.Next(0, 255);
                cores += "'rgba(" + aleatorio1 + "," + aleatorio2 + "," + aleatorio3 + ",0.2)',";
                coresBordas += "'rgba(" + aleatorio1 + "," + aleatorio2 + "," + aleatorio3 + ",1)',";

            }
            aleatorio1 = aleatorio.Next(0, 255);
            aleatorio2 = aleatorio.Next(0, 255);
            aleatorio3 = aleatorio.Next(0, 255);
            cores += "'rgba(" + aleatorio1 + "," + aleatorio2 + "," + aleatorio3 + ",0.2)'";
            coresBordas += "'rgba(" + aleatorio1 + "," + aleatorio2 + "," + aleatorio3 + ",1)'";

        }
    }
}