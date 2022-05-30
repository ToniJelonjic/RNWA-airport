using System.Web.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using System.Data;

namespace WebApp
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [System.Web.Services.WebMethod]
        public DataTable getEmployee(int id)
        {
            string connString = "SERVER=localhost" + ";" +
                "PORT=3307;" +
                "DATABASE=airportdb;" +
                "UID=root;" +
                "PASSWORD=;";

            MySqlConnection cnMySQL = new MySqlConnection(connString);

            MySqlCommand cmdMySQL = cnMySQL.CreateCommand();

            MySqlDataReader reader;

            cmdMySQL.CommandText = "select * from employee WHERE employee_id=" + id;

            cnMySQL.Open();
            
            reader = cmdMySQL.ExecuteReader();
           

            DataTable dt = new DataTable();
            

            dt.Load(reader);
        

            cnMySQL.Close();
            



            return dt;
        }
    }
}
