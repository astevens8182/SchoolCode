using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProjectVer1Steven
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        
  

        

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void BtnCreateAcc_Click(object sender, EventArgs e)
        {
            ///Calls new method to create account and displays message if the account was succesfully added to the db
            Account acc = new Account();
            
            acc.Email = txtEmail.Text;
            acc.FirstName = txtFirstName.Text;
            acc.LastName = txtLastName.Text;
            acc.Password = txtPassword.Text;
            acc.SecurityQuestion = ddlSecurityQuest.Text;
            acc.SecurtiyQuestionAnwser = txtSecurityQuestAns.Text;
            acc.PhoneNumber = txtPhoneNumber.Text;
            acc.StreetAddress1 = txtStreetAddress1.Text;
            acc.StreetAddress2 = txtStreetAddress2.Text;
            acc.State = ddlStates.Text;
            acc.City = txtCity.Text;
            acc.ZipCode = txtZipCode.Text;


            acc.CreateAccountDB(acc.Email, acc.FirstName, acc.LastName, acc.Password, acc.SecurityQuestion, acc.SecurtiyQuestionAnwser, acc.PhoneNumber, acc.StreetAddress1, acc.StreetAddress2, acc.City, acc.State, acc.ZipCode);
            System.Windows.Forms.MessageBox.Show("Your account has been created!");

            Response.Redirect("Default.aspx");
        }

     

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
     
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            /// calls method to see if the email is already in the db
            /// if the email is already in use then an error message is display and the user is redirected to the home page
            Account acc = new Account();
            if (acc.ValidEmailCheck(txtEmail.Text) == true)
            {
                System.Windows.Forms.MessageBox.Show("You already have an account please login");
                Response.Redirect("Default.aspx");

            }
        }
    }

}