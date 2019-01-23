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
    public partial class ExcelReport1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserLevel"].ToString() == "Manager") || (Session["UserLevel"].ToString() == "Finance"))
                divAuthorized.Visible = true;
            else
                divNotAuthorized.Visible = true;

            if (!IsPostBack)
            {
                FillDropDownList1();
                FillDropDownList2();
                cbByProject.Checked = true;
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
            ExcelRpt1();
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
    }
}