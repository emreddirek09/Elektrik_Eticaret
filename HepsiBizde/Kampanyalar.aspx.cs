using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        private string deger;

        protected void Page_Load(object sender, EventArgs e)
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("select * from Kampanyalar ", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            RepeaterKampanya.DataSource = reader;
            RepeaterKampanya.DataBind();
        }
        protected void login_ServerClick(object sender, EventArgs e)
        { 
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Hello" + "')", true);
        }

        protected void incele_Click(object sender, EventArgs e)
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            LinkButton link = (LinkButton)sender;
            deger = link.CommandArgument;
            Response.Redirect("KampayaliUrunler.aspx?UrünKampanyaId=" + deger );
            baglanti.Close();

        }
    }
}