using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeTrax
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmWebService1.WebService1SoapClient client = new EmWebService1.WebService1SoapClient();
            // Button1.Text = client.HelloWorld();
            Label2.Text = client.GetProjectTitle("31bf3856and364e35", TextBox1.Text);


        }
    }
}