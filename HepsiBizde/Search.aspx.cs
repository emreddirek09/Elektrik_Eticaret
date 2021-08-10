using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        public string Id { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UrunKontrol();
        }

        protected void SearchUrunler(string cId)
        {
            DbConnection conn = new DbConnection();
            SqlConnection baglanti = conn.ConnectDatabase();
            //SqlCommand command = new SqlCommand("select * from Urunler join Markalar on Markalar.MarkaId = Urunler.UrunMarkaId join Kategoriler on Kategoriler.KategoriId = Urunler.UrunKategoriId WHERE Urunler.UrunKategoriId='" + cId + "' && Urunler.UrünKampanyaId ='" + kampid + "'", baglanti);
            SqlCommand command = new SqlCommand("select * from Urunler join Markalar on Markalar.MarkaId = Urunler.UrunMarkaId join Kategoriler on Kategoriler.KategoriId = Urunler.UrunKategoriId WHERE Urunler.UrunAd LIKE '%" + cId + "%'", baglanti);
           

            SqlDataReader okuyucu = command.ExecuteReader();
            ProductRepeater.DataSource = okuyucu;
            ProductRepeater.DataBind();
            baglanti.Close();
        }
        protected void UrunKontrol()
        {
            try
            {
                Id = Request.QueryString["UrunAd"].ToString();
                SearchUrunler(Id);
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}