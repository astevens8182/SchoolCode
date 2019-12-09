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
    public partial class Cart : System.Web.UI.Page
    {
        private CartItemList cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            /// retrive cart object from session state on every postback
            cart = CartItemList.GetCart();
            //on initial page load, add cart items to list control
            if (!IsPostBack) this.DisplayCart();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            //if cart contains items and user has selected and item
            if (cart.Count > 0)
            {
                if (lstCart.SelectedIndex > -1)
                {
                    //remove selected item from cart and re-display cart
                    cart.RemoveAt(lstCart.SelectedIndex);
                    this.DisplayCart();
                }
                else
                {
                    //if no item is selected notify user
                    //lblMessage.Text = "Please select the item to remove";
                }
            }
        }
        private void DisplayCart()
        {
            //remove all current items from list control
            lstCart.Items.Clear();

            //Loop through cart and add each item's display value to the list
            for (int i =0; i < cart.Count; i++)
            {
                lstCart.Items.Add(cart[i].Display());
            }
        }

        protected void btnEmpty_Click(object sender, EventArgs e)
        {
            //if cart has items, clear both cart and list control
            if (cart.Count > 0)
            {
                cart.Clear();
                lstCart.Items.Clear();
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Session["cart"] = cart;




            Random rnd = new Random();
            int extensionNumber = rnd.Next(1, 2000000);
            Session["extensionNumber"] = extensionNumber;




            using (SqlConnection connection = new SqlConnection("Data Source = SQLEXPRESS; Initial Catalog = steveale_db; Integrated Security = True"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into LineItems(extension, ProductID, UnitPrice, Quantity)"  +
                        "VALUES (@extension, @ProductID, @UnitPrice, @Quantity)";
                    connection.Open();
                    for (int i = 0; i < CartItemList.GetCart().Count; i++)
                    {
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("@extension",extensionNumber);

                        command.Parameters.AddWithValue("@ProductID", cart[i].Product.ProductNumber.ToString());
                        command.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(cart[i].Product.ProductPrice));
                        command.Parameters.AddWithValue("@Quantity", Convert.ToInt32( cart[i].Quantity));
                        command.ExecuteNonQuery();

                    }




                    connection.Close(); 
                }

            }

                    
                        Response.Redirect("PaymentMethod.aspx");
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalog.aspx");
        }
    }
}