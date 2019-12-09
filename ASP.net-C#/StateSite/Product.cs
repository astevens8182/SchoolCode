using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
/// <summary>
/// This clas displays all the product details in the product details and displays them in the approatiate controls
/// Source for picture is https://www.madeinkc.co
/// </summary>
namespace ProjectVer1Steven
{
    public class Product
    {
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductImageURL { get; set; }
        public decimal ProductPrice { get; set; }
    
        public Product ()
        {

        }
        
        public void DetailsPageInformation(string productName, decimal productPrice, int productQuantity, string productDescription, string productImage, string SessionProductID ,Image detailsImage, Label productNamelabel, Label productDescriptionLabel,Label  quanLabel, Label priceLabel, DropDownList ddlQuantityOrdered )
        {
            SqlConnection connection = new SqlConnection("Data Source = SQLEXPRESS; Initial Catalog = steveale_db; Integrated Security = True");
            SqlCommand command = new SqlCommand("SELECT * FROM Product WHERE Number =@Number", connection);
            ///image
            using (connection)
            {
                var sql = "SELECT ImageURL FROM Product WHERE Number = @Number";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Number", SessionProductID);
                    connection.Open();
                    productImage = (string)cmd.ExecuteScalar();
                    connection.Close();

                }
                ///name
                var sql1 = "SELECT Name FROM Product WHERE Number = @Number";
                using (var cmd = new SqlCommand(sql1, connection))
                {
                    cmd.Parameters.AddWithValue("@Number", SessionProductID);
                    connection.Open();
                    productName = (string)cmd.ExecuteScalar();
                    connection.Close();
                }
                //desc
                var sql2 = "SELECT Description FROM Product WHERE Number = @Number";
                using (var cmd = new SqlCommand(sql2, connection))
                {
                    cmd.Parameters.AddWithValue("@Number", SessionProductID);
                    connection.Open();
                    productDescription = (string)cmd.ExecuteScalar();
                    connection.Close();

                }
                ///quan avail
                var sql3 = "SELECT Quantity FROM Product WHERE Number = @Number";
                using (var cmd = new SqlCommand(sql3, connection))
                {
                    cmd.Parameters.AddWithValue("@Number", SessionProductID);
                    connection.Open();
                    productQuantity = (int)cmd.ExecuteScalar();
                    connection.Close();

                }
                ///price
                var sql4 = "SELECT Price FROM Product WHERE Number = @Number";
                using (var cmd = new SqlCommand(sql4, connection))
                {
                    cmd.Parameters.AddWithValue("@Number", SessionProductID);
                    connection.Open();
                    productPrice = (decimal)cmd.ExecuteScalar();
                    connection.Close();

                }

            }
            /// displays information on page controls
            detailsImage.ImageUrl = productImage;
            productNamelabel.Text = productName.ToString();
            productDescriptionLabel.Text = productDescription.ToString();
            quanLabel.Text = productQuantity.ToString();
            priceLabel.Text = productPrice.ToString("C");

            /// loop for ddl 
            ///loop for ddl for quanity availble
            for (int i = 1; i <= productQuantity; i++)
            {
                ddlQuantityOrdered.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }


          

        }

    }
}