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
    public partial class FAQEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetFAQData();
                // Button btnAddNew = (Button)this.FormView1.FindControl("btnAddNew");
                //btnAddNew.Enabled = true;
                btnAddNew.BackColor = System.Drawing.Color.Yellow;
                lblSaved.Text = string.Empty;

            }
            
        }
        protected void GetFAQData()
        {

            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "GetFAQDataForEdit";
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
            //DataView dv = dt.DefaultView;
            //DataTable sortedDT = dv.ToTable();
            if (dt != null)
            {
                FormView1.DataSource = dt;
                FormView1.DataBind();
               Session["NumberOfRecords"] = dt.Rows.Count;
                //GridView1.DataSource = sortedDT;
                //GridView1.DataBind();
            }
        }

        protected void btnPrevious_Click(object sender, ImageClickEventArgs e)
        {
            if (FormView1.PageIndex >= 0)
            {
                GetFAQData();
                FormView1.PageIndex = FormView1.PageIndex - 1;
                FormView1.DataBind();
            }
            lblBottom.Text = FormView1.PageIndex.ToString();
            lblSaved.Text = string.Empty;
        }

        protected void btnNext_Click(object sender, ImageClickEventArgs e)
        {
            int NumberOfRecords = Convert.ToInt16(Session["NumberOfRecords"].ToString());
            if (FormView1.PageIndex <= NumberOfRecords)
            {
                GetFAQData();
                FormView1.PageIndex = FormView1.PageIndex + 1;
                FormView1.DataBind();
            }
            lblBottom.Text = FormView1.PageIndex.ToString();
            lblSaved.Text = string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
    {
        int ID = 0;
        bool newRecord = false;
        Label lblIDnumber = (Label)this.FormView1.FindControl("lblID");
        TextBox txtQuestion = (TextBox)this.FormView1.FindControl("txtQuestion");
        TextBox txtAnswer = (TextBox)this.FormView1.FindControl("txtAnswer");
        TextBox txtSortOrder = (TextBox)this.FormView1.FindControl("txtSortOrder");
        CheckBox cbActive = (CheckBox)this.FormView1.FindControl("cbActive");
        TextBox txtVideoLink = (TextBox)this.FormView1.FindControl("txtVideoLink");
        ID = Convert.ToInt16(lblIDnumber.Text);
        if (ID == 0)
        {
            newRecord = true;
        }
        string question = txtQuestion.Text;
        string answer = txtAnswer.Text;
        string sortOrder = txtSortOrder.Text;
        bool active = cbActive.Checked;
        string videoLink = txtVideoLink.Text;

        // ---------------
        string sqlCmdText = string.Empty;
        DataSet ds = new DataSet();
        sqlCmdText = "UpdateFAQ";
        SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
        using (conn)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sqlCmdText;
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Question", question);
            cmd.Parameters.AddWithValue("@Answer", answer);
            cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
            cmd.Parameters.AddWithValue("@Active", active);
            cmd.Parameters.AddWithValue("@VideoLink", videoLink);
            cmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            ID = Convert.ToInt16(ds.Tables[0].Rows[0]["ID"].ToString());
            conn.Close();

        }
        GetFAQData();
        //btnAddNew.Enabled = true;
        btnAddNew.BackColor = System.Drawing.Color.Yellow;
        lblBottom.Text = FormView1.PageIndex.ToString();
        //lblBottom.BackColor = System.Drawing.Color.Yellow;
        if (newRecord == true)
        {
            int NumberOfRecords = Convert.ToInt16(Session["NumberOfRecords"].ToString());
            FormView1.PageIndex = FormView1.PageIndex + (NumberOfRecords - FormView1.PageIndex);
            FormView1.DataBind();

            lblBottom.Text = FormView1.PageIndex.ToString();
            lblSaved.Text = "Saved";


        }
    }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Label lblIDnumber = (Label)this.FormView1.FindControl("lblID");
            TextBox txtQuestion = (TextBox)this.FormView1.FindControl("txtQuestion");
            TextBox txtAnswer = (TextBox)this.FormView1.FindControl("txtAnswer");
            TextBox txtSortOrder = (TextBox)this.FormView1.FindControl("txtSortOrder");
            CheckBox cbActive = (CheckBox)this.FormView1.FindControl("cbActive");
            TextBox txtVideoLink = (TextBox)this.FormView1.FindControl("txtVideoLink");
            Button btnAddNew = (Button)this.FormView1.FindControl("btnAddNew");
            lblIDnumber.Text = "0";
            txtQuestion.Text = string.Empty;
            txtAnswer.Text = string.Empty;
            txtSortOrder.Text = string.Empty;
            cbActive.Checked = true;
            txtVideoLink.Text = string.Empty;
            lblSaved.Text = string.Empty;
        }

        protected void btnFirstRecord_Click(object sender, ImageClickEventArgs e)
        {
            if (FormView1.PageIndex > 0)
            {
                GetFAQData();
                FormView1.PageIndex = 0;
                FormView1.DataBind();
            }
            lblSaved.Text = string.Empty;
        }

        protected void btnLastRecord_Click(object sender, ImageClickEventArgs e)
        {

            GetFAQData();
            int NumberOfRecords = Convert.ToInt16(Session["NumberOfRecords"].ToString());
            FormView1.PageIndex = FormView1.PageIndex + (NumberOfRecords - FormView1.PageIndex);
            FormView1.DataBind();

            lblBottom.Text = FormView1.PageIndex.ToString();
            lblSaved.Text = string.Empty;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            divWarning.Visible = true;
            divButtonArea.Visible = false;
            lblBottom.Text = "Delete Record?";
            lblBottom.ForeColor = System.Drawing.Color.Red;
            lblBottom.Font.Bold = true;
            lblSaved.Text = string.Empty;
        }

        protected void btnDeleteOK_Click(object sender, EventArgs e)
        {
            // DeleteFAQ
            int ID = 0;
            Label lblIDnumber = (Label)this.FormView1.FindControl("lblID");
            ID = Convert.ToInt16(lblIDnumber.Text);
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "DeleteFAQ";
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

            GetFAQData();
            FormView1.DataBind();
            divWarning.Visible = false;
            divButtonArea.Visible = true;
            lblBottom.Text = string.Empty;
            lblBottom.ForeColor = System.Drawing.Color.Black;
            lblBottom.Font.Bold = false;
            lblSaved.Text = string.Empty;


        }

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            divWarning.Visible = false;
            lblBottom.Text = FormView1.PageIndex.ToString();
            lblBottom.ForeColor = System.Drawing.Color.Black;
            lblBottom.Font.Bold = false;
            divButtonArea.Visible = true;
            lblSaved.Text = string.Empty;
        }
    }
}