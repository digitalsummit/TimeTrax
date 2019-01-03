using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TimeTrax
{
    public partial class EnterTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlHoursAddTimes();
                Calendar1.SelectedDate = Calendar1.TodaysDate;
                //lblWelcome.Text = "Submit time for: " + Session["EmployeeName"].ToString();
                lblWelcome.Text = HttpContext.Current.User.Identity.Name;
                //txtDateWorked.Text = Calendar1.SelectedDate.ToShortDateString();
                txtDateWorked.Text = DateTime.Now.ToShortDateString();
                divCalendar.Visible = false;
                Tab1.CssClass = "Clicked";
                Tab2.CssClass = "Initial";
                MainView.ActiveViewIndex = 0;
                cbWageScale.Visible = false;
            }
        }

        protected void Calendar1_PreRender(object sender, EventArgs e)
        {
            // Calendar1.SelectedDate = Calendar1.TodaysDate;
            txtDateWorked.Text = Calendar1.SelectedDate.ToShortDateString();
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDateWorked.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
      
        protected string GetProjectName(string ProjectId)
        {
            string returnVal = "Not Found";
            DataSet ds = new DataSet();
            string sqlCmdText = string.Empty;
            sqlCmdText = "GetProjectName";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@ProjectID", ProjectId);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();

            }
            returnVal = ds.Tables[0].Rows[0]["ProjectName"].ToString();
            return returnVal;
        }


        protected void Calendar1_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
        {
            //if (e.Day.Date > DateTime.Today)
            //{
            //    e.Day.IsSelectable = false;
            //}
        }

        protected void btnGetProjectName_Click(object sender, EventArgs e)
        {
            int ProjectID;
            if (int.TryParse(txtProjectNumber.Text, out ProjectID))
            {
                txtProjectName.Text = GetProjectName(txtProjectNumber.Text);
            }


        }
        protected void ddlHoursAddTimes()
        {
            ddlHours.Items.Insert(0, new ListItem("12", "12"));
            ddlHours.Items.Insert(0, new ListItem("11.5", "11.5"));
            ddlHours.Items.Insert(0, new ListItem("11", "11"));
            ddlHours.Items.Insert(0, new ListItem("10.5", "10.5"));
            ddlHours.Items.Insert(0, new ListItem("10", "10"));
            ddlHours.Items.Insert(0, new ListItem("9.5", "9.5"));
            ddlHours.Items.Insert(0, new ListItem("9", "9"));
            ddlHours.Items.Insert(0, new ListItem("8.5", "8.5"));
            ddlHours.Items.Insert(0, new ListItem("8", "8"));
            ddlHours.Items.Insert(0, new ListItem("7.5", "7.5"));
            ddlHours.Items.Insert(0, new ListItem("7", "7"));
            ddlHours.Items.Insert(0, new ListItem("6.5", "6.5"));
            ddlHours.Items.Insert(0, new ListItem("6", "6"));
            ddlHours.Items.Insert(0, new ListItem("5.5", "5.5"));
            ddlHours.Items.Insert(0, new ListItem("5", "5"));
            ddlHours.Items.Insert(0, new ListItem("4.5", "4.5"));
            ddlHours.Items.Insert(0, new ListItem("4", "4"));
            ddlHours.Items.Insert(0, new ListItem("3.5", "3.5"));
            ddlHours.Items.Insert(0, new ListItem("3", "3"));
            ddlHours.Items.Insert(0, new ListItem("2.5", "2.5"));
            ddlHours.Items.Insert(0, new ListItem("2", "2"));
            ddlHours.Items.Insert(0, new ListItem("1.5", "1.5"));
            ddlHours.Items.Insert(0, new ListItem("1", "1"));
            ddlHours.Items.Insert(0, new ListItem(".5", ".5"));
            ddlHours.Items.Insert(0, new ListItem("0", "0"));

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (SubmitTimeRecord() != "Success")
            {
                //lblSubmitView1.Text = "Error. Review and retry";
                lblSubmitView2.Text = "Error. Review and retry";
                divCalendar.Visible = false;
            }
            else
            {
                //lblSubmitView1.Text = "Saved. Ready for more.";
                lblSubmitView2.Text = "Saved. Ready for more.";
                SetCheckBoxesToFalse();
                cbProjectNumber.Checked = true;
                divCalendar.Visible = false;
                //this.View1.Focus();
                //View ViewSetter = FindControl("View1") as View;
                MainView.SetActiveView(View1);

            }
        }

        protected string SubmitTimeRecord()
        {
            string returnVal = "Error";
            string employeeName = lblWelcome.Text.Replace("Submit time for: ", "");
            int projectChecked = (cbProjectNumber.Checked == true) ? 1 : 0;
            int preProject = (cbPreProject.Checked == true) ? 1 : 0;
            int strategicInit = (cbStrategicInitiative.Checked == true) ? 1 : 0;
            int training = (cbTraining.Checked == true) ? 1 : 0;
            int Other = (cbOther.Checked == true) ? 1 : 0;
            int wageScale = (cbWageScale.Checked == true) ? 1 : 0;
            int driveTime = (cbDriveTime.Checked == true) ? 1 : 0;
            int PTO = (cbPTO.Checked == true) ? 1 : 0;

            if (Other == 1)
            {
                txtPreProjectNotes.Text = txtOther.Text;

            }

            string projectName = string.Empty;
            projectName = txtProjectName.Text.Trim();
            if (projectName.Length > 50) projectName = projectName.Substring(0, 49);
            try
            {

                DataSet ds = new DataSet();
                string sqlCmdText = string.Empty;
                sqlCmdText = "InsertTimeSheetRecord";
                SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sqlCmdText;
                    cmd.Parameters.AddWithValue("@ProjectNumber", txtProjectNumber.Text);
                    cmd.Parameters.AddWithValue("@ProjectName", projectName);
                    cmd.Parameters.AddWithValue("@DateWorked", txtDateWorked.Text);
                    cmd.Parameters.AddWithValue("@Employee", employeeName);
                    cmd.Parameters.AddWithValue("@Hours", ddlHours.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@WageScale", wageScale);
                    cmd.Parameters.AddWithValue("@DriveTime", driveTime);
                    cmd.Parameters.AddWithValue("@PreProject", preProject);
                    cmd.Parameters.AddWithValue("@StrategicInitiative", strategicInit);
                    cmd.Parameters.AddWithValue("@Training", training);
                    cmd.Parameters.AddWithValue("@Other", Other);
                    cmd.Parameters.AddWithValue("@PTO", PTO);
                    cmd.Parameters.AddWithValue("@Notes", txtPreProjectNotes.Text);
                    cmd.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds); //maybe not fill, but datawriter?
                    conn.Close();

                }
                ddlHours.SelectedValue = "0";
                txtProjectNumber.Text = string.Empty;
                txtProjectName.Text = string.Empty;
                txtPreProjectNotes.Text = string.Empty;
                txtOther.Text = string.Empty;
                returnVal = "Success";
            }
            catch(Exception ex)
            {
                returnVal = ex.ToString();

            }
              
            return returnVal;
        }

        protected void txtProjectNumber_TextChanged(object sender, EventArgs e)
        {
            lblSubmitView2.Text = string.Empty;
        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewCurrentTime.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", true);
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            divCalendar.Visible = true;
            Calendar1.Visible = true;
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            tblView1.CssClass = "SelectedView";
            tblView2.CssClass = "UnselectedView";
            MainView.ActiveViewIndex = 0;
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";
            tblView2.CssClass = "SelectedView";
            tblView1.CssClass = "UnselectedView";
            MainView.ActiveViewIndex = 1;
        }

        protected void cbPreProject_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbPreProject.Checked = true;
            //cbPreProject.BackColor = System.Drawing.Color.LightGreen;

        }

        protected void cbTraining_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbTraining.Checked = true;
            //cbTraining.BackColor = System.Drawing.Color.LightGreen;

        }

        protected void cbStrategicInitiative_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbStrategicInitiative.Checked = true;
            //cbStrategicInitiative.BackColor = System.Drawing.Color.LightGreen;
        }

        protected void cbOther_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbOther.Checked = true;
            //cbOther.BackColor = System.Drawing.Color.LightGreen;
        }

        protected void SetCheckBoxesToFalse()
        {
            cbProjectNumber.Checked = false;
            //cbProjectNumber.BackColor = System.Drawing.Color.White;
            cbStrategicInitiative.Checked = false;
            //cbStrategicInitiative.BackColor = System.Drawing.Color.White;
            cbPreProject.Checked = false;
            //cbPreProject.BackColor = System.Drawing.Color.White;
            cbOther.Checked = false;
            //cbOther.BackColor = System.Drawing.Color.White;
            cbTraining.Checked = false;
            //cbTraining.BackColor = System.Drawing.Color.White;
            cbPTO.Checked = false;

        }

        protected void ddlHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSubmitView2.Text = string.Empty;
        }

        protected void cbWageScale_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbWageScale.Checked == true)
            //{
            //    cbWageScale.BackColor = System.Drawing.Color.LightGreen;
            //}
            //else
            //    cbWageScale.BackColor = System.Drawing.Color.White;
        }

        protected void cbDriveTime_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbDriveTime.Checked == true)
            //{
            //    cbDriveTime.BackColor = System.Drawing.Color.LightGreen;
            //}
            //else
            //    cbDriveTime.BackColor = System.Drawing.Color.White;
        }

        protected void cbProjectNumber_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbProjectNumber.Checked = true;
        }

        protected void cbPTO_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbPTO.Checked = true;
        }
    }
}