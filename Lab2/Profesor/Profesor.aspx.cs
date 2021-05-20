using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Profesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int numAlumnos = (int)Application.Get("Alumno");
            int numProfesores = (int)Application.Get("Profesor");
            Label1.Text = "Numero de usuarios conectados- Alumno\\s: "+ Convert.ToString(numAlumnos)+ " Profe\\s: " + Convert.ToString(numProfesores);
            string arrProfesor = "ArrayProfesor";
            string arrAlumnos = "ArrayAlumno";
            ArrayList arrayProfesor = (ArrayList)Application.Contents[arrProfesor];
            ListBox1.Items.Clear();
            foreach (string a in arrayProfesor) {
                ListBox1.Items.Add(a);
            }
            ListBox1.DataBind();
            ArrayList arrayAlumnos = (ArrayList)Application.Contents[arrAlumnos];
            ListBox2.Items.Clear();
            foreach (string a in arrayAlumnos)
            {
                ListBox2.Items.Add(a);
            }
            ListBox2.DataBind();
        }
    }
}