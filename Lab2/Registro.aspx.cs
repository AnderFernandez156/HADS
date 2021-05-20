using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


namespace Lab2
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Label9.Text == "EMAIL NO MATRICULADO")
            {
                Label10.Text = "Es necesario estar matriculado";
            }
            else
            {
                Random random = new Random();
                int numConf = (random.Next() * 9000000) + 1000000;
                Funcionalidades.Class1.conectar();
                string pass = TextBox4.Text;
                string hashPass = Funcionalidades.Class1.getHashPassword(pass);
                string resultado = Funcionalidades.Class1.registrar(TextBox1.Text, TextBox2.Text, TextBox3.Text, numConf, RadioButtonList1.SelectedItem.Value, hashPass);
                Label8.Text = resultado;
                if (resultado == "Se ha registrado correctamente")
                {
                    string protocol = Request.ServerVariables["HTTPS"].ToLower() == "on" ? "https" : "http";
                    string server = Request.ServerVariables["SERVER_NAME"];
                    string port = Request.ServerVariables["SERVER_PORT"];

                    string url = $"{protocol}://{server}:{port}/Confirmar.aspx?mbr={TextBox1.Text}&numconf={numConf}";
                    string body = $"<p>Pulsa {url} para activar tu cuenta.</p>";


                    string subject = "Confirmar cuenta";
                    Funcionalidades.Class1.sendEmail(TextBox1.Text, subject, body);
                    HyperLink url2 = new HyperLink();
                    url2.NavigateUrl = "Confirmar.aspx?mbr=" + TextBox1.Text + "&numconf=" + numConf;
                    url2.Text = "Verificar";
                    form1.Controls.Add(url2);
                }
                Funcionalidades.Class1.desconectar();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            matriculas.Matriculas service = new matriculas.Matriculas();
            if (service.comprobar(TextBox1.Text) == "NO")
            {
                Label9.Text = "EMAIL NO MATRICULADO";
            }
            else {
                Label9.Text = "EMAIL MATRICULADO";
            }
        }
    }
}