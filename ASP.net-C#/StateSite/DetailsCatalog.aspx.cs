using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectVer1Steven
{
    public partial class DetailsCatalog : System.Web.UI.Page
    {
        private Product selectedProduct;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionProduct;
            sessionProduct = Session["sessionProduct"].ToString();


            string productName = "";
            decimal productPrice = 0.0M;
            int productQuantity = 0;
            string productDescription = "";
            string productImage = "";

            Product p = new Product();
            p.DetailsPageInformation(productName, productPrice, productQuantity, productDescription, productImage, sessionProduct, detailsImage, productNamelabel, productDescriptionLabel,quanLabel,priceLabel, ddlQuantityOrdered );

            selectedProduct = this.getSelectedProduct();


        }
       
        private Product getSelectedProduct()
        {
            Product p = new Product();
            string tempPrice = "";
             p.ProductNumber = Session["sessionProduct"].ToString();
          tempPrice=  Convert.ToString(priceLabel.Text).Replace("$", String.Empty);
            p.ProductPrice = Convert.ToDecimal(tempPrice);
            p.ProductName = productNamelabel.Text;
            p.ProductQuantity = Convert.ToInt32(ddlQuantityOrdered.SelectedItem.Text);
            return p;
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
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

        
                
            if (IsValid)
            {
                CartItemList cart = CartItemList.GetCart();
                CartItem cartItem = cart[selectedProduct.ProductNumber];

                if (cartItem == null)
                {
                    cart.AddItem(selectedProduct, Convert.ToInt32(ddlQuantityOrdered.SelectedItem.Text));
                }
                else
                {
                    cartItem.AddQuantity(Convert.ToInt32(ddlQuantityOrdered.SelectedItem.Text));
                }

            }
                Response.Redirect("~/Cart.aspx");
            
        }
    }
}