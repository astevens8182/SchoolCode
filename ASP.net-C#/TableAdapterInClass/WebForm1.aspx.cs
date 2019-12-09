using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TableAdapterInClass
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.AddressesTableAdapter tableAdapter = new DataSet1TableAdapters.AddressesTableAdapter();
            tableAdapter.InsertQuery(txtFirst.Text, txtLast.Text);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.AddressesTableAdapter tableAdapter = new DataSet1TableAdapters.AddressesTableAdapter();
            tableAdapter.DeleteQuery(txtFirst.Text, txtLast.Text);
        }
    }
}