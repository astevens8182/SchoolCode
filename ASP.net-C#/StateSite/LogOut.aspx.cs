using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectVer1Steven
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

                Session["sessionAccount"] = "";
            }

        }
    }
}