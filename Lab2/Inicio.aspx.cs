using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Inicio : System.Web.UI.Page
    {
        MD5CryptoServiceProvider hash;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            hash = new MD5CryptoServiceProvider();
            hash.Initialize();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pass = TextBox2.Text;
            string hashPass = Funcionalidades.Class1.getHashPassword(pass);
            

            Funcionalidades.Class1.conectar();
            int resultado = Funcionalidades.Class1.iniciarSesion(TextBox1.Text, hashPass);

            if (resultado == 1)
            {
                Session["UserName"] = TextBox1.Text;
                string rol = Funcionalidades.Class1.getRol(TextBox1.Text);
               
                if (TextBox1.Text == "vadillo@ehu.es")
                {
                    FormsAuthentication.RedirectFromLoginPage("vadillo", false);
                }
                else {
                    FormsAuthentication.RedirectFromLoginPage(rol, false);
                }
                Session["rol"]= rol;
                Application.Lock();
                int np = (int)Application.Contents[rol];
                np += 1;
                string arr = "Array" + rol;
                ArrayList array = (ArrayList)Application.Contents[arr];
                array.Add(TextBox1.Text);
                Application.Contents[arr]= array;
                Application.Contents[rol] = np;
                Application.UnLock();
                Funcionalidades.Class1.desconectar();
                Response.Redirect($"{rol}/{rol}.aspx");


            }
            else
            {
                Label3.Text = "El usuario no existe, es incorrecto o necesita verificar";
            }
            Funcionalidades.Class1.desconectar();

            
        }

        
    }
}