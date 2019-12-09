using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageLab
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["masterpage"] != null)
            {
                this.MasterPageFile = (String)Session["masterpage"];
            }
        }
    }
}