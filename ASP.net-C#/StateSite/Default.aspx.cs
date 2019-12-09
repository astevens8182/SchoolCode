using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectVer1Steven
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ///sends user to create account page
            Response.Redirect("CreateAccount.aspx");
        }

        protected void btnUpdateDelete_Click(object sender, EventArgs e)
        {
            ///sends user to the login page
            Response.Redirect("LoginPage.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }
    }
}