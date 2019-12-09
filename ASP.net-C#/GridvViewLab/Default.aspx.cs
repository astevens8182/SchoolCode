using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GridViewLab
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] stringArray = Directory.GetFiles(Server.MapPath("~/Images/"));
            List<ListItem> Imgs = new List<ListItem>();
            foreach (string l in stringArray)
            {
               string shortname  = Path.GetFileName(l);

                string imageName = "~/Images/" + shortname ;
                Imgs.Add(new ListItem(shortname, imageName));
                Grid1.DataSource = Imgs;
                Grid1.DataBind();
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (fileUploadControl.HasFile)
            {
              string  fileName = fileUploadControl.FileName;
               fileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}