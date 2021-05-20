using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Lab2
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Contents["Alumno"] = 0;
            Application.Contents["Profesor"] = 0;
            Application.Contents["ArrayAlumno"] =new ArrayList();
            Application.Contents["ArrayProfesor"] = new ArrayList();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
           
        }
        protected void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            if ((string)Session["rol"] == "Profesor")
            {
                Application.Lock();
                int np = (int)Application.Contents["Profesor"];
                np -= 1;
                Application.Contents["Profesor"] = np;
                ArrayList array = (ArrayList)Application.Contents["ArrayProfesor"];
                array.Remove(Session["Username"].ToString());
                Application.Contents["ArrayProfesor"] = array;

                Application.UnLock();
            }
            else if ((string)Session["rol"] == "Alumno")
            {
                Application.Lock();
                int np = (int)Application.Contents["Alumno"];
                np -= 1;
                Application.Contents["Alumno"] = np;
                ArrayList array = (ArrayList)Application.Contents["ArrayAlumno"];
                array.Remove(Session["UserName"].ToString());
                Application.Contents["ArrayAlumno"] = array;
                Application.UnLock();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application.Contents["ArrayAlumno"] = new ArrayList();
            Application.Contents["ArrayProfesor"] = new ArrayList();
        }
    }
}