using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectVer1Steven
{
    public partial class Catalog : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void ImageButton1_Click(object sender, EventArgs e)
        {

            ImageButton imageButton1 = sender as ImageButton;
            string commandName = imageButton1.CommandName;
            string commandArgument = imageButton1.CommandArgument;
            GridViewRow row = (imageButton1.NamingContainer as GridViewRow);
            int rowIndex = row.RowIndex;
            string sessionProduct = commandName.ToString();
           Session["sessionProduct"] = sessionProduct;
            Response.Redirect("DetailsCatalog.aspx");

        }
    }
}