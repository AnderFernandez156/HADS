using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string email = Request.QueryString["mbr"];
            int codpass = Convert.ToInt32(Request.QueryString["codpass"]);
            if (email != null && codpass!=null) {
                TextBox2.Text = email;
                TextBox3.Text = Convert.ToString(codpass);
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Funcionalidades.Class1.conectar();
            int codpassCorrecto = Funcionalidades.Class1.confirmarCodpass(TextBox2.Text, Convert.ToInt32(TextBox3.Text));
            int existeCuenta = Funcionalidades.Class1.existeCuenta(TextBox2.Text);
            // si es 0 es que esta registrado y el codpass coincide
            if (codpassCorrecto == 0 && existeCuenta == 1)
            {
                Funcionalidades.Class1.cambiarPassword(TextBox2.Text, TextBox4.Text);
                Label9.Text = Funcionalidades.Class1.cambiarPassword(TextBox2.Text, TextBox4.Text); 
            }
            else
            {
                Label9.Text = "Email o codigo erroneo";
            }
            Funcionalidades.Class1.desconectar();
        }
    }
}