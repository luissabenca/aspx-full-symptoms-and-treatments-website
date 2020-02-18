using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projeto_pratica3
{
    public partial class layout : System.Web.UI.MasterPage
    {
        public string estado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
                estado = "Sair";
            else
                estado = "Login";
        }
    }
}