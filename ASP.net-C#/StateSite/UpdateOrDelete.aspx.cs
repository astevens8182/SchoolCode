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
    public partial class UpdateOrDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionAccount;
            try
            {
                sessionAccount = Session["sessionAccount"].ToString();

            }
            catch (NullReferenceException)
            {
                sessionAccount = "";
            }
            if (sessionAccount != "")
            {
                sessionAccount = Session["sessionAccount"].ToString();
            }

            if (sessionAccount == "")
            {
                Response.Redirect("LoginPage.aspx");

            }

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ///calls method to delete the user account
            ///then displays message that account was deleted and sends user to home page
            string deleteaccount = Session["deleteacc"].ToString();
            Account acc = new Account();
            if (acc.DeleteAccount(deleteaccount) == true)
            {
                System.Windows.Forms.MessageBox.Show("Your account has been been deleted!");
                Response.Redirect("Default.aspx");
            }
           

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            ///sends user to the change password if the have the old password page
            Response.Redirect("CreateNewPasswordHaveOldPwd.aspx");
        }
    }
}