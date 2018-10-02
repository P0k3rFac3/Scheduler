using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;



namespace Scheduler
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }
        protected void editButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyAgent.aspx");
        }
    }
}