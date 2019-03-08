using System;
using System.Web;
using System.Web.UI;
using OfficeOpenXml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TimeTrax.Reports
{
    public partial class TimeSheetRpt : System.Web.UI.Page
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
                FillDropDownList2();
                cbByProject.Checked = true;
                setDefaultDates();


            }
        }
        protected void FillDropDownList1()
        {
            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "FillEmployeeNameDropDownList";
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
            DropDownList1.Items.Add("All Employees");
            for (int i = 0; i < UserDataRowCount; i++)
            {
                DropDownList1.Items.Add(ds.Tables[0].Rows[i]["EmployeeName"].ToString());
            }
        }

        // DropDownList2
        protected void FillDropDownList2()
        {
            DropDownList2.Items.Add("All");
            DropDownList2.Items.Add("Not Approved");
            DropDownList2.Items.Add("Approved");
            DropDownList2.SelectedValue = "All";
        }
        protected void CreateExcelSheet()
        {
            DateTime beginDate;
            DateTime endDate;
            int endingRow = 0;
            int calcRow = 0;
            Label1.Text = "Gathering the data...";
            DataSet ds = new DataSet();
            beginDate = Convert.ToDateTime(txtDateBegin.Text);
            endDate = Convert.ToDateTime(txtDateEnd.Text);
            endDate = endDate.Date.AddDays(1);
            string employeeName = DropDownList1.SelectedItem.ToString();
            // *
            string approved = DropDownList2.SelectedValue;
            string sqlCmdText = string.Empty;
            string flavor = string.Empty;
            if (cbByProject.Checked == true)
            { flavor = "ByProject"; }
            if (cbByEmployee.Checked == true)
            { flavor = "ByEmployee"; }
            sqlCmdText = "GetExcelReport1";
            SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sqlCmdText;
                cmd.Parameters.AddWithValue("@Employee", employeeName);
                cmd.Parameters.AddWithValue("@Approved", approved);
                cmd.Parameters.AddWithValue("@Flavor", flavor);
                cmd.Parameters.AddWithValue("@beginDate", txtDateBegin.Text);
                cmd.Parameters.AddWithValue("@endDate", txtDateEnd.Text);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
                Label1.Text = "Exporting the file...";

            }

            //Creates a blank workbook. Use the using statment, so the package is disposed when we are done.
            using (var p = new ExcelPackage())
            {
                //A workbook must have at least on cell, so lets add one... 
                var worksheet = p.Workbook.Worksheets.Add("TimeSheetRpt");
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
                worksheet.Cells[1, 2].Value = "Timesheet Employee:";
                worksheet.Cells[1, 3].Value = employeeName;
                worksheet.Column(1).Width = 14;
                worksheet.Column(2).Width = 10;
                worksheet.Column(3).Width = 23;
                worksheet.Column(4).Width = 12;
                worksheet.Column(5).Width = 12;
                //worksheet.Column(3).Style.Numberformat.Format = "0.00";
                //worksheet.Column(4).Style.Numberformat.Format = "0.00";
                //worksheet.Column(5).Style.Numberformat.Format = "0.00";
                calcRow = endingRow + 1;
                worksheet.View.FreezePanes(3, 1);
              
                if (cbByProject.Checked == true)
                {
                    worksheet.Cells[1, 2].Value = "Sorted by Project";
                }
                if (cbByEmployee.Checked == true)
                {
                    worksheet.Cells[1, 2].Value = "Sorted by Employee and date";
                }


                for (int i = 1; i < ds.Tables[0].Columns.Count + 1; i++)
                {
                    worksheet.Cells[2, i].Value = ds.Tables[0].Columns[i - 1];
                }
                // storing Each row and column value to excel sheet  
                // for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        worksheet.Cells[i + 3, j + 1].Value = ds.Tables[0].Rows[i][j];
                        endingRow = i + 3;
                    }
                }

                worksheet.Column(1).Width = 15;
                worksheet.Column(2).Width = 25;
                worksheet.Column(3).Width = 11;
                worksheet.Column(4).Width = 12;
                worksheet.Column(5).Width = 11;
                worksheet.Column(6).Width = 11;
                worksheet.Column(7).Width = 11;
                worksheet.Column(8).Width = 11;
                worksheet.Column(9).Width = 11;
                worksheet.Column(10).Width = 11;
                worksheet.Column(11).Width = 11;
                worksheet.Column(12).Width = 11;
                worksheet.Column(13).Width = 11;
                worksheet.Column(14).Width = 25;
                calcRow = endingRow + 1;

                worksheet.Cells[calcRow, 4].Value = "Totals:";
                worksheet.Cells[calcRow, 5].Formula = "SUM(E3:E" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 6].Formula = "SUM(F3:F" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 7].Formula = "SUM(G3:G" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 8].Formula = "SUM(H3:H" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 9].Formula = "SUM(I3:I" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 10].Formula = "SUM(J3:J" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 11].Formula = "SUM(K3:K" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 12].Formula = "SUM(L3:L" + endingRow.ToString() + ")";
                worksheet.Cells[calcRow, 13].Formula = "SUM(M3:M" + endingRow.ToString() + ")";


                //Save the new workbook. We haven't specified the filename so use the SaveAs method.
                //p.SaveAs(new FileInfo(@"c:\workbooks\myworkbook.xlsx"));
                //string filePath = Server.MapPath(@"\Book1.xlsx");
                string filePath = @"Book1.xlsx";

                //worksheet.Cells["A1"].Value = "My second EPPlus spreadsheet!";     //convert the excel package to a byte array    
                byte[] bin = p.GetAsByteArray();

                //clear the buffer stream     
                Response.Clear();
                Response.ClearHeaders();

                // Orig:  Response.Buffer = true;
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

            }

        }
        protected void btnCreateExcel_Click(object sender, EventArgs e)
        {
            CreateExcelSheet();

        }

        protected void cbByProject_CheckedChanged(object sender, EventArgs e)
        {
            clearCheckboxes();
            cbByProject.Checked = true;
        }

        protected void cbByEmployee_CheckedChanged(object sender, EventArgs e)
        {
            clearCheckboxes();
            cbByEmployee.Checked = true;
        }

        protected void clearCheckboxes()
        {
            cbByEmployee.Checked = false;
            cbByProject.Checked = false;
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
            { }

        }

        protected void btnNextWeek_Click(object sender, ImageClickEventArgs e)
        {
            DateTime beginDate = Convert.ToDateTime(txtDateBegin.Text);
            beginDate = beginDate.AddDays(7);
            txtDateBegin.Text = beginDate.ToShortDateString();
            txtDateEnd.Text = beginDate.AddDays(6).ToShortDateString();

        }

        protected void setDefaultDates()
        {
            int currentDayOfWeek = (int)DateTime.Now.DayOfWeek;
            DateTime endingDate = DateTime.Now.AddDays(-currentDayOfWeek);
            txtDateBegin.Text = endingDate.AddDays(-6).ToShortDateString();
            txtDateEnd.Text = endingDate.ToShortDateString();
        }

    }
}