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
    public partial class CreateNewPasswordHaveOldPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            /// calls method to change password
            /// checks to see if new password matches old password and display's correspoinding messages

            Account acc = new Account();
            string changePasswordEmail = Session["deleteacc"].ToString();
            if (acc.ChangePasswordKnowOldPwd(txtOldPassword,txtNewPassword,txtReenterPassword, changePasswordEmail) == true)
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