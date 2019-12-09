using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace StoredProcLab
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only run this code the first time the page is loaded.
            // The code inside the IF statement is skipped when you resubmit the page.
            if (!IsPostBack)
            {
                //Create a connection to the SQL Server; modify the connection string for your environment
                //SqlConnection MyConnection = new SqlConnection("server=(local);database=pubs;Trusted_Connection=yes");
                SqlConnection MyConnection = new SqlConnection("Data Source=sqlexpress;Initial Catalog=steveale_db;Integrated Security=True;");

                // Create a Command object, and then set the connection.
                // check whether a GetContactsByLastName  
                // stored procedure already exists.
                SqlCommand MyCommand = new SqlCommand("select * from sysobjects where id = object_id(N'GetContactsByLastName')" +
                "  and OBJECTPROPERTY(id, N'IsProcedure') = 1", MyConnection);

                // Set the command type that you will run.
                MyCommand.CommandType = CommandType.Text;

                // Open the connection.
                MyCommand.Connection.Open();

                // Run the SQL statement, and then get the returned rows to the DataReader.
                SqlDataReader MyDataReader = MyCommand.ExecuteReader();

                // If any rows are returned, the stored procedure that you are trying 
                // to create already exists. Therefore, try to create the stored procedure
                // only if it does not exist.
                if (!MyDataReader.Read())
                {
                    MyCommand.CommandText = "create procedure GetContactsByLastName" +
                    " (@lname varchar(30), select * from Contacts where" +
                    " ContactLastName like @lname; select @RowCount=@@ROWCOUNT";
                    MyDataReader.Close();
                    MyCommand.ExecuteNonQuery();
                }
                else
                {
                    MyDataReader.Close();
                }

                MyCommand.Dispose();  //Dispose of the Command object.
                MyConnection.Close(); //Close the connection.
            }

            // Add the event handler to the Button_Click event.
            this.btnGetContacts.Click += new System.EventHandler(this.btnGetContacts_Click);

        }

        protected void btnGetContacts_Click(object sender, EventArgs e)
        {
            //Create connection to the SQL Server; modify the connection string for your environment.
            //SqlConnection MyConnection = new SqlConnection("server=(local);database=pubs;Trusted_Connection=yes");
            SqlConnection MyConnection = new SqlConnection("Data Source=sqlexpress;Initial Catalog=steveale_db;Integrated Security=True;");

            //Create a DataAdapter, and then provide the name of the stored procedure.
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("GetContactsByLastName", MyConnection);

            //Set the command type as StoredProcedure.
            MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            //Create and add a parameter to Parameters collection for the stored procedure.
            MyDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@lname", SqlDbType.VarChar, 30));

            //Assign the search value to the parameter.
            MyDataAdapter.SelectCommand.Parameters["@lname"].Value = (txtLastName.Text).Trim();

            //Create and add an output parameter to the Parameters collection. 
            MyDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@RowCount", SqlDbType.Int, 4));

            //Set the direction for the parameter. This parameter returns the Rows that are returned.
            MyDataAdapter.SelectCommand.Parameters["@RowCount"].Direction = ParameterDirection.Output;

            //Create a new DataSet to hold the records.
            DataSet DS = new DataSet();

            //Fill the DataSet with the rows that are returned.
            MyDataAdapter.Fill(DS, "ContactsByLastName");

            //Get the number of rows returned, and assign it to the Label control.
            //lblRowCount.Text = DS.Tables(0).Rows.Count().ToString() & " Rows Found!"
            lblRowCount.Text = MyDataAdapter.SelectCommand.Parameters[1].Value + " Rows Found!";

            //Set the data source for the DataGrid as the DataSet that holds the rows.
            GrdContacts.DataSource = DS.Tables["ContactsByLastName"].DefaultView;

            //NOTE: If you do not call this method, the DataGrid is not displayed!
            GrdContacts.DataBind();

            MyDataAdapter.Dispose(); //Dispose the DataAdapter.
            MyConnection.Close(); //Close the connection.
        }

    }
}
