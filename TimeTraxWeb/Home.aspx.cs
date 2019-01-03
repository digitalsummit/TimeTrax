using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeTrax
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeNameAndUserLevel();

                if (Session["UserLevel"] == null || Session["UserLevel"].ToString() == "Standard User")
                {
                    btnReports.Visible = false;
                    btnApproval.Visible = false;
                }
                


            }
        }

        protected void btnEnterTime_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnterTime.aspx", true);
        }

        protected void btnReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExcelReport1.aspx", true);
        }

        protected void btnApproval_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagerApproval.aspx", true);
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", true);
        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewCurrentTime.aspx");
        }
        protected void GetEmployeeNameAndUserLevel()
        {
            try
            {
                DataSet ds = new DataSet();
                string sqlCmdText = string.Empty;
                sqlCmdText = "GetEmployeeNameAndUserLevel";
                SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sqlCmdText;

                    cmd.Parameters.AddWithValue("@email", HttpContext.Current.User.Identity.Name);
                    //cmd.Parameters.AddWithValue("@email", Session["EmployeeEmail"].ToString());
                    cmd.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    conn.Close();

                }
                Session["EmployeeName"] = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                Session["UserLevel"] = ds.Tables[0].Rows[0]["UserLevel"].ToString();
                lblUserName.Text = Session["EmployeeName"].ToString();
            }
            catch(Exception ex)
            {
                lblUserName.Text = ex.ToString();
            }
        }

    }
}