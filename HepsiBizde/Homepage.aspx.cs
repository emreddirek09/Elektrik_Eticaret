using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string categoryId;

        public string KampanyaId { get; private set; }

        static List<Sepet> urunadlari = new List<Sepet>();

        protected void Page_Load(object sender, EventArgs e)
        {
            UrunKontrol();
        }

        protected void UrunleriKategoriOlarakGetir(string cId)
        {
            DbConnection conn = new DbConnection();
            SqlConnection baglanti = conn.ConnectDatabase();
            //SqlCommand command = new SqlCommand("select * from Urunler join Markalar on Markalar.MarkaId = Urunler.UrunMarkaId join Kategoriler on Kategoriler.KategoriId = Urunler.UrunKategoriId WHERE Urunler.UrunKategoriId='" + cId + "' && Urunler.UrünKampanyaId ='" + kampid + "'", baglanti);
            SqlCommand command = new SqlCommand("select * from Urunler join Markalar on Markalar.MarkaId = Urunler.UrunMarkaId join Kategoriler on Kategoriler.KategoriId = Urunler.UrunKategoriId WHERE Urunler.UrunKategoriId='"+cId+ "'", baglanti);

            SqlDataReader okuyucu = command.ExecuteReader();
            ProductRepeater.DataSource = okuyucu;
            ProductRepeater.DataBind();
            baglanti.Close();
        }

        protected void AllProducts_Click(object sender, EventArgs e)
        {
            categoryId = "";
            //bütün ürünleri listeleme
            Response.Redirect("homepage.aspx");
            //anasayfaya bütün ürünlere yönlendirdik
            ButunUrunleriGetir();
        }

        protected void ButunUrunleriGetir()
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            //Connection classımızı bağlantı kurduk

            SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            //bağlantımız açıldı

            SqlCommand komut = new SqlCommand("select * from Urunler join Markalar on Markalar.MarkaId = Urunler.UrunMarkaId join Kategoriler on Kategoriler.KategoriId = Urunler.UrunKategoriId ", baglanti);
            // Markalar Kategoriler ve Ürünleri innerjoin ile bağladık repeaterımıza datasource olarak gönderdik


            //komutumuzu datareadera yükledik
            SqlDataReader reader = komut.ExecuteReader();

            ProductRepeater.DataSource = reader;
            //repeater datasource atadık
            ProductRepeater.DataBind();

            baglanti.Close();
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LinkButton mybutton = (LinkButton)sender;
            // linkbuttonumuzu tanımladık
            Sepet sepet = new Sepet();
            //sepet classımızı çağırdık
            sepet.indexNo = Convert.ToInt32(mybutton.CommandArgument);
            sepet.Name = mybutton.CommandName;
            //ürün indexi ve ismi tanımladık
            urunadlari.Add(sepet);

            var basketCount = urunadlari.Count;

            //static sepetimize ekledik ve sepetimizi sessiona atadık
            Session["basket"] = urunadlari;
            Session["basketCount"] = basketCount;
            Response.Redirect("homepage.aspx#"+ mybutton.CommandArgument);

        }

        protected void UrunKontrol()
        {
            try
            {
                categoryId = Request.QueryString["KategoriId"].ToString();
                //KampanyaId = Request.QueryString["UrünKampanyaId"].ToString();
                UrunleriKategoriOlarakGetir(categoryId);
            }
            catch (Exception)
            {
                //query boş gelirse bütün ürünler listelenecek
                //sıkıntı çıkmazsa kategoriye göre listelenecek
                ButunUrunleriGetir();
            }

            if (Session["basket"] == null)
            {
                //sepet boşsa static listemiz temizleniyor
                urunadlari.Clear();
            }

            if (categoryId == null || categoryId.Length == 0)
            {
                //ctageori id boş ise bütün ürünlwe
                ButunUrunleriGetir();

            }
            else
            {
                //categori ıd boş değilse kategoryie göre getiriri.
                UrunleriKategoriOlarakGetir(categoryId);
            }
        }

    }
}