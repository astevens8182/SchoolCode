using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxPractice
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            //Include three second delay for example only. 
            System.Threading.Thread.Sleep(3000);

        }
    }
}