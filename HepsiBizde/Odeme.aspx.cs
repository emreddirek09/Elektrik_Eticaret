using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        static string kullaniciId; 
        static string modified = "0";
        List<string> emails = new List<string>();
        List<Sepet> liste2 = new List<Sepet>();
        protected void Page_Load(object sender, EventArgs e)
        {
            siparisler.DataSource = Session["basket"];
            //sessionda tutulan sepetimizdkei ürünleri kullanıcıya listelemek
            siparisler.DataBind();
            //toplam sepet fşyatı
            Bring();
        }



        protected void UyeGetir()
        {
            try
            {
                kullaniciId = Session["userid"].ToString();

                //giris yapan kullanıcı ıdsi alma

                DbConnection Database = new DbConnection();
                //veritbanımıza bağlandık
                SqlConnection sqlConnection = Database.ConnectDatabase();
                //connectionumuzu açtık
                SqlCommand komut = new SqlCommand("Select * from Kullanicilar where KullaniciID='"+ kullaniciId + "' ", sqlConnection);
                //sql komudumuz

                SqlDataReader reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    OdemeDiv.Visible = true;
                    // kullanıcı girişi sağlandıktan sonra ödeme sağlanması için bilgilerin bulunduğu
                    //kısım kullanıcya görünür.
                }
                sqlConnection.Close();
            }
            catch (Exception)
            {


            }
        }

        protected void Bring()
        {
            ToplamHesap();

            E_mail_adresss();
            //veritabanından getirilen e-mailler
            UyeGetir();
            //uye kontrolü
        }

        

        protected void Unnamed_Click(object sender, EventArgs e)
        {


            if (emails.Contains(mail.Text))
            {
                //e-mail adreisnin kayıtlı oldugunu gösteren uyarı
                UyariLabel.Text = "Email Adresi Kayıtlı";
            }
            else
            {
                DbConnection Database = new DbConnection();
                   
                SqlConnection sqlConnection = Database.ConnectDatabase();
                //veritabanı insert komutumuz,

                SqlCommand komut = new SqlCommand("Insert into Kullanicilar (KullaniciAdSoyad,KullaniciMail,KullaniciSifre,KullanıcıTelefon,KullaniciAdres,KullaniciTur) VALUES(@KullaniciAdSoyad,@KullaniciMail,@KullaniciSifre,@KullanıcıTelefon,@KullaniciAdres,1)  select SCOPE_IDENTITY() as idsi ", sqlConnection);

                komut.Parameters.AddWithValue("@KullaniciAdSoyad", adsoyad.Text);
                // ad soyad parametre gönderme
                komut.Parameters.AddWithValue("@KullaniciMail", mail.Text);
                // mail parametre gönderme
                komut.Parameters.AddWithValue("@KullaniciSifre", sifre.Text);
                // sifre parametre gönderme
                komut.Parameters.AddWithValue("@KullanıcıTelefon", tel.Text);
                // telefon no parametre gönderme
                komut.Parameters.AddWithValue("@KullaniciAdres", adres.Text);

                // ev adresi parametre ile gönderimi

                komut.ExecuteNonQuery();
                SqlDataReader reader2 = komut.ExecuteReader();

                if (reader2.Read())
                {
                    //statc Id ye okudugumuz Idyi atadık daha sonradan kulanmak için
                    modified = reader2["idsi"].ToString();
                }

                Session["userid"] = modified; sqlConnection.Close();
                Response.Redirect("Homepage.aspx");
                UyariLabel.Text = "Başarılı, Alışverişe Devam Edebilirsiniz";
                // üye kaydından sonra ödeme işlemini tamamlayabilir.
                OdemeDiv.Visible = true;

            }
            
        }

        protected void Unnamed_Click2(object sender, EventArgs e)
        {
            DbConnection Database = new DbConnection();
            //veritabanına bağlandık
            SqlConnection sqlConnection = Database.ConnectDatabase();
            //bağlantı açıldı
            SqlCommand komut = new SqlCommand("Select * from Kullanicilar where KullaniciMail='"+ TextBox2.Text + "' ", sqlConnection);
            //mail adresini parametre olarak gönderdik

            SqlDataReader reader = komut.ExecuteReader();
            //komudumuuz okuduk
            if (reader.Read())
            {

                if (reader["KullaniciMail"].ToString() == TextBox2.Text && reader["KullaniciSifre"].ToString() == TextBox3.Text)
                {//şifre ve kullanıcıadi doğruı ise  kulanici ıdsi hafızıda tutulur
                    modified = reader["KullaniciId"].ToString(); 
                    Session["userid"] = reader["KullaniciId"].ToString();
                    UyariLabel.Text = "Kullanici Adı Şifre Doğru Alışverişe Devam Edebilirsiniz"; 
                    OdemeDiv.Visible = true; Response.Redirect("UsersProfil.aspx");
                    //
                }
                else
                {
                    //şifre yanlışsa uyarı çıkar
                    UyariLabel.Text = "Kullanici Adı veya Şifre Yanlış";
                }
            }
            sqlConnection.Close();
        }
        string a;
        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            //Ödeme işlememi tamamlama

            //veritabanı connectionumuzun oldugu classs
            DbConnection Database = new DbConnection();
            SqlConnection sqlConnection2 = Database.ConnectDatabase();
            //veritabanına bağlandık

            SqlCommand COMMAND = new SqlCommand("Insert into Siparisler (SiparisMusteriId,SiparisTarih,SiparisFiyat,Urünler) VALUES(@SiparisMusteriId,@SiparisTarih,@SiparisFiyat,@Urünlerr) ", sqlConnection2); // parametre ile insert komudumuz
            COMMAND.Parameters.AddWithValue("@SiparisMusteriId", modified);
            COMMAND.Parameters.AddWithValue("@SiparisTarih", DateTime.Now);
            COMMAND.Parameters.AddWithValue("@SiparisFiyat", Convert.ToDouble(toplampara.Text));

            foreach (var item in liste2)
            {
                 a=  string.Join(",", item);
            }
         
           COMMAND.Parameters.AddWithValue("@Urünlerr", a);
           
           
            COMMAND.ExecuteNonQuery(); islemdiv.Visible = true;
            //komutlarımızı gönderdikten sona islem yapılabilecek div görünür hale getirildi
        }

        protected void ToplamHesap()
        {

            //sepet hesabı
            
            double toplamHesap = 0;
            //sepete

            try
            {

                liste2 = (List<Sepet>)Session["basket"];
                //sessionda tutal sepetimizi listeye atadık
                if (liste2.Count > 0)
                {
                    foreach (var item in liste2)
                    {
                        DbConnection Database = new DbConnection();
                        SqlConnection sql = Database.ConnectDatabase();
                        SqlCommand command = new SqlCommand("select * from Urunler where UrunId=@CateID", sql);
                        command.Parameters.AddWithValue("@CateID", item.indexNo);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {//vt de bulunan ürünlerin fiyatlarını hesapladık
                            toplamHesap += Convert.ToDouble(reader["UrunFiyat"]);
                        }  //connectionumuz kapandı
                        sql.Close();
                    }
                    Countlabel.Text = liste2.Count.ToString();
                    toplampara.Text = toplamHesap.ToString();
                }

            }
            catch (Exception)
            {
                //  Response.Redirect("Odeme.aspx");
              //Response.Redirect("homepage.aspx");
                toplampara.Text = "0";
            }
        }


        protected void E_mail_adresss()
        {
            DbConnection Database = new DbConnection(); SqlConnection CONNECT = Database.ConnectDatabase();

            SqlCommand command = new SqlCommand("select KullaniciMail from Kullanicilar", CONNECT);
            //bütün kullanıcıların mailini listemize çektik eğer kayıtlıysa kullanıcı maili kontrol etmek için
            SqlDataReader reader = command.ExecuteReader();while (reader.Read()) { emails.Add(reader["KullaniciMail"].ToString()); }
            CONNECT.Close();
        }
    }
}