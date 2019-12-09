using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectVer1Steven
{
    public partial class CreateNewPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string sessionAccount;
            sessionAccount = Session["sessionAccount"].ToString();

            if (sessionAccount == "")
            {
                Response.Redirect("LoginPage.aspx");

            }


        }



        protected void btnChange_Click(object sender, EventArgs e)
        {
            /// checks to see if the passwords match eachother and if they do provides message, if not provides error message and clears the txtboxes for user to reenter the password
            string changePasswordEmail = Session["changePasswordEmail"].ToString();
            Account acc = new Account();

            if (acc.ChangePassword(txtNewPassword, txtReenterPassword, changePasswordEmail) == true)
            {
                System.Windows.Forms.MessageBox.Show("Your password has been changed!");
                Response.Redirect("Default.aspx");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Your passwords do not match!");
                txtNewPassword.Text = "";
                txtReenterPassword.Text = "";

            }
        }
    }
}
