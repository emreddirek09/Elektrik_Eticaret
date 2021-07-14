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
            //DbConnection ConnectDatabaseti = new DbConnection();
            //SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            //SqlCommand komut = new SqlCommand("select * from Kampanyalar inner join Urunler ON Urunler.UrünKampanyaId = Kampanyalar.KampanyaId ", baglanti);
            //SqlDataReader reader = komut.ExecuteReader();
            //RepeaterKampanya.DataSource = reader;
            //RepeaterKampanya.DataBind();
           VeriCek();
        }
       
        private void VeriCek()
        {
            Proje.Business.Kampanyalar kampanyalarNesne = new Proje.Business.Kampanyalar();
            var liste = kampanyalarNesne.Listele();
            RepeaterKampanya.DataSource = liste;
            RepeaterKampanya.DataBind();
        }
        protected void login_ServerClick(object sender, EventArgs e)
        { 
            //Response.Redirect("Default.aspx");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Hello" + "')", true);
        }

        protected void incele_Click(object sender, EventArgs e)
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            LinkButton link = (LinkButton)sender;
            deger = link.CommandArgument;
            //SqlCommand komut = new SqlCommand("select * from Kampanyalar inner join Urunler ON Urunler.UrünKampanyaId = Kampanyalar.KampanyaId where Urunler.UrünKampanyaId = 11 ", baglanti);
            //komut.Parameters.AddWithValue("@id",deger);
            //SqlDataReader reader = komut.ExecuteReader();
            Response.Redirect("Homepage.aspx?UrünKampanyaId="+ deger);
            //RepeaterKampanya.DataSource = reader;
            //RepeaterKampanya.DataBind();
            //reader.Close();
            baglanti.Close();

        }
    }
}