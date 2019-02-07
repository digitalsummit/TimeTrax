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
    public partial class ExcelCostRpt1 : System.Web.UI.Page
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
        protected void createExcelFile()
        {
            //  using Excel = Microsoft.Office.Interop.Excel;
            var excel = new Microsoft.Office.Interop.Excel.Application();
            var workBooks = excel.Workbooks;
            var workBook = workBooks.Add();
            var workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
            // want to add code here to insert or add rows
            Range line = (Range)workSheet.Rows[3];
            line.Insert();
            // end of add rows code
            workBook.SaveAs("D:\\Documents\\Projects\\TimeTraxNew\\TimeTraxWeb\\Reports\\TimeTraxReport.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            //workBook.SaveAs(@"C:\inetpub\wwwroot\TimeTrax\Reports\TimeTraxReport.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            workBook.Close();
        }

        protected void CreateExcelSheet()
        {
            if(DropDownList1.SelectedValue == "Select Manager")
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
                    worksheet.Name = "Manager Cost Report";
            // storing header part in Excel  
            worksheet.Cells[1, 2] = "Manager:";
            worksheet.Cells[1, 3] = manager;

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

            worksheet.Columns[1].ColumnWidth = 14;
            worksheet.Columns[2].ColumnWidth = 10;
            worksheet.Columns[3].ColumnWidth = 23;
            worksheet.Columns[4].ColumnWidth = 12;
            worksheet.Columns[5].ColumnWidth = 12;
            calcRow = endingRow + 1;

            worksheet.Cells[calcRow, 1] = "Totals:";
            worksheet.Cells[calcRow, 2] = "=SUM(B3:B" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 3] = "=SUM(C3:C" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 4] = "=SUM(D3:D" + endingRow.ToString() + ")";
            worksheet.Cells[calcRow, 5] = "=SUM(E3:E" + endingRow.ToString() + ")";

            //Microsoft.Office.Interop.Excel.Range ThisRange = worksheet.get_Range("C3,C33");
            for (int i = 3; i < ds.Tables[0].Columns.Count + 1; i++)
            {
                Microsoft.Office.Interop.Excel.Range ThisRange = worksheet.Columns[i];
                ThisRange.NumberFormat = "0.00";
                Marshal.FinalReleaseComObject(ThisRange);
                
            }

            // save the application  
            //                     workbook.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // workbook.SaveAs(@"C:\inetpub\wwwroot\TimeTrax\" + manager + "_ProjectCost.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  

            //app.Quit();
            //    }
            //}

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
        
        protected void ExcelRpt1()
        {
            DateTime beginDate;
            DateTime endDate;
            
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
                //ExportDataSetToExcel(ds, @"C:\inetpub\wwwroot\TimeTrax\ProjectCost.xls");
                //tableA = ds.Tables[0];
                //tableB = ds.Tables[1];
                //ds2.Tables.Add(tableB);
                ExportDataSetToExcel(ds, @"C:\inetpub\wwwroot\TimeTrax\" + manager + "_ProjectCost.xls");
               // ExportDataSetToExcel(ds2, @"C:\inetpub\wwwroot\TimeTrax\ProjectCost2.xls");
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
                    // dg.DataSource = ds.Tables[0];
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedManager"] = DropDownList1.SelectedValue.ToString();
            lblWarningSelectManager.Visible = false;
        }
        //protected void formatExcelFile()
        //{
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=ReportOutput.xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    StringWriter tw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(tw);
        //    hw.WriteLine("<h3>Output Form</h3>");
        //    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(tw.ToString());
        //    Response.Flush();
        //    Response.End();

        //}
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

    }
}