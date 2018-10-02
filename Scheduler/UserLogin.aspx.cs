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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString);
            conn.Open();
            string checkUser = "Select count(*) from Reg where username='" + userNameTextBox.Text + "'";
            SqlCommand com = new SqlCommand(checkUser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                string checkPassword = "Select password from reg where username='" + userNameTextBox.Text + "'";
                SqlCommand passComm = new SqlCommand(checkPassword, conn);
                string password = passComm.ExecuteScalar().ToString();
                if (password == passwordTextBox.Text)
                {
                    Session["New"] = userNameTextBox.Text;
                    Response.Write("Password is correct");
                }
                else
                {
                    Response.Write("Password is incorrect");
                }
            }
            else
            {
                Response.Write("Username is incorrect");
            }
            }
        }
    }
