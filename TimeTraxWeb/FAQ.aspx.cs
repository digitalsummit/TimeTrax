using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeTrax
{
    public partial class FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetFAQData();

            }
        }

        protected void GetFAQData()
        {

            string sqlCmdText = string.Empty;
            DataSet ds = new DataSet();
            sqlCmdText = "GetFAQData";
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
            DataTable dt = ds.Tables[0];
            //DataView dv = dt.DefaultView;
            //DataTable sortedDT = dv.ToTable();
            if (dt != null)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                //GridView1.DataSource = sortedDT;
                //GridView1.DataBind();
            }
        }
    }
}