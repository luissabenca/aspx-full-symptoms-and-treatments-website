using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projeto_pratica3
{
    public partial class index : System.Web.UI.Page
    {
        public string usuario = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
                usuario = " " + (string)Session["usuario"];
        }
    }
}