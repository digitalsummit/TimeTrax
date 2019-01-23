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
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLevel"].ToString() != "Finance")
                divNotAuthorized.Visible = true;
            else
                divAuthorized.Visible = true;

            if (!IsPostBack)
            {
                GetUserData();

            }

        }

        protected void GetUserData()
       {
            string sortExp = string.Empty;

            if (Session["sortExp"] != null)
            {
                sortExp = Session["sortExp"].ToString();
            }

            else
            {
                Session["sortExp"] = "EmployeeName";
            }

            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "GetUserData";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;
            dv.Sort = sortExp;
            DataTable sortedDT = dv.ToTable();
            Session["Userlist"] = sortedDT;
            if (dt != null)
                {
                GridView1.DataSource = sortedDT;
                GridView1.DataBind();
                }
      }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = Session["Userlist"];
            GridView1.DataBind();
            // GetUserData();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView1.EnableViewState = true;
            string SortDirection = GridView1.SortDirection.ToString();
            string sortExp = GridView1.SortExpression.ToString();
            Session["sortExp"] = sortExp;
            // find id of edit row
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            // find updated values for update
            TextBox GridEmployeeName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmployeeName");
            string EmployeeName = GridEmployeeName.Text;

            TextBox GridEmailAddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmailAddress");
            string EmailAddress = GridEmailAddress.Text;

            TextBox GridManagerID = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtManagerID");
            string ManagerID = GridManagerID.Text;

            TextBox GridUserLevel = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUserLevel");
            string UserLevel = GridUserLevel.Text;

            TextBox GridCostPerHour = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCostPerHour");
            string CostPerHour = GridCostPerHour.Text;


            GridView1.EnableViewState = true;
            
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "UpdateUsers";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress);
                cmd.Parameters.AddWithValue("@ManagerID", ManagerID);
                cmd.Parameters.AddWithValue("@UserLevel", UserLevel);
                cmd.Parameters.AddWithValue("@CostPerHour", CostPerHour);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //adapter.Fill(ds);
                conn.Close();

            }

            GridView1.EditIndex = -1;
            GetUserData();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = Session["Userlist"];
            GridView1.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            Session["sortExp"] = e.SortExpression.ToString();
            Session["SortOrder"] = GridView1.SortDirection.ToString();
            string sortExp = Session["sortExp"].ToString();
            DataTable dt = Session["Userlist"] as DataTable;
            DataView dv = dt.DefaultView;
            dv.Sort = sortExp;
            DataTable sortedDT = dv.ToTable();
            if (dt != null)
            {

                //Sort the data.
                GridView1.DataSource = sortedDT;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            // sqlCmdText = "DeleteUser";
            sqlCmdText = "UpdateUserInActive";
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
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conn.Close();

            }
            GetUserData();
            GridView1.EditIndex = -1;

        }

        protected void btnShowAddUser_Click(object sender, EventArgs e)
        {
            FillDropDownList_ddlUserLevel();
            divAddUser.Visible = true;
            btnShowAddUser.Visible = false;
        }

        protected void btnAddThisUser_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sqlCmdText = string.Empty;
            sqlCmdText = "InsertUserRecord";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@EmployeeName", txtAddEmployeeName.Text);
                cmd.Parameters.AddWithValue("@EmailAddress", txtAddEmailAddress.Text);
                cmd.Parameters.AddWithValue("@ManagerID", Convert.ToInt16(txtAddManagerID.Text));
                cmd.Parameters.AddWithValue("@UserLevel", ddlUserLevel.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@CostPerHour", txtAddCostPerHour.Text);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conn.Close();

            }

            GetUserData();
            GridView1.EditIndex = -1;
            divAddUser.Visible = false;
            lblMessageBox.Text = "User Added";
            btnShowAddUser.Visible = true;
            divMessage.Visible = true;
        }
        protected void FillDropDownList_ddlUserLevel()
        {
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "FillListOfUserLevels";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
            }
            int UserDataRowCount = ds.Tables[0].Rows.Count;
            ddlUserLevel.Items.Add("Select User Level");
            for (int i = 0; i < UserDataRowCount; i++)
            {
                ddlUserLevel.Items.Add(ds.Tables[0].Rows[i]["UserLevel"].ToString());
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            divMessage.Visible = false;
        }
    }
}