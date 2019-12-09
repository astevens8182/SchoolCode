using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageLab
{
    public partial class Default : System.Web.UI.Page
    {
        void Page_Load(object sender, EventArgs e)
        {
            CompanyName.Text = Master.CompanyName;
        }
      
    }
}