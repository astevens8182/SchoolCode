using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccesingDBTable
{

    public partial class Default : System.Web.UI.Page {
        decimal hoursWorked = 0.0M;
        decimal grossPay = 0.0M;
        decimal payRate = 0.0M;
        double overtimeRate = 1.5;
       


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {



            string query1 = "SELECT * FROM [Payroll] ";
            string countRecords = "SELECT COUNT(*) FROM [Payroll]";
            SqlConnection Conn1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["steveale_dbConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query1, Conn1);
            SqlCommand totalCount = new SqlCommand(countRecords, Conn1);
            Conn1.Open();
            DataTable dataTable1 = new DataTable();
            dataTable1.Load(cmd.ExecuteReader());
            foreach (DataRow record1 in dataTable1.Rows)
            //you now have a collection you can go through - in variable record1 
            // rows is indexable 
            // record1 is just my name for the returned rows of the result 
            {
                payRate = Convert.ToDecimal(record1[2]);
                hoursWorked = Convert.ToDecimal(record1[1]);

                if (hoursWorked <= 40)
                {
                    grossPay = payRate * hoursWorked;
                }
                else
                {
                    grossPay = 40 * payRate;
                    grossPay += (hoursWorked - 40) * (payRate * (Convert.ToDecimal(overtimeRate)));
                }
                DropDownList1.Items.Add(record1[0].ToString() + " " + "Gross pay: " + string.Format("${0:#.00}", Convert.ToDecimal(grossPay)));
                grossPay = 0;
            }
            DropDownList1.Items.Add("Total records: " + totalCount.ExecuteScalar().ToString());

        }

    }
}