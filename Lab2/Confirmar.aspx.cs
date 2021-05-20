using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Confirmar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["mbr"];
            int numConf = Convert.ToInt32(Request.QueryString["numconf"]);
            Funcionalidades.Class1.conectar();
            Label1.Text= Funcionalidades.Class1.confirmar(email, numConf);
            Funcionalidades.Class1.desconectar();
            HyperLink url = new HyperLink();
            url.NavigateUrl = "Inicio.aspx";
            url.Text = "Inicio";
            form1.Controls.Add(url);
            
            }
    }
}