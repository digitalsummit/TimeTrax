using System;
using System.Web;
using System.Web.UI;
using OfficeOpenXml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TimeTrax.Reports
{
    public partial class MgrCostRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLevel"].ToString() == "Finance")
            {
                divAuthorized.Visible = true;
                divNotAuthorized.Visible = false;
            }
            else
            {
                divAuthorized.Visible = false;
                divNotAuthorized.Visible = true;
            }

            if (!IsPostBack)
            {
                FillDropDownList1();
                //formatExcelFile();
                setDefaultDates();

            }
        }
        protected void createWorkbook()
        {
            if (DropDownList1.SelectedValue == "Select Manager")
            {
                lblWarningSelectManager.Visible = true;
                return;
            }

            DateTime beginDate;
            DateTime endDate;
            int endingRow = 0;
            int calcRow = 0;
            Label1.Text = "Gathering the data...";
            DataSet ds = new DataSet();
            beginDate = Convert.ToDateTime(txtDateBegin.Text);
            endDate = Convert.ToDateTime(txtDateEnd.Text);
            string manager = Session["SelectedManager"].ToString();

            string sqlCmdText = string.Empty;

            sqlCmdText = "rptProjectPercentagesCostTeamProjects";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@beginDate", beginDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@Manager", manager);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
                Label1.Text = "Exporting the file...";
            }


            // *************************************************************
            //Creates a blank workbook. Use the using statment, so the package is disposed when we are done.
            using (var p = new ExcelPackage())
            {
                //A workbook must have at least on cell, so lets add one... 
                var worksheet = p.Workbook.Worksheets.Add(manager);
                //To set values in the spreadsheet use the Cells indexer.
                // worksheet.Cells["A1"].Value = "This is cell A1";
                // ********trying to format worksheet ws
                for (int i = 1; i < ds.Tables[0].Columns.Count + 1; i++)
                {
                    //worksheet.Cells[2, i].Value = ds.Tables[0].Columns[i - 1].ToString();
                    worksheet.Cells[2, i].Value = ds.Tables[0].Columns[i - 1];
                }
                // storing Each row and column value to excel sheet  
                // for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        //worksheet.Cells[i + 3, j + 1].Value = ds.Tables[0].Rows[i][j].ToString();
                        worksheet.Cells[i + 3, j + 1].Value = ds.Tables[0].Rows[i][j];
                        endingRow = i + 3;
                    }
                }
                worksheet.Cells[1, 2].Value = "Manager:";
                worksheet.Cells[1, 3].Value = manager;
                worksheet.Column(1).Width = 14;
                worksheet.Column(2).Width = 10;
                worksheet.Column(3).Width = 23;
                worksheet.Column(4).Width = 12;
                worksheet.Column(5).Width = 12;
                worksheet.Column(3).Style.Numberformat.Format = "0.00";
                worksheet.Column(4).Style.Numberformat.Format = "0.00";
                worksheet.Column(5).Style.Numberformat.Format = "0.00";
                calcRow = endingRow + 1;
                worksheet.View.FreezePanes(2, 1);
                worksheet.Cells[calcRow, 1].Value = "Totals:";
                worksheet.Cells[calcRow, 2].Formula = "SUM(B3:B" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 3].Formula = "SUM(C3:C" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 4].Formula = "SUM(D3:D" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 5].Formula = "SUM(E3:E" + endingRow.ToString() + ")";

                //Save the new workbook. We haven't specified the filename so use the Save as method.
                //p.SaveAs(new FileInfo(@"c:\workbooks\myworkbook.xlsx"));
                string filePath = @"Book1.xlsx";
                //p.SaveAs(new FileInfo(@"D:\Documents\Projects\TimeTraxNew\TimeTraxWeb\ReportOutput\myworkbook.xlsx"));
                // Tobey ** p.SaveAs(new FileInfo(filePath));

                //Try to open file in browser

                //ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");     //add some text to cell A1     
                //worksheet.Cells["A1"].Value = "My second EPPlus spreadsheet!";     //convert the excel package to a byte array    

                byte[] bin = p.GetAsByteArray();     
                    //clear the buffer stream     
                
                Response.Clear();
                Response.ClearHeaders();

                // Tobey **  Response.Buffer = true;
                Response.Buffer = false;
                Response.BufferOutput = false;
                //set the correct contenttype     
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";     
                    //set the correct length of the data being send     
                Response.AddHeader("content-length", bin.Length.ToString());     
                    //set the filename for the excel package     
                Response.AddHeader("content-disposition", "attachment; filename =" + filePath);     
                    //send the byte array to the browser     
                Response.OutputStream.Write(bin, 0, bin.Length);     
                    //cleanup     
                Response.Flush();
                // HttpContext.Current.ApplicationInstance.CompleteRequest();

                Response.BinaryWrite(p.GetAsByteArray());
                Response.End();

                //***************
       
                //*************************

            }
        }

        protected void btnRunRpt_Click(object sender, EventArgs e)
        {
            // createWorkbook();
            createWorkbook();

        }

        protected void btnPreviousWeek_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DateTime beginDate = Convert.ToDateTime(txtDateBegin.Text);
                beginDate = beginDate.AddDays(-7);
                txtDateBegin.Text = beginDate.ToShortDateString();
                txtDateEnd.Text = beginDate.AddDays(6).ToShortDateString();
            }
            catch
            {
                setDefaultDates();
            }

        }

        protected void btnNextWeek_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DateTime beginDate = Convert.ToDateTime(txtDateBegin.Text);
                beginDate = beginDate.AddDays(7);
                txtDateBegin.Text = beginDate.ToShortDateString();
                txtDateEnd.Text = beginDate.AddDays(6).ToShortDateString();
            }
            catch
            {
                setDefaultDates();
            }

        }
        protected void setDefaultDates()
        {
            int currentDayOfWeek = (int)DateTime.Now.DayOfWeek;
            DateTime endingDate = DateTime.Now.AddDays(-currentDayOfWeek);
            txtDateBegin.Text = endingDate.AddDays(-6).ToShortDateString();
            txtDateEnd.Text = endingDate.ToShortDateString();
        }

        protected void FillDropDownList1()
        {
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "FillManagerNameDropDownList";
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
            DropDownList1.Items.Add("Select Manager");
            for (int i = 0; i < UserDataRowCount; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i]["EmployeeName"].ToString());
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedManager"] = DropDownList1.SelectedValue.ToString();
            lblWarningSelectManager.Visible = false;
        }

        protected void SendToBrowser()
        {
            //create a new ExcelPackage 
            using (ExcelPackage excelPackage = new ExcelPackage())
            {     //create the WorkSheet     
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");     //add some text to cell A1     
                worksheet.Cells["A1"].Value = "My second EPPlus spreadsheet!";     //convert the excel package to a byte array     
                byte[] bin = excelPackage.GetAsByteArray();     //clear the buffer stream     
                Response.ClearHeaders(); Response.Clear(); Response.Buffer = true;     //set the correct contenttype     
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";     //set the correct length of the data being send     
                Response.AddHeader("content-length", bin.Length.ToString());     //set the filename for the excel package     
                Response.AddHeader("content-disposition", "attachment; filename=\"ExcelDemo.xlsx\"");     //send the byte array to the browser     
                Response.OutputStream.Write(bin, 0, bin.Length);     //cleanup     
                Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
        }
    }
}