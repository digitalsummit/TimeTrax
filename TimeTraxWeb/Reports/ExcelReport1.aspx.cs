using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace TimeTrax
{
    public partial class ExcelReport1 : System.Web.UI.Page
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

        protected void createExcelFile()
        {
            //  using Excel = Microsoft.Office.Interop.Excel;
            var excel = new Microsoft.Office.Interop.Excel.Application();
            var workBooks = excel.Workbooks;
            var workBook = workBooks.Add();
            var workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
            //workBook.SaveAs("D:\\Projects\\TimeTrax\\TimeTrax\\TimeTraxReport.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            workBook.SaveAs(@"C:\inetpub\wwwroot\TimeTrax\Reports\TimeTraxReport.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            workBook.Close();

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
                // cmd.Parameters.AddWithValue("@Employee", employeeName);
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

        // ************************************************************************************

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
                // ExportDataSetToExcel(ds, @"C:\inetpub\wwwroot\TimeTrax\TimeTraxRpt.xls");
            }
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Time Sheet Report";
            // storing header part in Excel  
            worksheet.Cells[1, 1] = "Time Sheet Report";
            if (cbByProject.Checked==true)
            { 
                worksheet.Cells[1, 2] = "Sorted by Project";
            }
            if (cbByEmployee.Checked == true)
            {
                worksheet.Cells[1, 2] = "Sorted by Employee";
            }


            for (int i = 1; i < ds.Tables[0].Columns.Count + 1; i++)
            {
                worksheet.Cells[2, i] = ds.Tables[0].Columns[i - 1].ToString();
            }
            // storing Each row and column value to excel sheet  
            // for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    worksheet.Cells[i + 3, j + 1] = ds.Tables[0].Rows[i][j].ToString();
                    endingRow = i + 3;
                }
            }

            worksheet.Columns[1].ColumnWidth = 15;
            worksheet.Columns[2].ColumnWidth = 25;
            worksheet.Columns[3].ColumnWidth = 11;
            worksheet.Columns[4].ColumnWidth = 12;
            worksheet.Columns[5].ColumnWidth = 11;
            worksheet.Columns[6].ColumnWidth = 11;
            worksheet.Columns[7].ColumnWidth = 11;
            worksheet.Columns[8].ColumnWidth = 11;
            worksheet.Columns[9].ColumnWidth = 11;
            worksheet.Columns[10].ColumnWidth = 11;
            worksheet.Columns[11].ColumnWidth = 11;
            worksheet.Columns[12].ColumnWidth = 11;
            worksheet.Columns[13].ColumnWidth = 11;
            worksheet.Columns[14].ColumnWidth = 25;

            calcRow = endingRow + 1;

            worksheet.Cells[calcRow, 4] = "Totals:";
            worksheet.Cells[calcRow, 5] = "=SUM(E3:E" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 6] = "=SUM(F3:F" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 7] = "=SUM(G3:G" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 8] = "=SUM(H3:H" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 9] = "=SUM(I3:I" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 10] = "=SUM(J3:J" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 11] = "=SUM(K3:K" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 12] = "=SUM(L3:L" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 13] = "=SUM(M3:M" + endingRow.ToString() + ")";


           // ***** Uncomment this section to format the numbers as 2 decimals.  You will need to adjust what columns are being formatted
            //for (int i = 3; i < ds.Tables[0].Columns.Count + 1; i++)
            //{
            //    Microsoft.Office.Interop.Excel.Range ThisRange = worksheet.Columns[i];
            //    ThisRange.NumberFormat = "0.00";
            //    Marshal.FinalReleaseComObject(ThisRange);

            //}

            // save the application  
            //                     workbook.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // workbook.SaveAs(@"C:\inetpub\wwwroot\TimeTrax\" + manager + "_ProjectCost.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  

            //app.Quit();
            //    }
            //}


        }

        // ************************************************************************************
        protected void ExcelRpt1()
        {
            DateTime beginDate;
            DateTime endDate;
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
            if(cbByProject.Checked==true)
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
                ExportDataSetToExcel(ds, @"C:\inetpub\wwwroot\TimeTrax\TimeTraxRpt.xls");
            }
            Label1.Text = "Finished";
        }
        public static void ExportDataSetToExcel(DataSet ds, string filename)
        {
            HttpResponse response = HttpContext.Current.Response;

            // first let's clean up the response.object
            response.Clear();
            response.Charset = "";

            // set the response mime type for excel
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");

            // create a string writer
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // instantiate a datagrid
                    DataGrid dg = new DataGrid();
                    dg.DataSource = ds.Tables[0];
                    dg.DataBind();
                    dg.RenderControl(htw);
                    response.Write(sw.ToString());
                    response.End();
                }
            }
        }

        protected void btnCreateExcel_Click(object sender, EventArgs e)
        {
            // ExcelRpt1();
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