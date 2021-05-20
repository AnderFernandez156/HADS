using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Funcionalidades
{
    public class Class1
    {
        static SqlConnection conexion = new SqlConnection();
        public static void conectar()
        {
            try
            {
                conexion = new SqlConnection();
                conexion.ConnectionString = "Server=tcp:hads21fernandez.database.windows.net,1433;Initial Catalog=Hads21Fernandez;Persist Security Info=False;User ID=AnderFernandez;Password=a0V6voTZ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                conexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
        public static void desconectar() {
            try
            {
                conexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            
        }
        public static string registrar(string email, string nombre, string apellidos, int numConfir, string tipo, string pass)
        {
            if (existeCuenta(email) == 1)
            {
                return "Ya exite una cuenta con ese email";
            }
            else {
                int confirmado = 0;
                int codpass = 0;
                SqlCommand comando = new SqlCommand();
                string st = $"insert into dbo.Usuarios values ('{email}','{nombre}','{apellidos}', {numConfir}, {confirmado}, '{tipo}', '{pass}', {codpass})";
                comando = new SqlCommand(st, conexion);
                try
                {
                    comando.ExecuteNonQuery();
                    return "Se ha registrado correctamente";
                }
                catch (Exception e)
                {
                    return "Ha ocurrido un fallo al registrarse";
                }
                
            }
        }
        public static int  iniciarSesion(string email, string password) {
            SqlCommand comando = new SqlCommand();
            string st = $"select count(*) from dbo.Usuarios where email = '{email}' and pass = '{password}' and confirmado= 1";
            comando = new SqlCommand(st, conexion);
            return (int)comando.ExecuteScalar();
            
        }
        public static int existeCuenta(string email)
        {
            SqlCommand comando = new SqlCommand();
            string st = $"select count(*) from dbo.Usuarios where email = '{email}'";
            comando = new SqlCommand(st, conexion);
            return (int)comando.ExecuteScalar();
        }
        public static string confirmar(string email, int numConf)
        {
            SqlCommand comando = new SqlCommand();
            string st = $"select count(*) from dbo.Usuarios where email = '{email}' and numconfir='{numConf}'";
            comando = new SqlCommand(st, conexion);
            if ((int)comando.ExecuteScalar()==1) {
                st = $"update dbo.Usuarios set confirmado = 1 where email = '{email}'";
                comando = new SqlCommand(st, conexion);
                comando.ExecuteNonQuery();
                return "Su cuenta ha sido verificada";
            }
            return "Error al verificar la cuenta, codigo o email incorrecto";
        }
        public static void sendEmail(string to, string subject, string body) {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.ehu.eus");

            mail.From = new MailAddress("afernandez493@ikasle.ehu.eus");
            mail.To.Add(to);
            mail.Subject = subject;
            //string AbsolutePath = ResolveUrl("~/Confirmar.aspx");
            mail.Body =body;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("916628", "a0V6voTZ");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        public static int CambiarCodPass(string email, int codpass) {
            SqlCommand comando = new SqlCommand();
            string st = $"update dbo.Usuarios set codpass = {codpass} where email = '{email}'";
            comando = new SqlCommand(st, conexion);
            try {
                comando.ExecuteNonQuery();
                return 0;
            }
            catch {
                return 1;
            } 
        }
        public static int confirmarCodpass(string email, int codpass)
        {
            SqlCommand comando = new SqlCommand();
            string st = $"select count(*) from dbo.Usuarios where email = '{email}' and codpass='{codpass}'";
            comando = new SqlCommand(st, conexion);
            if ((int)comando.ExecuteScalar() == 1)
            {
                return 0;
            }
            return 1;
        }
        public static string cambiarPassword(string email, string password) {
            SqlCommand comando = new SqlCommand();
            string st = $"update   dbo.Usuarios set pass='{password}' where email = '{email}'";
            comando = new SqlCommand(st, conexion);
            try
            {
                comando.ExecuteNonQuery();
                return "Se ha modificado correctamente";
            }
            catch
            {
                return "Ha ocurrido un error al modificar la contrasena";
            }
        }
        public static string getRol(string email) {
            SqlCommand comando = new SqlCommand();
            string st = $"select tipo from dbo.Usuarios  where email = '{email}'";
            comando = new SqlCommand(st, conexion);
            SqlDataReader rs = comando.ExecuteReader();
            if (rs.Read()) {
                return rs["tipo"].ToString();
            }
            return "Fallo al buscar el tipo";
        }
        public static DataTable getAsignaturas(string email) {
            string st = $"SELECT GruposClase.codigoasig FROM GruposClase INNER JOIN ProfesoresGrupo ON GruposClase.codigo = ProfesoresGrupo.codigogrupo WHERE ProfesoresGrupo.email ='{email}'";
            SqlDataAdapter adapter = new SqlDataAdapter(st, conexion);
            
            DataSet dataset = new DataSet();
            adapter.Fill(dataset,"EstudiantesTareas");
            DataTable data = dataset.Tables["EstudiantesTareas"];
            return data;
        }
        public static DataTable getAsignaturasAlumnos(string email)
        {
            string st = $"select codigoasig from [dbo].[EstudiantesGrupo] inner join [dbo].[GruposClase] on [dbo].[GruposClase].codigo=[dbo].[EstudiantesGrupo].Grupo  where [dbo].[EstudiantesGrupo].email='{email}'";
            SqlDataAdapter adapter = new SqlDataAdapter(st, conexion);

            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "EstudiantesTareas");
            DataTable data = dataset.Tables["EstudiantesTareas"];
            return data;
        }
        public static DataTable getTareasGenericas()
        {
            string st = $"select * from dbo.TareasGenericas ";
            SqlDataAdapter adapter = new SqlDataAdapter(st, conexion);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "TareasGenericas");
            DataTable data = dataset.Tables["TareasGenericas"];

            return data;
        }
        public static DataSet getInstancias(string email)
        {
            string st = $"select * from dbo.EstudiantesTareas where Email = '{email}'";
            SqlDataAdapter adapter = new SqlDataAdapter(st, conexion);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "EstudiantesTareas");
            return dataset;
        }
        public static bool Instanciar(string email, string codigo, int horasEstimadas, int horasReales,DataSet dataset)
        {
            try
            {
                string st = $"insert into  dbo.EstudiantesTareas values('{email}','{codigo}',{horasEstimadas}, {horasReales})";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(st, conexion);
                adapter.InsertCommand.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            
        }
        public static bool updateTable(string codigo,string descripcion,string codAsig, int horas,string tipoTarea) {
            try {
                string st = $"select * from dbo.TareasGenericas ";
                SqlDataAdapter adapter = new SqlDataAdapter(st, conexion);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "TareasGenericas");
                DataRow dataRow = dataset.Tables[0].NewRow();
                dataRow["Codigo"] = codigo;
                dataRow["Descripcion"] = descripcion;
                dataRow["CodAsig"] = codAsig;
                dataRow["HEstimadas"] = horas;
                dataRow["Explotacion"] = false;
                dataRow["TipoTarea"] = tipoTarea;
                dataset.Tables[0].Rows.Add(dataRow);
                SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = cb.GetUpdateCommand();
                adapter.Update(dataset, "TareasGenericas");
                return true;
            }
            catch { return false; }
            
        }
        public static bool existeTarea(string codigo) {
            string st = $"select count(*) from dbo.TareasGenericas where Codigo ='{codigo}'";
            SqlCommand comando = new SqlCommand(st, conexion);
            int existe = (Int32)comando.ExecuteScalar();
            if ( existe == 0)
            {
                return false;
            }
            return true;
            
        }
        public static SqlDataAdapter TareasGenericasAdapter() {
            string st = $"select * from dbo.TareasGenericas";
            SqlDataAdapter adapter = new SqlDataAdapter(st, conexion);
            return adapter;
        }
        public static SqlDataAdapter TareasGenericasAdapterCodigo(string codigo)
        {
            string st = $"select * from dbo.TareasGenericas where CodAsig='{codigo}'";
            SqlDataAdapter adapter = new SqlDataAdapter(st, conexion);
            return adapter;
        }
        public static string getHashPassword(string normalPass) {
            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
            hash.Initialize();
            string pass = normalPass;
            byte[] hashbytes = hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

            StringBuilder password = new StringBuilder();

            for (int i = 0; i < hashbytes.Length; i++)
            {
                password.Append(hashbytes[i].ToString("x2"));
            }
            pass = password.ToString();
            return pass;
        }
        public static int getHorasMedias(string asignatura) {
            string st = $"select avg([dbo].[EstudiantesTareas].HReales) from [dbo].[EstudiantesTareas] inner join [dbo].[TareasGenericas] on [dbo].[EstudiantesTareas].CodTarea = [dbo].[TareasGenericas].Codigo where [dbo].[TareasGenericas].CodAsig='{asignatura}'";
            SqlCommand comando = new SqlCommand(st, conexion);
            int horasMedias = 0;
            try {
                 horasMedias = (Int32)comando.ExecuteScalar();
            }
            catch {
                 return 0;
            }
           
            return horasMedias;
        }
    }
}
