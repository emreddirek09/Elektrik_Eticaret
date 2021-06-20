using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            denemediv1.Visible = false;
            denemediv2.Visible = false;
            denemediv3.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            denemediv1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            denemediv2.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
             denemediv3.Visible = true;
        }
    }
}