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


namespace TimeTrax
{
    public partial class ExcelCostRpt1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLevel"].ToString() == "Finance")
              divAuthorized.Visible = true;
            else
              divNotAuthorized.Visible = true;
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
            //workBook.SaveAs("D:\\Projects\\TimeTrax\\TimeTrax\\TimeTraxReport.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            workBook.SaveAs(@"C:\inetpub\wwwroot\TimeTrax\Reports\TimeTraxReport.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            workBook.Close();

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
            ExcelRpt1();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedManager"] = DropDownList1.SelectedValue.ToString();
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