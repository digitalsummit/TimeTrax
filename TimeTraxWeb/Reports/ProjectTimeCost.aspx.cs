using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace TimeTrax.Reports
{
    public partial class ProjectTimeCost : System.Web.UI.Page
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

        }
        protected void createWorkbook()
        {
    
            int endingRow = 0;
            int calcRow = 0;
            LabelProgress.ForeColor = System.Drawing.Color.Black;
            LabelProgress.Text = "Gathering the data...";
            LabelProgress.Visible = true;
            DataSet ds = new DataSet();
            string sqlCmdText = string.Empty;

            sqlCmdText = "rptProjectCostPerWeek";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@projectNumber", txtProjectNumber.Text);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
            }

            if (ds.Tables[0].Rows.Count < 4)
            {
                LabelProgress.ForeColor = System.Drawing.Color.Red;
                LabelProgress.Text = "No data found for: " + txtProjectNumber.Text;
                return;
            }
            else
            {
                LabelProgress.ForeColor = System.Drawing.Color.Black;
                LabelProgress.Text = "Exporting the file...";
            }

            // *************************************************************
            //Creates a blank workbook. Use the using statment, so the package is disposed when we are done.
            using (var p = new ExcelPackage())
            {
                //A workbook must have at least one cell, so lets add one... 
                var worksheet = p.Workbook.Worksheets.Add("ProjectCost");
                worksheet.Cells[1, 1].Value = "Project Cost For";
                worksheet.Cells[1, 2].Value = txtProjectNumber.Text;
                worksheet.Cells[1, 3].Value = LabelProjectName.Text;
                //To set values in the spreadsheet use the Cells indexer.
                // worksheet.Cells["A1"].Value = "This is cell A1";
                // ********trying to format worksheet ws

                // WORKSHEET COLUMN HEADINGS This section:
                //for (int i = 1; i < ds.Tables[0].Columns.Count + 1; i++)
                //{  // WORKSHEET COLUMN HEADINGS:
                //    worksheet.Cells[2, i].Value = ds.Tables[0].Columns[i - 1];
                //}

                // storing Each row and column value to excel sheet  
                // for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                worksheet.Cells["A2"].Value = "Summary";
                for (int i = 0; i < 3; i++)
                {  //  SUMMARY DATA: NumberOfWeeks, TotalHoursWorked, TotalLaborCost
                    for (int j = 0; j < 2; j++)
                    {
                        worksheet.Cells[i + 3, j + 1].Value = ds.Tables[0].Rows[i][j];
                        endingRow = i + 3;
                    }
                }

                worksheet.Cells["A7"].Value = "Person";
                worksheet.Cells["B7"].Value = "Hours";
                worksheet.Cells["C7"].Value = "LaborCost";
                worksheet.Cells["D7"].Value = "Week";
                worksheet.Cells["E7"].Value = "BeginDate";
                worksheet.Cells["A7:E7"].Style.Font.Bold = true;
                worksheet.Cells["A7:E7"].Style.Font.UnderLine = true;
                worksheet.Cells["A2"].Style.Font.Bold = true;
                for (int i = 3; i < ds.Tables[0].Rows.Count; i++)
                {  //  WORKSHEET DATA
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        worksheet.Cells[i + 5, j + 1].Value = ds.Tables[0].Rows[i][j];
                        endingRow = i + 3;
                    }
                }
                string formatHoursRange = string.Empty;
                formatHoursRange = "B8:C" + (endingRow + 2).ToString();
                worksheet.Cells[formatHoursRange].Style.Numberformat.Format = "0.00";

                string formatDollarRange = string.Empty;
                formatDollarRange = "C8:C" + (endingRow + 2).ToString();
                worksheet.Cells[formatDollarRange].Style.Numberformat.Format = "$0.00";
                // worksheet.Cells[1, 2].Value = "Manager:";
                // worksheet.Cells[1, 3].Value = manager;
                worksheet.Column(1).Width = 17;
                worksheet.Column(2).Width = 17;
                worksheet.Column(3).Width = 17;
                //   worksheet.Column(4).Width = 15;
                //  worksheet.Column(5).Width = 15;
                //  worksheet.Column(1).Style.Numberformat.Format = "mm-dd-yyyy";
                worksheet.Cells["B3"].Style.Numberformat.Format = "0";
                worksheet.Cells["B4"].Style.Numberformat.Format = "0.00";
                worksheet.Cells["B5"].Style.Numberformat.Format = "$0.00";
                //worksheet.Column(1).Style.Numberformat.Format = "0";
                //worksheet.Column(2).Style.Numberformat.Format = "0.00";
                //worksheet.Column(3).Style.Numberformat.Format = "0.00";
                //worksheet.Column(4).Style.Numberformat.Format = "0.00";
                //worksheet.Column(5).Style.Numberformat.Format = "0.00";

                //Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B7DEE8");
                worksheet.Cells["A1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:G1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aquamarine);

                worksheet.Cells["A1:C1"].Style.Font.Bold = true;
                //worksheet.Cells["A2:C2"].Style.Font.Bold = true;
                //worksheet.Cells["A2:C2"].Style.Font.UnderLine = true;
                worksheet.Cells["B3:B5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["B3:B5"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Pink);


                calcRow = endingRow + 1;
                //worksheet.View.FreezePanes(2, 1);
                //worksheet.Cells[calcRow, 2].Value = "Totals:";
                //worksheet.Cells[calcRow, 2].Style.Font.Bold = true;
                //worksheet.Cells[calcRow, 2].Style.Font.UnderLine = true;

              //  worksheet.Cells[calcRow, 2].Formula = "SUM(B3:B" + endingRow.ToString() + ")";
              //  worksheet.Cells[calcRow, 3].Formula = "SUM(C3:C" + endingRow.ToString() + ")";
                // worksheet.Cells[calcRow, 4].Formula = "SUM(D3:D" + endingRow.ToString() + ")";
                // worksheet.Cells[calcRow, 5].Formula = "SUM(E3:E" + endingRow.ToString() + ")";

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
        protected void GetProjectName()
        {
            DataSet ds = new DataSet();
            string sqlCmdText = string.Empty;
            sqlCmdText = "select top 1 ProjectName from TimeSheet where ProjectNumber = '" + txtProjectNumber.Text + "' and LEN(ProjectName) > 5";
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
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["ProjectName"] != null)
                LabelProjectName.Text = ds.Tables[0].Rows[0]["ProjectName"].ToString();
        }

        protected void btnRunRpt_Click(object sender, EventArgs e)
        {
            LabelProgress.ForeColor = System.Drawing.Color.Black;
            LabelProgress.Text = string.Empty;
            GetProjectName();
            createWorkbook();
        }

        protected void btnGetProjectName_Click(object sender, EventArgs e)
        {
            int ProjectID;
            LabelProgress.ForeColor = System.Drawing.Color.Black;
            LabelProgress.Text = string.Empty;
            if (int.TryParse(txtProjectNumber.Text, out ProjectID))
            {
                txtProjectName.Text = GetProjectName(txtProjectNumber.Text);
            }

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
    }
}