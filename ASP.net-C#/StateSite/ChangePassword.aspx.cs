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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {

            /// Create an new object and if the change password is correct then redirect to create new password page
            ///Else display with incorrect login information
            Account acc = new Account();

            if (acc.VerifySecurityQestions(txtEmail,ddlSecurityQuest,txtAnwser) == true)
            {
                string changePasswordEmail = txtEmail.Text;
                Session["changePasswordEmail"] = changePasswordEmail;
                Response.Redirect("CreateNewPassword.aspx");

            }
           
            else
            {
                System.Windows.Forms.MessageBox.Show("Incorrect email or anwser!");
                txtEmail.Text = "";
                txtAnwser.Text = "";
            }
        }


        
    }
}