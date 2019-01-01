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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            divLogin.Visible = false;
            divRegister.Visible = true;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["divActive"] = "divLogin";
            divMessageBox.Visible = false;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (LoginUser() == "Success")
            {
                Session["EmployeeEmail"] = email;
                Response.Redirect("home.aspx");
            }
            else
            {
                divLogin.Visible = false;
                lblMessagebox.Text = "Invalid attempt.  Please try again.";
                divMessageBox.Visible = true;
            }

        }

        protected string LoginUser()
        {
            string returnVal = "Error";
            string email = txtEmail.Text;
            string password = txtPassword.Text.Trim();
            // Session["EmployeeEmail"]
            if (!email.Contains("@"))
            {
                // messagebox invalid email address
                lblMessagebox.Text = "Invalid email address.  Please try again.";
                divLogin.Visible = false;
                Session["divActive"] = "divLogin";
                divMessageBox.Visible = true;
            }

            else

                try
                {

                    DataSet ds = new DataSet();
                    string sqlCmdText = string.Empty;
                    sqlCmdText = "LoginUser";
                    SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
                    using (conn)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sqlCmdText;
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Connection = conn;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds);
                        conn.Close();
                    }

                    returnVal = ds.Tables[0].Rows[0]["ReturnVal"].ToString();
                    if (returnVal == "Success")
                    {
                        Session["EmployeeEmail"] = email;
                    }

                }
                catch (Exception ex)
                {
                    returnVal = ex.ToString();

                }

            return returnVal;
        }
        protected string Register()
        {
            string returnVal = "Success";
            string email = txtRegisterEmail.Text;
            string password1 = txtPassword1.Text.Trim();
            string password2 = txtPassword2.Text.Trim();

            if (!email.Contains("@"))
            {
                // messagebox invalid email address
                returnVal = "Invalid email address.  Please try again.";
            }

            if (password1 != password2)
            {
                // messagebox Passwords don't match
                txtPassword1.Text = string.Empty;
                txtPassword2.Text = string.Empty;
                returnVal = "Passwords do not match.  Please try again.";
            }
            else
            if (txtPassword1.Text.Length < 5)
            {
                // messagebox password too short
                returnVal = "Password too short.  Please try again.";
                divMessageBox.Visible = true;
            }
            else

            try
            {

                DataSet ds = new DataSet();
                string sqlCmdText = string.Empty;
                sqlCmdText = "RegisterUser";
                SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["TimeTraxConnectionString"]));
                using (conn)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sqlCmdText;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password1);
                    cmd.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    conn.Close();
                }
                
                returnVal = ds.Tables[0].Rows[0]["ReturnVal"].ToString();
                    if (returnVal == "Success")
                    {
                        Session["EmployeeEmail"] = email;
                    }
                }
            catch (Exception ex)
            {
                returnVal = ex.ToString();

            }

            return returnVal;
        }

        protected void btnMessagebox_Click(object sender, EventArgs e)
        {
            divMessageBox.Visible = false;
            if (Session["divActive"].ToString() == "divLogin")
            {
                divLogin.Visible = true;
            }
            if (Session["divActive"].ToString() == "divRegister")
            {
                divRegister.Visible = true;
            }

        }

        protected void RegisterAndLogin_Click(object sender, EventArgs e)
        {
            Session["divActive"] = "divRegister";
            divMessageBox.Visible = false;
            string registerResult = Register();
            if (registerResult == "Success")
            {
                Response.Redirect("Home.aspx", true);
            }
            else
            {
                divRegister.Visible = false;
                lblMessagebox.Text = registerResult;
                divMessageBox.Visible = true;

            }
        }

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            divRegister.Visible = false;
            divMessageBox.Visible = false;
            divLogin.Visible = true;
        }
    }
}