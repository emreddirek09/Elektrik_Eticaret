using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class Default : System.Web.UI.Page
    {
        static string kullaniciId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UrünCek();
                UrunleriGetir();
                KampanyaliUrunleriGetir();
                BannerCek();
                Getir();
                /*KapmayaCek()*/;
            }
            
            try
            {
                kullaniciId = Session["userid"].ToString();
                //SESSION ID BOŞ OLMAMASI DURUMUNDA UYE BİLGİLERİ GETİRİRS
                Bring_Member();

            }
            catch (Exception)
            {


            }
            //MENU VE SEPETTE BULUNAN ÜRÜNLERİ TEMİZLEME
            Listing();

            if (Session["basketCount"] != null)
            {
                sup.Text = Session["basketCount"].ToString();

            }
            else
            {
                sup.Text = "0";
                basketlist.DataSource = Session["basket"];
                basketlist.DataBind();
            }
        }

        private void UrünCek()
        {
            Proje.Business.Kategoriler kategorilerNesne = new Proje.Business.Kategoriler();

            foreach (var item in kategorilerNesne.Listele())
            {
                var i = item.KategoriId;
                string KatAdi = kategorilerNesne.KategoriCek(i).KategoriAd;
                int Katid = kategorilerNesne.KategoriCek(i).KategoriId;                
                DropDownList1Urün.Items.Add(new ListItem(KatAdi, "Homepage.aspx?KategoriId="+ Katid.ToString()));
            }
        }
        //private void KapmayaCek()
        //{
        //    Proje.Business.Kampanyalar kampanyalarNesne = new Proje.Business.Kampanyalar();
        //    foreach (var item in kampanyalarNesne.Listele())
        //    {
        //        var i = item.KampanyaId;
        //        string KatAdi = kampanyalarNesne.KategoriCek(i).KampanyaAd;
        //        int Katid = kampanyalarNesne.KategoriCek(i).KampanyaId;
        //        DropDownList2Kampanya.Items.Add(new ListItem(KatAdi, "Homepage.aspx?KampanyaId=" + Katid.ToString()));
        //    }
        //}
        

        protected void SEpettekiUrunleriGetir()
        {
            //ödeme kısmında sessionumuzda bulunan ürünleri yükledik
            if (Session["basketCount"] != null)
            {
                sup.Text = Session["basketCount"].ToString();

            }
            else
            {
                sup.Text = "0";
                basketlist.DataSource = Session["basket"];
                basketlist.DataBind();
            }
        }


        protected void Listing()
        {
            SEpettekiUrunleriGetir();

        }


        protected void Bring_Member()
        {
            DbConnection DBBAGLANTI = new DbConnection();
            SqlConnection sqlConnection = DBBAGLANTI.ConnectDatabase();
            SqlCommand SQLCOMMAND = new SqlCommand("Select * from Kullanicilar where KullaniciID='" + kullaniciId + "' ", sqlConnection);

            SqlDataReader SQLDATAREADER = SQLCOMMAND.ExecuteReader();//readerimiz komutumuzu okudu
            if (SQLDATAREADER.Read())
            {
                Adsoyad.Text = SQLDATAREADER["KullaniciAdSoyad"].ToString();//giriş yapan üyenin bilgileri getilrili.
            }
            sqlConnection.Close();//baglantımızı kapattık cikisbutton.Visible = true;
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //session sepetimiz dolu ise ödeme sayfasına gönderirir.
            Response.Redirect("Odeme.aspx");
        }
        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            Session.Contents.Remove("basket");
            sup.Text = "0";
            //sepet temizlenir
            Response.Redirect(Page.Request.Url.ToString(), true);
            //Response.Redirect("homepage.aspx");

        }
        protected void giris_Click(object sender, EventArgs e)
        {

            if (kullaniciId == null)
            {
                Response.Redirect("Odeme.aspx");
            }
            Response.Redirect("UsersProfil.aspx");

        }
        protected void logout(object sender, EventArgs e)
        {
            Session.Contents.Remove("userid");
            Response.Redirect("Default.aspx", true);
            //Response.Redirect("homepage.aspx");
        }

        protected void DropDownList1Urün_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = DropDownList1Urün.SelectedItem.Value;
            if (DropDownList1Urün.SelectedItem.Value == "-1")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect(a);
            }

        }

        protected void Kampanyalar_Click(object sender, EventArgs e)
        {
            Response.Redirect("KampayaliUrunler.aspx");
        }
        protected void UrunleriGetir()
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("select TOP(4)* from Urunler join Markalar on Markalar.MarkaId = Urunler.UrunMarkaId join Kategoriler on Kategoriler.KategoriId = Urunler.UrunKategoriId WHERE Urunler.UrünIndirimFiyat IS NULL order by Urunler.UrunId desc ", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            RepeaterUrunler.DataSource = reader;
            RepeaterUrunler.DataBind();

            baglanti.Close();
        }
        protected void Getir()
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("select TOP(2)* from Urunler join Markalar on Markalar.MarkaId = Urunler.UrunMarkaId join Kategoriler on Kategoriler.KategoriId = Urunler.UrunKategoriId WHERE Urunler.UrünIndirimFiyat IS NULL", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            Repeater3.DataSource = reader;
            Repeater3.DataBind();
            baglanti.Close();
        }
        protected void KampanyaliUrunleriGetir()
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("select TOP(4)* from Urunler join Markalar on Markalar.MarkaId = Urunler.UrunMarkaId join Kategoriler on Kategoriler.KategoriId = Urunler.UrunKategoriId WHERE Urunler.UrünIndirimFiyat IS NOT NULL order by Urunler.UrunId desc ", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            Repeater1.DataSource = reader;
            Repeater1.DataBind();

            baglanti.Close();
        }
        protected void BannerCek()
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("select TOP(1)* from Kampanyalar order by KampanyaId desc", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            Repeater2.DataSource = reader;
            Repeater2.DataBind();

            baglanti.Close();
        }

    }
}