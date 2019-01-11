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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx", true);
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    FillArrayTable(DropDownList1.SelectedItem.ToString());
        //    try
        //    {
        //        ProcessStartInfo psi = new ProcessStartInfo();
        //        psi.UseShellExecute = true;
        //        psi.LoadUserProfile = true;
        //        psi.WorkingDirectory = MapPath("~/"); // This line solved a problem for someone on StackExchange
        //        psi.FileName = MapPath("~/TimeTraxReport.xlsx");
        //        Process.Start(psi);

        //    }
        //    catch (Exception ex)
        //    {
        //        Label1.Text = ex.ToString();
        //    }
        //}
        //protected void FillArrayTable(string employeeName)
        //protected void FillArrayTable(string employeeName)
        //{
        //    string approved = DropDownList2.SelectedValue;
        //    string sqlCmdText = string.Empty;
        //    DataSet ds = new DataSet();
        //    sqlCmdText = "GetMyCurrentTimeSheet";
        //    SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
        //    using (conn)
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = sqlCmdText;
        //        cmd.Parameters.AddWithValue("@Employee", employeeName);
        //        cmd.Parameters.AddWithValue("@Approved", approved);
        //        cmd.Connection = conn;
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(ds);
        //        conn.Close();

        //    }
        //    // GridView1.DataSource = ds.Tables[0];
        //    //
        //    //System.Data.Entity.Utilities.ExcelExport.Export excel = new Utilities.ExcelExport.Export();
        //    ////Pass your Dataset and Specify the style.
        //    //excel.ExportDataToExcel(ds, Utilities.ExcelExport.ExportStyle.RowWise);

        //    // string[] timeData = new[] { ds.Tables[0].ToString() };
        //    int timeDataRowCount = ds.Tables[0].Rows.Count;

        //    var excel = new Microsoft.Office.Interop.Excel.Application();
        //    int x = 1;
        //    var workBooks = excel.Workbooks;
        //    var workBook = workBooks.Add();
        //    var workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
        //    for (int i = 0; i < timeDataRowCount; i++)
        //    {
        //        if (x == 1)
        //        {
        //            workSheet.Cells[x, "A"] = "ID";
        //            workSheet.Cells[x, "B"] = "ProjectNumber";
        //            workSheet.Cells[x, "C"] = "ProjectName";
        //            workSheet.Cells[x, "D"] = "DateWorked";
        //            workSheet.Cells[x, "E"] = "Employee";
        //            workSheet.Cells[x, "F"] = "Hours";
        //            workSheet.Cells[x, "G"] = "PreProject"; 
        //            workSheet.Cells[x, "H"] = "StrategicInitiative";
        //            workSheet.Cells[x, "I"] = "Training";
        //            workSheet.Cells[x, "J"] = "WageScale";
        //            workSheet.Cells[x, "K"] = "DriveTime";
        //            workSheet.Cells[x, "L"] = "Other";
        //            workSheet.Cells[x, "M"] = "Notes";
        //            workSheet.Cells[x, "N"] = "Approved";
        //            x = 2;
        //            // greeting = age < 20 ? "What's up?" : "Hello";
        //            workSheet.Cells[x, "A"] = ds.Tables[0].Rows[i]["ID"].ToString();
        //            workSheet.Cells[x, "B"] = ds.Tables[0].Rows[i]["ProjectNumber"].ToString();
        //            workSheet.Cells[x, "C"] = ds.Tables[0].Rows[i]["ProjectName"].ToString();
        //            workSheet.Cells[x, "D"] = ds.Tables[0].Rows[i]["DateWorked"].ToString();
        //            workSheet.Cells[x, "E"] = ds.Tables[0].Rows[i]["Employee"].ToString();
        //            workSheet.Cells[x, "F"] = ds.Tables[0].Rows[i]["Hours"].ToString();
        //            workSheet.Cells[x, "G"] = ds.Tables[0].Rows[i]["PreProject"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["PreProject"].ToString();
        //            workSheet.Cells[x, "H"] = ds.Tables[0].Rows[i]["StrategicInitiative"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["StrategicInitiative"].ToString();
        //            workSheet.Cells[x, "I"] = ds.Tables[0].Rows[i]["Training"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["Training"].ToString();
        //            workSheet.Cells[x, "J"] = ds.Tables[0].Rows[i]["WageScale"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["WageScale"].ToString();
        //            workSheet.Cells[x, "K"] = ds.Tables[0].Rows[i]["DriveTime"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["DriveTime"].ToString();
        //            workSheet.Cells[x, "L"] = ds.Tables[0].Rows[i]["Other"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["Other"].ToString();
        //            workSheet.Cells[x, "M"] = ds.Tables[0].Rows[i]["Notes"].ToString();
        //            workSheet.Cells[x, "N"] = ds.Tables[0].Rows[i]["Approved"].ToString();

        //        }
        //        else
        //        {
        //            workSheet.Cells[x, "A"] = ds.Tables[0].Rows[i]["ID"].ToString();
        //            workSheet.Cells[x, "B"] = ds.Tables[0].Rows[i]["ProjectNumber"].ToString();
        //            workSheet.Cells[x, "C"] = ds.Tables[0].Rows[i]["ProjectName"].ToString();
        //            workSheet.Cells[x, "D"] = ds.Tables[0].Rows[i]["DateWorked"].ToString();
        //            workSheet.Cells[x, "E"] = ds.Tables[0].Rows[i]["Employee"].ToString();
        //            workSheet.Cells[x, "F"] = ds.Tables[0].Rows[i]["Hours"].ToString();
        //            workSheet.Cells[x, "G"] = ds.Tables[0].Rows[i]["PreProject"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["PreProject"].ToString();
        //            workSheet.Cells[x, "H"] = ds.Tables[0].Rows[i]["StrategicInitiative"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["StrategicInitiative"].ToString();
        //            workSheet.Cells[x, "I"] = ds.Tables[0].Rows[i]["Training"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["Training"].ToString();
        //            workSheet.Cells[x, "J"] = ds.Tables[0].Rows[i]["WageScale"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["WageScale"].ToString();
        //            workSheet.Cells[x, "K"] = ds.Tables[0].Rows[i]["DriveTime"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["DriveTime"].ToString();
        //            workSheet.Cells[x, "L"] = ds.Tables[0].Rows[i]["Other"].ToString() == false.ToString() ? "" : ds.Tables[0].Rows[i]["Other"].ToString();
        //            workSheet.Cells[x, "M"] = ds.Tables[0].Rows[i]["Notes"].ToString();
        //            workSheet.Cells[x, "N"] = ds.Tables[0].Rows[i]["Approved"].ToString();
        //        }
        //        x = x + 1;
        //    }
        //    workBook.SaveAs(@"C:\inetpub\wwwroot\TimeTrax\Reports\TimeTraxReport.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
        //    workBook.Close();


        //}
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
            DateTime beginDate = DateTime.Now.AddDays(-14);
            DateTime endDate = DateTime.Now;
            endDate = endDate.Date.AddDays(1);
            Label1.Text = "Gathering the data...";
            DataSet ds = new DataSet();
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
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
                Label1.Text = "Exporting the file...";
                ExportDataSetToExcel(ds, @"C:\inetpub\wwwroot\TimeTrax\LotNums.xls");
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