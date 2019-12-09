using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageLab
{
    public partial class Master1 : System.Web.UI.MasterPage
    {
        public String CompanyName
        {
            get { return (String)ViewState["companyName"];  }
            set { ViewState["companyName"] = value; }
        }
        void Page_Init(object sender, EventArgs e)
        {
            this.CompanyName = "New Company Name";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["masterpage"] = "Master.master";
            Response.Redirect(Request.Url.ToString());
        }
    }
}