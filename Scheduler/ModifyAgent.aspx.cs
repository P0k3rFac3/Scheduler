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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateAgentList();
            if (!IsPostBack) // If page loads for first time
            {
                // Assign the Session["update"] with unique value
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
            

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString);
                conn.Open();
                string checkAgentName = "Select count(*) from Reg where username='" + agentName.Text + "'";
                SqlCommand com = new SqlCommand(checkAgentName, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp ==1)
                {
                    Response.Write("User already exists");
                }
                conn.Close();
                
            }
            

        }

        protected void agentAddButton_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                try
                {

                    Guid newGuid = Guid.NewGuid();
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString);
                    conn.Open();
                    string insertQuery = "insert into Agents(id, AgentName, StartTime, Lunch, EndTime) values (@id, @agentName, @agentStart, @agentLunch, @agentEnd)";
                    SqlCommand com = new SqlCommand(insertQuery, conn);
                    com.Parameters.AddWithValue("@id", newGuid);
                    com.Parameters.AddWithValue("@agentName", agentName.Text);
                    com.Parameters.AddWithValue("@agentStart", agentStart.Text);
                    com.Parameters.AddWithValue("@agentLunch", agentLunch.Text);
                    com.Parameters.AddWithValue("@agentEnd", agentEnd.Text);
                    com.ExecuteNonQuery();
                    Response.Write(agentName.Text + " has been successfully added!");

                    conn.Close();
                    populateAgentList();
                    agentName.Text = "";
                    agentStart.Text = "";
                    agentEnd.Text = "";
                    agentLunch.Text = "";
                    Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                }



                catch (Exception ex)
                {
                    Response.Write("Error:" + ex.ToString());
                }
            }
            else // If Page Refreshed
            {
                // Do nothing 
            }
        }

        protected void viewSchedule_Click(object sender, EventArgs e)
        {
            Response.Redirect("Schedule.aspx");
        }

        protected void update_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString);
                conn.Open();
                string updateQuery = "update Agents set StartTime = @agentStart, Lunch = @agentLunch, EndTime = @agentEnd where AgentName='"+agentListDown.Text+"'";
                SqlCommand com = new SqlCommand(updateQuery, conn);
            
                com.Parameters.AddWithValue("@agentStart", startDown.Text);
                com.Parameters.AddWithValue("@agentLunch",lunchDown.Text);
                com.Parameters.AddWithValue("@agentEnd", endDown.Text);
                com.ExecuteNonQuery();
                Response.Write(agentListDown.Text + "'s Timings have been successfully Updated!");

                conn.Close();

                //conn.Open();
                //string selecaList = "select AgentName from Agents";
                //SqlCommand com2 = new SqlCommand(selecaList, conn);
                //com2.ExecuteNonQuery();
                populateAgentList();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }

        }
        protected override void OnPreRender(EventArgs e)
        {
            ViewState["update"] = Session["update"];
        }

        protected void agentListDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateAgentList();
        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        protected void populateAgentList()
        {
            agentListDown.DataSource = SqlDataSource2;
            agentListDown.DataValueField = "id";
            agentListDown.DataTextField = "AgentName";
            agentListDown.DataBind();
        }
    }
}