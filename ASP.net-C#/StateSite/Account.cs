using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProjectVer1Steven
{
    public class Account
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurtiyQuestionAnwser { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }


        /// <summary>
        /// Checks to make sure that the email that the user enterss is not already an account created
        /// </summary>
        /// <param name="emailp">The users entered email</param>
        /// <returns></returns>
        public bool ValidEmailCheck(string emailp)
        {
            SqlConnection connection = new SqlConnection("Data Source = SQLEXPRESS; Initial Catalog = steveale_db; Integrated Security = True");
            SqlCommand command = new SqlCommand("SELECT * FROM AccountTable WHERE EmailT =@EmailT", connection);
            command.Parameters.AddWithValue("@EmailT", emailp);
            connection.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            bool tOrf;
            int count=0;
            while (dataReader.Read())
            {
                if (dataReader.HasRows == true)
                {
                    count = 1;
                }
                else
                {
                    count = 0;
                }
            }
            if (count == 1)
            {
                tOrf = true;
            }
            else
            {
                tOrf = false;
            }
            return tOrf;
        }

        /// <summary>
        /// This is when the user is creating an account and it adds the user enters the and updates the information DB
        /// </summary>
        /// <param name="emailp">email</param>
        /// <param name="firstNamep">first name</param>
        /// <param name="lastNamep">last name</param>
        /// <param name="passwordp">password</param>
        /// <param name="secQuestp">security question</param>
        /// <param name="secQuestAwnp"> security question anwser</param>
        /// <param name="phoneNump">phone number</param>
        /// <param name="streetadd1p">primary street address</param>
        /// <param name="streetaddp">addtional street info</param>
        /// <param name="cityp">city</param>
        /// <param name="statep">state </param>
        /// <param name="zipcodep">sip code</param>
        public void CreateAccountDB(string emailp, string firstNamep, string lastNamep, string passwordp, string secQuestp, string secQuestAwnp, string phoneNump, string streetadd1p, string streetaddp, string cityp, string statep, string zipcodep)
        {
            string query = "INSERT INTO AccountTable(EmailT, FirstNameT, LastNameT, PasswordT, SecurityQuestionT, SecurityQuestionAnwserT, PhoneNumberT, StreetAddress1T, StreetAddress2T, CityT, StateT, ZipCodeT)" + "Values('" + emailp + "', '" + firstNamep + "', '" + lastNamep + "', '" + passwordp + "', '" + secQuestp + "', '" + secQuestAwnp + "', '" + passwordp + "', '" + streetadd1p + "', '" + streetaddp + "', '" + cityp + "', '" + statep + "', '" + zipcodep + "')";

            using (SqlConnection connection = new SqlConnection("Data Source = SQLEXPRESS; Initial Catalog = steveale_db; Integrated Security = True"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into AccountTable (EmailT, FirstNameT, LastNameT, PasswordT, SecurityQuestionT, SecurityQuestionAnwserT, PhoneNumberT, StreetAddress1T, StreetAddress2T, CityT, StateT, ZipCodeT) " +
                        "VALUES (@EmailT, @FirstNameT, @LastNameT, @PasswordT, @SecurityQuestionT, @SecurityQuestionAnwserT, @PhoneNumberT, @StreetAddress1T, @StreetAddress2T, @CityT, @StateT, @ZipCodeT)";
                    command.Parameters.AddWithValue("@EmailT", emailp);
                    command.Parameters.AddWithValue("@FirstNameT", firstNamep);
                    command.Parameters.AddWithValue("@LastNameT", lastNamep);
                    command.Parameters.AddWithValue("@PasswordT", passwordp);
                    command.Parameters.AddWithValue("@SecurityQuestionT", secQuestp);
                    secQuestAwnp = secQuestAwnp.ToUpper();
                    command.Parameters.AddWithValue("@SecurityQuestionAnwserT", secQuestAwnp);
                    command.Parameters.AddWithValue("@PhoneNumberT", phoneNump);
                    command.Parameters.AddWithValue("@StreetAddress1T", streetadd1p);
                    command.Parameters.AddWithValue("@StreetAddress2T", streetaddp);
                    command.Parameters.AddWithValue("@CityT", cityp);
                    command.Parameters.AddWithValue("@StateT", statep);
                    command.Parameters.AddWithValue("@ZipCodeT", zipcodep);

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                    }
                    finally
                    {
                        connection.Close();
                    }

                }



            }





        }
        /// <summary>
        /// This method verifies the securtiy question anwser with the user account for the forgot password page
        /// </summary>
        /// <param name="txtEmail">user email</param>
        /// <param name="ddlSecurityQuest">security question</param>
        /// <param name="txtAnwser">the answer to the question</param>
        /// <returns>verifyFinal if valid</returns>
        public bool VerifySecurityQestions(TextBox txtEmail, DropDownList ddlSecurityQuest, TextBox txtAnwser)
        {
            bool  verifyFinal;
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=SQLEXPRESS;Initial Catalog=steveale_db;Integrated Security=True";
            SqlCommand command = new SqlCommand("SELECT EmailT, SecurityQuestionT, SecurityQuestionAnwserT  FROM AccountTable Where EmailT=@EmailT and SecurityQuestionT=@SecurityQuestionT and SecurityQuestionAnwserT=@SecurityQuestionAnwserT", scn);
            scn.Open();
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@EmailT", txtEmail.Text);
            command.Parameters.AddWithValue("@SecurityQuestionT", ddlSecurityQuest.Text);
            command.Parameters.AddWithValue("@SecurityQuestionAnwserT", txtAnwser.Text.ToUpper());
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                verifyFinal = true;
                scn.Close();

                return verifyFinal;
            }
            else
            {
                verifyFinal = false;
                scn.Close();

                return verifyFinal;
            }

        }
        /// <summary>
        /// When the user remembers thier password and wants to change it. Then it is uploaded to the db
        /// </summary>
        /// <param name="txtNewPassword">new password</param>
        /// <param name="txtReenterPassword">reenters password</param>
        /// <param name="changePasswordEmail">the email that wants a new password</param>
        /// <returns>bool if valid</returns>
        public bool ChangePassword(TextBox txtNewPassword,TextBox txtReenterPassword, string changePasswordEmail)
        {
            SqlConnection connection = new SqlConnection("Data Source = SQLEXPRESS; Initial Catalog = steveale_db; Integrated Security = True");
            string changePasswordStatement = "UPDATE AccountTable  SET PasswordT = @PasswordT  WHERE EmailT = @EmailT";
            bool ValidChangePassword;
            if (txtNewPassword.Text == txtReenterPassword.Text)
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(changePasswordStatement, connection);
                    command.Parameters.AddWithValue("@EmailT", changePasswordEmail.ToString());
                    command.Parameters.AddWithValue("@PasswordT", txtNewPassword.Text);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    ValidChangePassword = true;
                    return ValidChangePassword;
                

                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                ValidChangePassword = false;
                
                return ValidChangePassword;
            }
        }
        /// <summary>
        /// this is method if the changing the old password while the user knows thier current password
        /// </summary>
        /// <param name="txtOldPassword">old password</param>
        /// <param name="txtNewPassword">new password</param>
        /// <param name="txtReenterPassword">reenter password</param>
        /// <param name="changePasswordEmail">email</param>
        /// <returns>valid if valid</returns>
        public bool ChangePasswordKnowOldPwd(TextBox txtOldPassword, TextBox txtNewPassword , TextBox txtReenterPassword, string changePasswordEmail)
        {
            SqlConnection connection = new SqlConnection("Data Source = SQLEXPRESS; Initial Catalog = steveale_db; Integrated Security = True");
            string changePasswordStatement = "UPDATE AccountTable  SET PasswordT = @PasswordT  WHERE EmailT = @EmailT";
            bool valid;
            if (txtOldPassword.Text != txtNewPassword.Text)
            {
                if (txtNewPassword.Text == txtReenterPassword.Text)
                {

                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(changePasswordStatement, connection);
                        command.Parameters.AddWithValue("@EmailT", changePasswordEmail.ToString());
                        command.Parameters.AddWithValue("@PasswordT", txtNewPassword.Text);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                        valid = true;
                        return valid;
                       

                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    valid = false;
                    return valid;
                   
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Your new password cannot match your old password!");
                txtNewPassword.Text = "";
                txtReenterPassword.Text = "";
                txtOldPassword.Text = "";
                valid = false;
                return valid;
            }


        }
        /// <summary>
        /// This is the method of the login page where it checks to see if the user has entered and provided valid login information
        /// </summary>
        /// <param name="txtEmail">user email</param>
        /// <param name="txtPassword">password</param>
        /// <returns>valid as true if record is a correct login attempt</returns>
        public bool LoginPageM(TextBox txtEmail, TextBox txtPassword)
        {
            bool valid;

            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=SQLEXPRESS;Initial Catalog=steveale_db;Integrated Security=True";
            SqlCommand command = new SqlCommand("SELECT COUNT (*) as count  FROM AccountTable Where EmailT=@EmailT and PasswordT=@PasswordT", scn);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@EmailT", txtEmail.Text);
            command.Parameters.AddWithValue("@PasswordT", txtPassword.Text);
            scn.Open();
            if (command.ExecuteScalar().ToString() == "1")
            {
                 valid = true;
                return valid;

            }
            else
            {
                scn.Close();

                valid = false;
                return valid;
 
            }
        }
        /// <summary>
        /// Method that allows the user to delete an already exsisting account in the db
        /// </summary>
        /// <param name="deleteaccount">the email of the account to be deleted</param>
        /// <returns>bool valid if the deletion of the account was successful</returns>
        public bool DeleteAccount(string deleteaccount)
        {
            SqlConnection connection = new SqlConnection("Data Source = SQLEXPRESS; Initial Catalog = steveale_db; Integrated Security = True");
            string deleteStatment = "DELETE FROM AccountTable WHERE EmailT = @EmailT";
            bool valid;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(deleteStatment, connection);
                command.Parameters.AddWithValue("@EmailT", deleteaccount);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                valid = true;
                return valid;
              

            }
            finally
            {
                connection.Close();
            }
        }
    }

    

}