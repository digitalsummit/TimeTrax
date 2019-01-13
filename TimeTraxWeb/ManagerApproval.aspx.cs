using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TimeTrax
{
    public partial class ManagerApproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                FillDropDownList1();

            }
        }

        protected void FillDropDownList1()
        {
            string sqlCmdText = string.Empty;
            string managerID = "18";
            DataSet ds = new DataSet();
            sqlCmdText = "FillEmployeeListByManager";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@Manager", managerID);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
            }
            int UserDataRowCount = ds.Tables[0].Rows.Count;
            DropDownList1.Items.Add("Select Employee");
            for (int i = 0; i < UserDataRowCount; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i]["EmployeeName"].ToString());
            }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.ToString() == "Approve")
            {
                GridViewRow row = GridView1.SelectedRow;
                string sRowId = row.Cells[0].ToString();
                updateGridView1Approved(sRowId);
                GridView1.DataBind();
                
            }
        }

        protected void updateGridView1Approved(string sRowID)
        {
            GridView1.EnableViewState = true;
            
            string SortDirection = GridView1.SortDirection.ToString();
            string employeeName = DropDownList1.SelectedItem.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "UpdateApproved";
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

            string employeeName = DropDownList1.SelectedItem.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            // sqlCmdText = "GetCurrentTimeSheetForApproval";
            sqlCmdText = "[GetCurrentTimeSheetForApprovalShowHours]";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@Employee", employeeName);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            DataTable dt = ds.Tables[0];

            //GridView1.DataSource = ds.Tables[0];
            
            //
            //DataTable dt = Session["timesheet"] as DataTable;
            DataView dv = dt.DefaultView;
            dv.Sort = sortExp;
            DataTable sortedDT = dv.ToTable();
            Session["timesheet"] = sortedDT;
            if (dt != null)
            {

                //Sort the data.
                // dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                // GridView1.DataSource = Session["timesheet"];
                GridView1.DataSource = sortedDT;
                GridView1.DataBind();
            }
            //
            //GridView1.DataSource = timesheet;
            //GridView1.DataSource = Session["timesheet"];
            //GridView1.DataBind();

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Attributes["width"] = "70px";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1_GetData();
            btnApproveAll.Text =  "Approve All time for: " + DropDownList1.SelectedValue.ToString();
            btnApproveAll.Visible = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string sRowID = row.Cells[0].Text.ToString();
            updateGridView1Approved(sRowID);

        }


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
        

        protected void btnApproveAll_Click(object sender, EventArgs e)
        {
            string employeeName = DropDownList1.SelectedItem.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "UpdateApprovedAllforEmployee";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@employeeName", employeeName);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            GridView1_GetData();
        }

       
    }
}