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
   
    public partial class PaymentMethod : System.Web.UI.Page
    {
        private CartItemList cart;
        string sessionAccount = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            cart = CartItemList.GetCart();


            lblSFName.Visible = false;
            lblSLName.Visible = false;
            lblShippingaddress.Visible = false;
            lblSAddress.Visible = false;
            lblSCity.Visible = false;
            lblSState.Visible = false;
            lblSZip.Visible = false;

            txtSAddress.Visible = false;
            txtSCity.Visible = false;
            txtSFName.Visible = false;
            txtSLName.Visible = false;
            txtSZip.Visible = false;
            ddlSStates.Visible = false;

      
        }

        protected void radYes_CheckedChanged(object sender, EventArgs e)
        {
          
            
        }

        protected void radNo_CheckedChanged(object sender, EventArgs e)
        {
            lblSFName.Visible = true;
            lblSLName.Visible = true;
            lblShippingaddress.Visible = true;
            lblSAddress.Visible = true;
            lblSCity.Visible = true;
            lblSState.Visible = true;
            lblSZip.Visible = true;

            txtSAddress.Visible = true;
            txtSCity.Visible = true;
            txtSFName.Visible = true;
            txtSLName.Visible = true;
            txtSZip.Visible = true;
            ddlSStates.Visible = true;
            
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnProceedOrderConfirm_Click(object sender, EventArgs e)
        {
            int extensionNumber = Convert.ToInt32(Session["extensionNumber"]);
           sessionAccount= Session["sessionAccount"].ToString();
            decimal Subtotal = 0m;
            decimal ShippingCost = 7.99m;
            decimal SalesTax = 1.065m;
            decimal Total = 0.0m;
            string CreditCardType = "";
            double CardNumber = 0;
            string ExpirationMonth = "";
            string ExpirationYear = "";
            string CvcCode = "";


            CreditCardType = ddlCreditCardType.Text.ToString();
            CardNumber = Convert.ToDouble(txtCreditCardNumber.Text);
            ExpirationMonth = ddlExpMonth.Text.ToString();
            ExpirationYear = ddlexpYear.Text.ToString();
            CvcCode = txtcreditCardCVCcode.Text.ToString();

            int tempquanity = 0;
            decimal tempPrice = 0.0m;
            for (int i = 0; i < CartItemList.GetCart().Count; i++)
            {
                tempquanity = cart[i].Product.ProductQuantity;
                tempPrice = cart[i].Product.ProductPrice;

                Subtotal += tempPrice * tempquanity;

            }
            Total = (Subtotal + ShippingCost) * SalesTax;

            Session["subtotalSession"] = Subtotal;
            Session["totalSession"] = Total;
            Session["shippingSession"] = ShippingCost;
            Session["taxSession"] = "6.5%";


            string query = "INSERT INTO Invoices(extension, OrderDate, Subtotal, CustEmail, ShippingCost, SalesTax, Total, CreditCardType, CardNumber, ExpirationMonth, ExpirationYear, CvcCode)" + 
                "Values('" + Subtotal + "', '" + sessionAccount + "', '" + ShippingCost + "', '" + SalesTax + "', '" + Total + "', '" + CreditCardType + "', '" + CardNumber + "', '" + ExpirationMonth + "', '" + ExpirationYear + "', '" + CvcCode  + "')";

            using (SqlConnection connection = new SqlConnection("Data Source = SQLEXPRESS; Initial Catalog = steveale_db; Integrated Security = True"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into Invoices (extension, OrderDate, Subtotal, CustEmail, ShippingCost, SalesTax, Total, CreditCardType, CardNumber, ExpirationMonth, ExpirationYear, CvcCode)" +
                        "VALUES (@extension, @OrderDate, @Subtotal, @CustEmail, @ShippingCost, @SalesTax, @Total, @CreditCardType, @CardNumber, @ExpirationMonth, @ExpirationYear, @CvcCode)";
                    command.Parameters.AddWithValue("@extension", extensionNumber);

                    command.Parameters.AddWithValue("@OrderDate",DateTime.Now);
                    command.Parameters.AddWithValue("@Subtotal", Subtotal);
                    command.Parameters.AddWithValue("@CustEmail", sessionAccount);
                    command.Parameters.AddWithValue("@ShippingCost", ShippingCost);
                    command.Parameters.AddWithValue("@SalesTax", SalesTax);
                    command.Parameters.AddWithValue("@Total", Total);
                    command.Parameters.AddWithValue("@CreditCardType", CreditCardType);
                    command.Parameters.AddWithValue("@CardNumber", CardNumber);
                    command.Parameters.AddWithValue("@ExpirationMonth", ExpirationMonth);
                    command.Parameters.AddWithValue("@ExpirationYear", ExpirationYear);
                    command.Parameters.AddWithValue("@CvcCode", CvcCode);
                    command.ExecuteNonQuery();

                    connection.Close();









                }
            }
            Response.Redirect("OrderConfirmation.aspx");
        }
    }
}