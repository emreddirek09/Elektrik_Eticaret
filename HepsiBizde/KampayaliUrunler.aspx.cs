using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VeriCek();
        }
        private void VeriCek()
        {
            Proje.Business.Kampanyalar kampanyalarNesne = new Proje.Business.Kampanyalar();
            var liste = kampanyalarNesne.Listele();
            RepeaterKampanya.DataSource = liste;
            RepeaterKampanya.DataBind();
        }
    }
}