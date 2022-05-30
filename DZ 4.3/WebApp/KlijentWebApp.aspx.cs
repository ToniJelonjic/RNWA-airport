using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class KlijentWebApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Reference.WebService1SoapClient klijent = new Reference.WebService1SoapClient("WebService1Soap");
            int id = int.Parse(Id.Text);
            System.Data.DataTable rezultat = klijent.getEmployee(id);
            gvUsers.DataSource = rezultat;
            gvUsers.DataBind();


        }
    }
}