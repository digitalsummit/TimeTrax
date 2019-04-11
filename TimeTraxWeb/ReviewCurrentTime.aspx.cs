using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
                Session["flavor"] = "All";
                setDefaultDates();
                RadioButtonList1.SelectedValue = "All";
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
            string employeeName = Session["EmployeeName"].ToString();
            DataSet ds = new DataSet();
            string sqlCmdText = string.Empty;
            string flavor = Session["flavor"].ToString();
            sqlCmdText = "GetMyCurrentTimeSheetTotal";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@Employee", employeeName);
                cmd.Parameters.AddWithValue("@beginDate", txtDateBegin.Text);
                cmd.Parameters.AddWithValue("@endDate", txtDateEnd.Text);
                cmd.Parameters.AddWithValue("@flavor", flavor);  // Unapproved, Approved, All
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            lblSumLastWeek.Text = " Previous Week:" +  ds.Tables[0].Rows[0]["SumLastWeek"].ToString();
            lblSumThisWeek.Text = " Shown Week:" + ds.Tables[0].Rows[0]["SumThisWeek"].ToString();
            lblSumNextWeek.Text = " Following Week:" + ds.Tables[0].Rows[0]["SumNextWeek"].ToString();

            lblSumCurrentMonday.Text = "Mon:" + ds.Tables[0].Rows[0]["SumCurrentMonday"].ToString();
            lblSumCurrentTuesday.Text = "Tue:" + ds.Tables[0].Rows[0]["SumCurrentTuesday"].ToString();
            lblSumCurrentWednesday.Text = "Wed:" + ds.Tables[0].Rows[0]["SumCurrentWednesday"].ToString();
            lblSumCurrentThursday.Text = "Thu:" + ds.Tables[0].Rows[0]["SumCurrentThursday"].ToString().Trim();
            lblSumCurrentFriday.Text = "Fri:" + ds.Tables[0].Rows[0]["SumCurrentFriday"].ToString();
            lblSumCurrentSaturday.Text = "Sat:" + ds.Tables[0].Rows[0]["SumCurrentSaturday"].ToString();
            lblSumCurrentSunday.Text = "Sun:" + ds.Tables[0].Rows[0]["SumCurrentSunday"].ToString();
        }

        protected void GetEmployeeName()
        {

            //DataSet ds = new DataSet();
            //string sqlCmdText = string.Empty;
            //sqlCmdText = "select EmployeeName from users where EmailAddress = '" + lblWelcome.Text + "'";
            //SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            //using (conn)
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = sqlCmdText;
            //    cmd.Connection = conn;
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    adapter.Fill(ds);
            //    conn.Close();

            //}
            //if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["EmployeeName"] != null)
            //    lblWelcome.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
            lblWelcome.Text = Session["EmployeeName"].ToString();
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
            string flavor = string.Empty;
            flavor = RadioButtonList1.SelectedValue.ToString();
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
                cmd.Parameters.AddWithValue("@Approved", flavor);
                cmd.Parameters.AddWithValue("@beginDate", txtDateBegin.Text);
                cmd.Parameters.AddWithValue("@endDate", txtDateEnd.Text);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }

            DataTable dt = new DataTable();
            if (ds.Tables.Count != 0)
            { 
                dt = ds.Tables[0];
            }
            else
            {
                dt.Columns.Add(new DataColumn("ID", typeof(string)));
                dt.Columns.Add(new DataColumn("ProjectNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("ProjectName", typeof(string)));
                dt.Columns.Add(new DataColumn("DateWorked", typeof(string)));
                dt.Columns.Add(new DataColumn("Day", typeof(string)));
                dt.Columns.Add(new DataColumn("Employee", typeof(string)));
                dt.Columns.Add(new DataColumn("Hours", typeof(string)));
                dt.Columns.Add(new DataColumn("DriveTime", typeof(string)));
                dt.Columns.Add(new DataColumn("PreProject", typeof(string)));
                dt.Columns.Add(new DataColumn("CorporateEvents", typeof(string)));
                dt.Columns.Add(new DataColumn("training", typeof(string)));
                dt.Columns.Add(new DataColumn("PTO", typeof(string)));
                dt.Columns.Add(new DataColumn("Holiday", typeof(string)));
                dt.Columns.Add(new DataColumn("WageScale", typeof(string)));
                dt.Columns.Add(new DataColumn("Other", typeof(string)));
                dt.Columns.Add(new DataColumn("Notes", typeof(string)));

                DataRow dr = dt.NewRow();
                dr["ProjectName"] = "No data selected";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
            }

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
            //sqlCmdText = "UpdateMyTimeSheetSubstractHalfHour";
            sqlCmdText = "UpdateMyTimeSheetSubstractHour";
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
            // sqlCmdText = "UpdateMyTimeSheetAddHalfHour";
            sqlCmdText = "UpdateMyTimeSheetAddHour";
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

        protected void btnPreviousWeek_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DateTime beginDateValue = DateTime.Now;
            string s = txtDateBegin.Text;
            if (DateTime.TryParse(txtDateBegin.Text, out beginDateValue))
            {
                // do for valid date
                int currentDayOfWeek = (int)beginDateValue.DayOfWeek;
                DateTime endingDate = beginDateValue.AddDays(-currentDayOfWeek);
                txtDateBegin.Text = endingDate.AddDays(-6).ToShortDateString();
                txtDateEnd.Text = endingDate.ToShortDateString();
                GridView1_GetData();
            }
            else
            {
                // do for invalid date
                int currentDayOfWeek = (int)DateTime.Now.DayOfWeek;
                DateTime endingDate = DateTime.Now.AddDays(-currentDayOfWeek);
                txtDateBegin.Text = endingDate.AddDays(-6).ToShortDateString();
                txtDateEnd.Text = endingDate.ToShortDateString();
                GridView1_GetData();
            }

           
        }

        protected void btnNextWeek_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DateTime beginDateValue = DateTime.Now;
            string s = txtDateBegin.Text;
            if(DateTime.TryParse(txtDateBegin.Text,out beginDateValue))
            {
                // do for valid date
                DateTime beginDate = Convert.ToDateTime(txtDateBegin.Text);
                beginDate = beginDate.AddDays(7);
                txtDateBegin.Text = beginDate.ToShortDateString();
                txtDateEnd.Text = beginDate.AddDays(6).ToShortDateString();
                GridView1_GetData();
            }
            else
            {
                // do for invalid date
                DateTime beginDate = Convert.ToDateTime(txtDateBegin.Text);
                beginDate = beginDate.AddDays(7);
                txtDateBegin.Text = beginDate.ToShortDateString();
                txtDateEnd.Text = beginDate.AddDays(6).ToShortDateString();
                GridView1_GetData();
            }
       
        }

        protected void setDefaultDates()
        {
            //int currentDayOfWeek = (int)DateTime.Now.DayOfWeek;
            //DateTime endingDate = DateTime.Now.AddDays(-currentDayOfWeek);
            //txtDateBegin.Text = endingDate.AddDays(-6).ToShortDateString();
            //txtDateEnd.Text = endingDate.ToShortDateString();

            int currentDayOfWeek = (int)DateTime.Now.DayOfWeek;
            int daysToAddForEndDate = (7 - currentDayOfWeek);
            DateTime endingDate = DateTime.Now.AddDays(daysToAddForEndDate);
            txtDateBegin.Text = endingDate.AddDays(-6).ToShortDateString();
            txtDateEnd.Text = endingDate.ToShortDateString();

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1_GetData();
        }

        protected void btnSubtractDay_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            GridView1.EnableViewState = true;

            string SortDirection = GridView1.SortDirection.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            //sqlCmdText = "UpdateMyTimeSheetSubstractHalfHour";
            sqlCmdText = "UpdateMyTimesheetSubtractDay";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@beginDate", txtDateBegin.Text);
                cmd.Parameters.AddWithValue("@endDate", txtDateEnd.Text);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            GridView1_GetData();

        }

        protected void btnAddDay_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            GridView1.EnableViewState = true;

            string SortDirection = GridView1.SortDirection.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            //sqlCmdText = "UpdateMyTimeSheetSubstractHalfHour";
            sqlCmdText = "UpdateMyTimesheetAddDay";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@beginDate", txtDateBegin.Text);
                cmd.Parameters.AddWithValue("@endDate", txtDateEnd.Text);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            GridView1_GetData();

        }

    }
}
