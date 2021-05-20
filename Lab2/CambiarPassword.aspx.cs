using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Funcionalidades.Class1.conectar();
            int resultado = Funcionalidades.Class1.existeCuenta(TextBox1.Text);
            if (resultado == 1)
            {
                Random random = new Random();
                int codpass = (random.Next() * 900000) + 100000;
                resultado = Funcionalidades.Class1.CambiarCodPass(TextBox1.Text,codpass);
                //si es 0 es que ha funcionado
                if (resultado == 0)
                {
                    string protocol = Request.ServerVariables["HTTPS"].ToLower() == "on" ? "https" : "http";
                    string server = Request.ServerVariables["SERVER_NAME"];
                    string port = Request.ServerVariables["SERVER_PORT"];

                    string url = $"{protocol}://{server}:{port}/Modificarpassword.aspx?mbr={TextBox1.Text}&codpass={codpass}";
                    string body = $"<p>Pulsa {url} para modificar su contrasena.</p>";


                    string subject = "Cambiar contrasena";
                    Funcionalidades.Class1.sendEmail(TextBox1.Text, subject, body);
                    Label2.Text = "Se ha enviado un correo a su direccion por el cual se modificara la contrasena";
                }
                else {
                    Label2.Text = "Ha ocurrido un error, intentelo mas tarde";
                }
            }
            else {
                Label2.Text = "Su correo no esta registrado";
            }
            Funcionalidades.Class1.desconectar();
        }

        
    }
}