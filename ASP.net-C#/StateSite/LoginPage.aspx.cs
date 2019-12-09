using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectVer1Steven
{
    public partial class ChangePasswordForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnForgotPwd_Click(object sender, EventArgs e)
        {
            /// sends user to the forgot password page
            Response.Redirect("ChangePassword.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ///calls login method 
            ///if valid login, displays message, then sends user to new page
            ///if not valid login, displays message and lets user try login again
            Account acc = new Account();
            if (acc.LoginPageM(txtEmail, txtPassword) == true)
            {
                string deleteacc = txtEmail.Text;
                Session["deleteacc"] = deleteacc;
                string sessionAccount = txtEmail.Text;
                Session["sessionAccount"] = sessionAccount;
                Response.Redirect("UpdateOrDelete.aspx");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Incorrect email or password!");
                txtEmail.Text = "";
                txtPassword.Text = "";
            }
        }
    }
}