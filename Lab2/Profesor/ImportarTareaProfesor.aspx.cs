using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Lab2
{
    public partial class ImportarTareaProfesor : System.Web.UI.Page
    {
        
        private DataTable tareas;
        private SqlDataAdapter adapter;
        private DataSet dataset;

        protected void Page_Load(object sender, EventArgs e)
        {
            adapter = Funcionalidades.Class1.TareasGenericasAdapter();
            dataset = new DataSet();
            adapter.Fill(dataset, "TareasGenericas");
            tareas = dataset.Tables["TareasGenericas"];
            verXML();
        }
        protected void verXML()
        {
            if (File.Exists(Server.MapPath("../APP_DATA/" + DropDownList1.SelectedValue + ".xml")))
            {
                Label3.Text = "";
                Xml1.DocumentSource = Server.MapPath("../APP_DATA/" + DropDownList1.SelectedValue + ".xml");
                Xml1.TransformSource = Server.MapPath("../APP_DATA/VerTablaTareas.xsl");
            }
            else {
                Label3.Text = "No hay XML para esta asignatura";
                
            }    
            
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verXML();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {
                XmlDocument xml = new XmlDocument();
                xml.Load(Server.MapPath("../APP_DATA/" + DropDownList1.SelectedValue + ".xml"));
                XmlNodeList TareasXML;
                TareasXML = xml.GetElementsByTagName("tarea");
                Funcionalidades.Class1.conectar();
                foreach (XmlNode tarea in TareasXML)
                {

                    bool exists = Funcionalidades.Class1.existeTarea(tarea.Attributes["codigo"].InnerText.ToString());
                    if (!exists)
                    {
                        DataRow row = tareas.NewRow();
                        row["Codigo"] = tarea.Attributes["codigo"].InnerText.ToString();
                        row["Descripcion"] = tarea.ChildNodes[0].InnerText.ToString();
                        row["CodAsig"] = DropDownList1.SelectedValue;
                        row["HEstimadas"] = Convert.ToInt32(tarea.ChildNodes[1].InnerText.ToString());
                        row["Explotacion"] = Convert.ToBoolean(tarea.ChildNodes[2].InnerText.ToString());
                        row["TipoTarea"] = tarea.ChildNodes[3].InnerText.ToString();
                        tareas.Rows.Add(row);
                    }

                }
                SqlCommandBuilder command = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = command.GetUpdateCommand();
                adapter.Update(dataset, "TareasGenericas");
                adapter.Update(tareas);
                //tareas.AcceptChanges();
                Funcionalidades.Class1.desconectar();
                Label3.Text = "Importadas correctamente";
            }
            catch {
                Label3.Text = "No existe un archivo XML para poder importar";
            }
        }
    }
}