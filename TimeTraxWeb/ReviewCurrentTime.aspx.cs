using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace TimeTrax
{
    public partial class ReviewCurrentTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = Session["EmployeeEmail"].ToString();
            GetEmployeeName();
            GetTotalHours();
        }

        //protected void btnEnterTime_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("EnterTime.aspx", true);
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Attributes["width"] = "70px";
            //e.Row.Cells[3].Attributes["width"] = "300px";
            //e.Row.Cells[4].Attributes["width"] = "77px";
        }
        protected void GetTotalHours()
        {
            string returnVal = "No Data";
            DataSet ds = new DataSet();
            string sqlCmdText = string.Empty;
            sqlCmdText = "GetMyCurrentTimeSheetTotal";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@Employee", lblWelcome.Text);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            returnVal = ds.Tables[0].Rows[0]["SumHours"].ToString();
            lblTotalHours.Text = returnVal + " Hours";

        }
        protected void GetEmployeeName()
        {
            DataSet ds = new DataSet();
            string sqlCmdText = string.Empty;
            sqlCmdText = "select EmployeeName from users where EmailAddress = '" + lblWelcome.Text + "'";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlCmdText;
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            lblWelcome.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx", true);
        }
    }
    }
