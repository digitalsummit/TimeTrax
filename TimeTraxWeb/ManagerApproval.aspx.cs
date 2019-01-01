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
            string employeeName = DropDownList1.SelectedItem.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "GetCurrentTimeSheetForApproval";
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
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Attributes["width"] = "70px";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1_GetData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string sRowID = row.Cells[0].Text.ToString();
            updateGridView1Approved(sRowID);

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", true);
        }
    }
}