using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            DbConnection VTBAGLANTI = new DbConnection();
            SqlConnection baglanitmiz = VTBAGLANTI.ConnectDatabase();

            SqlCommand sqlcommand = new SqlCommand("Select * from Kullanicilar where KullaniciId = @id ", baglanitmiz);
            sqlcommand.Parameters.AddWithValue("@id", 26);
            SqlDataReader sqlOkuyucu = sqlcommand.ExecuteReader();
            if (sqlOkuyucu.Read())
            {
                if (sqlOkuyucu["KullaniciMail"].ToString() == uname.Value && sqlOkuyucu["KullaniciSifre"].ToString() == psw.Value)
                {
                    Session["girisyapildi"] = "1";

                    Session["isimsoyisim"] = sqlOkuyucu["KullaniciMail"].ToString();
                    Response.Redirect("YönetimPaneli.aspx");
                }
                else
                {
                    Session["girisyapildi"] = "0";
                    Response.Redirect("Homepage.aspx");
                }

            }
            baglanitmiz.Close();
        }
    }
}