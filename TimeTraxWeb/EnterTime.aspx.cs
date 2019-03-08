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
                GetEmployeeNameAndUserLevel();
                //Calendar1.SelectedDate = Calendar1.TodaysDate;
                lblWelcome.Text = "Submit time for: " + Session["EmployeeName"].ToString();
                //lblWelcome.Text = HttpContext.Current.User.Identity.Name;
                //txtDateWorked.Text = Calendar1.SelectedDate.ToShortDateString();
                //txtDateWorked.Text = DateTime.Now.ToShortDateString();
                //divCalendar.Visible = false;
                Tab1.CssClass = "Clicked";
                Tab2.CssClass = "Initial";
                MainView.ActiveViewIndex = 0;
                txtDateWorked.Text = DateTime.Today.ToShortDateString();
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = true;
                //cbWageScale.Visible = false;
                txtHoursAndMinutes.Text = "0.00";
                string employee = string.Empty;
                employee = Session["EmployeeName"].ToString();
                if (CheckEmployeeRole(employee,"TravelTime") == "Yes")
                {
                    lblTravelTime.Visible = true;
                    cbTravelTime.Visible = true;

                }
                if (CheckEmployeeRole(employee, "WageScale") == "Yes")
                {
                    lblWageScale.Visible = true;
                    cbWageScale.Visible = true;

                }

            }
        }

        protected void Calendar1_PreRender(object sender, EventArgs e)
        {
            // Calendar1.SelectedDate = Calendar1.TodaysDate;
            //txtDateWorked.Text = Calendar1.SelectedDate.ToShortDateString();
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //txtDateWorked.Text = Calendar1.SelectedDate.ToShortDateString();
            //Calendar1.Visible = false;
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
            ddlHours.Items.Insert(0, new ListItem("11", "11"));
            ddlHours.Items.Insert(0, new ListItem("10", "10"));
            ddlHours.Items.Insert(0, new ListItem("9", "9"));
            ddlHours.Items.Insert(0, new ListItem("8", "8"));
            ddlHours.Items.Insert(0, new ListItem("7", "7"));
            ddlHours.Items.Insert(0, new ListItem("6", "6"));
            ddlHours.Items.Insert(0, new ListItem("5", "5"));
            ddlHours.Items.Insert(0, new ListItem("4", "4"));
            ddlHours.Items.Insert(0, new ListItem("3", "3"));
            ddlHours.Items.Insert(0, new ListItem("2", "2"));
            ddlHours.Items.Insert(0, new ListItem("1", "1"));
            ddlHours.Items.Insert(0, new ListItem("0", "0"));
            ddlMinutes.Items.Insert(0, new ListItem("45", "45"));
            ddlMinutes.Items.Insert(0, new ListItem("30", "30"));
            ddlMinutes.Items.Insert(0, new ListItem("15", "15"));
            ddlMinutes.Items.Insert(0, new ListItem("00", "00"));

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(!Page.IsValid)
            {
                return;
            }

            if(ddlHours.SelectedValue == "0")
            {
                lblHoursWorked.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (SubmitTimeRecord() != "Success")
            {
                //lblSubmitView1.Text = "Error. Review and retry";
                lblSubmitView2.Text = "Error. Review and retry";
                //divCalendar.Visible = false;
            }
            else
            {
                //lblSubmitView1.Text = "Saved. Ready for more.";
                SetCheckBoxesToFalse();
                //rbProjectNumber.Checked = true;
                cbProjectNumber.Checked = true;
                cbTravelTime.Checked = false;
                cbWageScale.Checked = false;
                //divCalendar.Visible = false;
                //this.View1.Focus();
                //View ViewSetter = FindControl("View1") as View;
                txtPreProjectNotes.Visible = false;
                //lblcharCountOutput.Visible = false;
                MainView.SetActiveView(View1);
                lblHoursWorked.ForeColor = System.Drawing.Color.Black;
                lblSubmitView2.Text = "Saved. Ready for more.";

            }
        }

        protected string SubmitTimeRecord()
        {
            string returnVal = "Error";
            string employeeName = lblWelcome.Text.Replace("Submit time for: ", "");
            //int projectChecked = (rbProjectNumber.Checked == true) ? 1 : 0;
            int projectChecked = (cbProjectNumber.Checked == true) ? 1 : 0;
            int hours = Convert.ToInt16(ddlHours.SelectedValue.ToString());
            if (txtProjectNumber.Text.Length > 4)
            {
                projectChecked = 1;
                SetCheckBoxesToFalse();
                // rbProjectNumber.Checked = true;
                cbProjectNumber.Checked = true;
            }

            int preProject = (cbPreProject.Checked == true) ? 1 : 0;
            int shareAcross = (cbShareAcross.Checked == true) ? hours : 0;
            int holiday = (cbHoliday.Checked == true) ? 1 : 0;
            int CorporateEvents = (cbCorporateEvents.Checked == true) ? 1 : 0;
            //int Other = (cbOther.Checked == true) ? 1 : 0;
            int wageScale = (cbWageScale.Checked == true) ? 1 : 0;
            int TravelTime = (cbTravelTime.Checked == true) ? 1 : 0;
            int PTO = (cbPTO.Checked == true) ? 1 : 0;
            string hoursAndMinutes = string.Empty;
            hoursAndMinutes = ddlHours.SelectedValue.ToString() + "." + ddlMinutes.SelectedValue.ToString();

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
                    cmd.Parameters.AddWithValue("@Hours", hoursAndMinutes);
                    cmd.Parameters.AddWithValue("@WageScale", wageScale);
                    cmd.Parameters.AddWithValue("@DriveTime", TravelTime);
                    cmd.Parameters.AddWithValue("@PreProject", preProject);
                    cmd.Parameters.AddWithValue("@shareAcross", shareAcross);
                    cmd.Parameters.AddWithValue("@holiday", holiday);
                    cmd.Parameters.AddWithValue("@CorporateEvents", CorporateEvents);
                    // cmd.Parameters.AddWithValue("@Other", string.Empty);
                    cmd.Parameters.AddWithValue("@PTO", PTO);
                    cmd.Parameters.AddWithValue("@Notes", txtPreProjectNotes.Text);
                    cmd.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds); //maybe not fill, but datawriter?
                    conn.Close();

                }
                ddlHours.SelectedValue = "0";
                ddlMinutes.SelectedValue = "00";
                txtProjectNumber.Text = string.Empty;
                txtProjectName.Text = string.Empty;
                txtPreProjectNotes.Text = string.Empty;
                //txtOther.Text = string.Empty;
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
            if (txtProjectNumber.Text.Length > 4)
            {
                SetCheckBoxesToFalse();
                // rbProjectNumber.Checked = true;
                cbProjectNumber.Checked = true;
            }
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = true;
        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewCurrentTime.aspx");
        }
              

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //divCalendar.Visible = true;
            //Calendar1.Visible = true;
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            tblView1.CssClass = "SelectedView";
            tblView2.CssClass = "UnselectedView";
            MainView.ActiveViewIndex = 0;
            btnSubmit.ValidationGroup = "ProjectBased";
            //RequiredFieldValidator3.Enabled = false;
            lblSubmitView2.Text = string.Empty;
            Tab1.BorderColor = System.Drawing.Color.Gray;
            Tab2.BorderColor = System.Drawing.Color.LightGray;
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";
            tblView2.CssClass = "SelectedView";
            //tblView1.CssClass = "UnselectedView";
            MainView.ActiveViewIndex = 1;
            btnSubmit.ValidationGroup = "Overhead";
            lblSubmitView2.Text = string.Empty;
            Tab1.BorderColor = System.Drawing.Color.LightGray;
            Tab2.BorderColor = System.Drawing.Color.Gray;

        }

        protected void cbPreProject_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbPreProject.Checked = true;
            lblShortNote.Visible = true;
            txtPreProjectNotes.Visible = true;
            txtProjectNumber.Text = string.Empty;
            //lblcharCountOutput.Visible = true;
            //cbPreProject.BackColor = System.Drawing.Color.LightGreen;
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = false;

        }

        protected void cbProjectNumber_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbProjectNumber.Checked = true;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = true;
        }

        protected void cbCorporateEvents_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbCorporateEvents.Checked = true;
            //cbCorporateEvents.BackColor = System.Drawing.Color.LightGreen;

        }

        protected void cbHoliday_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbHoliday.Checked = true;
            //cbHoliday.BackColor = System.Drawing.Color.LightGreen;
        }

        //protected void cbOther_CheckedChanged(object sender, EventArgs e)
        //{
        //    SetCheckBoxesToFalse();
        //    cbOther.Checked = true;
        //    RequiredFieldValidator3.Enabled = true;
        //    txtOther.Visible = true;
        //    lblOtherNote.Visible = true;
        //    //cbOther.BackColor = System.Drawing.Color.LightGreen;
        //}

        protected void SetCheckBoxesToFalse()
        {
            txtProjectName.ForeColor = System.Drawing.Color.White;
            txtProjectName.Text = string.Empty;
            cbHoliday.Checked = false;
            cbProjectNumber.Checked = false;
            cbPreProject.Checked = false;
            cbShareAcross.Checked = false;
            cbCorporateEvents.Checked = false;
            cbPTO.Checked = false;
            lblShortNote.Visible = false;
            txtPreProjectNotes.Visible = false;
            RequiredFieldValidator1.Enabled = false;
            lblSubmitView2.Text = string.Empty;

        }

        protected void ddlHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSubmitView2.Text = string.Empty;
            if(cbShareAcross.Checked == true)
            {
                checkShareAcrossTimeForWeek();

            }

            txtHoursAndMinutes.Text = ddlHours.SelectedValue.ToString() + "." + ddlMinutes.SelectedValue.ToString();
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

        protected void cbTravelTime_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbTravelTime.Checked == true)
            //{
            //    cbTravelTime.BackColor = System.Drawing.Color.LightGreen;
            //}
            //else
            //    cbTravelTime.BackColor = System.Drawing.Color.White;
        }

        protected void rbProjectNumber_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            // rbProjectNumber.Checked = true;
            cbProjectNumber.Checked = true;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = true;

        }

        protected void cbPTO_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbPTO.Checked = true;
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
                //lblUserName.Text = Session["EmployeeName"].ToString();
            }
            catch (Exception ex)
            {
                //lblUserName.Text = ex.ToString();
            }
        }

        protected void txtPreProjectNotes_TextChanged(object sender, EventArgs e)
        {
            int charactersLeft = 0;
            charactersLeft = 50 - txtPreProjectNotes.Text.Length;
            //lblcharCountOutput.Text = charactersLeft.ToString() + " more characters allowed";
        }

        protected void ddlMinutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHoursAndMinutes.Text = ddlHours.SelectedValue.ToString() + "." + ddlMinutes.SelectedValue.ToString();
        }
        protected void IsTextboxValid(object sender, ServerValidateEventArgs e)
        {
            //e.IsValid = (cbProjectNumber.Checked == false);
            if(cbProjectNumber.Checked == true)
            {
                if ( txtProjectNumber.Text == string.Empty)
                {
                    e.IsValid = false;
                }
            }

        }

        protected void cbShareAcross_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckBoxesToFalse();
            cbShareAcross.Checked = true;
            lblShortNote.Visible = true;
            txtPreProjectNotes.Visible = true;
            txtProjectNumber.Text = string.Empty;
            //lblcharCountOutput.Visible = true;
            //cbPreProject.BackColor = System.Drawing.Color.LightGreen;
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = false;
            checkShareAcrossTimeForWeek();


        }

        protected void checkShareAcrossTimeForWeek()
        {
            // search timesheet for shareAcross entries for this week.  
            // add up the time and subtract from 4
            int ShareAcrossMaxHoursLeftToTakeThisWeek = 0;
            int ShareAcrossMaxHoursAllowedBySystem = 0;
            int shareAcrossHoursTaken = 0;
            // put SQL here to check on hours used for shareAcross
            // maxHoursAllowed = maxHoursAllowed - shareAcrossHoursUsedThisWeek
            string employeeName = lblWelcome.Text.Replace("Submit time for: ", "");
            string ShareAcrossProject = string.Empty;

            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "checkShareAcrossTimeForWeek";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@dateSubmittedFor", txtDateWorked.Text);
                cmd.Parameters.AddWithValue("@Employee", employeeName);
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

            shareAcrossHoursTaken = Convert.ToInt16(ds.Tables[0].Rows[0]["shareAcrossHoursTaken"].ToString());
            ShareAcrossMaxHoursAllowedBySystem = Convert.ToInt16(ds.Tables[0].Rows[0]["ShareAcrossMaxHoursAllowed"].ToString());
            ShareAcrossProject = ds.Tables[0].Rows[0]["ShareAcrossProject"].ToString();

            ShareAcrossMaxHoursLeftToTakeThisWeek = ShareAcrossMaxHoursAllowedBySystem - shareAcrossHoursTaken;

            if (Convert.ToInt16(ddlHours.SelectedValue.ToString()) > ShareAcrossMaxHoursLeftToTakeThisWeek)
            {
                if(Convert.ToInt16(ShareAcrossMaxHoursLeftToTakeThisWeek.ToString()) < 1 )
                    {
                    ShareAcrossMaxHoursLeftToTakeThisWeek = 0;
                }
                ddlHours.SelectedValue = ShareAcrossMaxHoursLeftToTakeThisWeek.ToString();
                txtProjectName.Text = "Hours adjusted to max remaining allowed.";
                txtProjectName.ForeColor = System.Drawing.Color.Red;
            }

            if (ShareAcrossMaxHoursLeftToTakeThisWeek < 1)
            {
                txtProjectName.Text = "You have already assigned max Share Hours.";
                txtProjectName.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected string CheckEmployeeRole(string employee, string roleName)
        {
            string IsEmployeeInRole = string.Empty;
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "CheckEmployeeRole";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@Employee", employee);
                cmd.Parameters.AddWithValue("@RoleName", roleName);
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
            
            IsEmployeeInRole = ds.Tables[0].Rows[0]["IsEmployeeInRole"].ToString();
            return (IsEmployeeInRole);
        }
    }
}