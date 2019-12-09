using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectVer1Steven
{
    public partial class Master1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionAccount;
            try
            {
                sessionAccount = Session["sessionAccount"].ToString();
               
            }
            catch (NullReferenceException )
            {
                sessionAccount = "";
            }
            if (sessionAccount != "")
            {
                btnSessionLogin.Text = sessionAccount.ToString();
                
            }
          

        }

        protected void btnSessionLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
     
        }
    }
}