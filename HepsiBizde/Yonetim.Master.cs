using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class Yonetim : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {  //giris yapma durumu true ise labele kullanıcı adı yazılır
                if (Session["girisyapildi"].ToString() == "1") { Girislabel.Text = Session["isimsoyisim"].ToString();  }
                else  { Response.Redirect("login.aspx"); }//giriş yapılmadıysa logine yönlendirilir.
            }
            catch (Exception)
            { Response.Redirect("login.aspx");  }//herhangi bir hata olursa örneğin boş gelme gibi tekrar logine yönlendirir.
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("girisyapildi");// logout click ile session temizlenir.
            Response.Redirect("Login.aspx", true); // 
        }
    }
}