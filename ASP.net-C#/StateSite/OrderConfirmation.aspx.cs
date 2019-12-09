using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectVer1Steven
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int extensionNumber = Convert.ToInt32(Session["extensionNumber"]);
            decimal sessionSubtotal = Convert.ToDecimal(Session["subtotalSession"]);
            decimal sessionTotal = Convert.ToDecimal(Session["totalSession"]);
            decimal sessionShipping = Convert.ToDecimal(Session["shippingSession"]);
            lblShipping.Text = sessionShipping.ToString("c");
            lblSubTotal.Text = sessionSubtotal.ToString("c");
            lblTotal.Text = sessionTotal.ToString("c");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}