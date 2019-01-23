using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;



namespace TimeTrax
{
    public partial class ReviewCurrentTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["sortExp"] = null;
            }

            lblWelcome.Text = HttpContext.Current.User.Identity.Name;
            GetEmployeeName();
            GridView1_GetData();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Attributes["width"] = "70px";
            //e.Row.Cells[3].Attributes["width"] = "300px";
            //e.Row.Cells[4].Attributes["width"] = "77px";
        }
        protected void GetTotalHours()
        {
            
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
            lblSumHours.Text = "Total shown: " + ds.Tables[0].Rows[0]["SumHours"].ToString();
            lblSumLastWeek.Text = " Last Week:" +  ds.Tables[0].Rows[0]["SumLastWeek"].ToString();
            lblSumThisWeek.Text = " This Week:" + ds.Tables[0].Rows[0]["SumThisWeek"].ToString();
            lblSumNextWeek.Text = " Next Week:" + ds.Tables[0].Rows[0]["SumNextWeek"].ToString();

            lblSumCurrentMonday.Text = " Mon: " + ds.Tables[0].Rows[0]["SumCurrentMonday"].ToString();
            lblSumCurrentTuesday.Text = " Tues: " + ds.Tables[0].Rows[0]["SumCurrentTuesday"].ToString();
            lblSumCurrentWednesday.Text = " Wed: " + ds.Tables[0].Rows[0]["SumCurrentWednesday"].ToString();
            lblSumCurrentThursday.Text = " Thurs: " + ds.Tables[0].Rows[0]["SumCurrentThursday"].ToString();
            lblSumCurrentFriday.Text = " Fri: " + ds.Tables[0].Rows[0]["SumCurrentFriday"].ToString();
            lblSumCurrentSaturday.Text = " Sat: " + ds.Tables[0].Rows[0]["SumCurrentSaturday"].ToString();
            lblSumCurrentSunday.Text = " Sun: " + ds.Tables[0].Rows[0]["SumCurrentSunday"].ToString();
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
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["EmployeeName"] != null)
                lblWelcome.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
        }

        protected void btnLastWeek_Click(object sender, EventArgs e)
        {

        }
       
        protected void updateGridView1(string sRowID)
        {
            GridView1.EnableViewState = true;

            string SortDirection = GridView1.SortDirection.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "UpdateMyTimeSheet";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@sRowID", sRowID);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            GridView1_GetData();
        }

        protected void GridView1_GetData()
        {

            string sortExp = string.Empty;
            // if (Session["LoggedIn"]) !=null)
            if (Session["sortExp"] != null)
            {
                sortExp = Session["sortExp"].ToString();
            }

            else
            {
                Session["sortExp"] = "ID";
            }

            string employeeName = lblWelcome.Text;
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "GetMyCurrentTimeSheet";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@Employee", employeeName);
                cmd.Parameters.AddWithValue("@Approved", "Not Approved");
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            DataTable dt = ds.Tables[0];

            DataView dv = dt.DefaultView;
            dv.Sort = sortExp;
            DataTable sortedDT = dv.ToTable();
            Session["timesheet"] = sortedDT;
            if (dt != null)
            {
                GridView1.DataSource = sortedDT;
                GridView1.DataBind();
            }
            GetTotalHours();

        }
          
             
        protected void lnkDelete(Object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            deleteTimeSheetRow(id);

        }
        protected void lnkSubstractTime(Object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            GridView1.EnableViewState = true;

            string SortDirection = GridView1.SortDirection.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "UpdateMyTimeSheetSubstractHalfHour";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            GridView1_GetData();

        }
        protected void lnkAddTime(Object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            GridView1.EnableViewState = true;

            string SortDirection = GridView1.SortDirection.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "UpdateMyTimeSheetAddHalfHour";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            GridView1_GetData();

        }

        protected void deleteTimeSheetRow(int ID)
        {
            GridView1.EnableViewState = true;

            string SortDirection = GridView1.SortDirection.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "DeleteTimeSheetRow";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            GridView1_GetData();
        }
        // lnkSubstractTime
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            Session["sortExp"] = e.SortExpression.ToString();
            Session["SortOrder"] = GridView1.SortDirection.ToString();
            string sortExp = Session["sortExp"].ToString();
            DataTable dt = Session["timesheet"] as DataTable;
            DataView dv = dt.DefaultView;
            dv.Sort = sortExp;
            DataTable sortedDT = dv.ToTable();
            if (dt != null)
            {

                //Sort the data.
                // dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                // GridView1.DataSource = Session["timesheet"];
                GridView1.DataSource = sortedDT;
                GridView1.DataBind();
            }
        }
    }
}
