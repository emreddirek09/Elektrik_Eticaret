using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class User : System.Web.UI.MasterPage
    {
        static string kullaniciId;
        protected void Page_Load(object sender, EventArgs e)
        {

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

        }
        protected void giris_Click(object sender, EventArgs e)
        {
            Response.Redirect("Odeme.aspx");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //session sepetimiz dolu ise ödeme sayfasına gönderirir.
            Response.Redirect("Odeme.aspx");
        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Contents.Remove("userid"); Response.Redirect("Homepage.aspx", true);
            //Response.Redirect("homepage.aspx");
        }

        protected void List_Categories_On_Menu()
        {
            DbConnection DBBAGLANTI = new DbConnection(); SqlConnection conn_ = DBBAGLANTI.ConnectDatabase();
            //vt baglantımızın bulundugu class nesnesi oluşturduj
            SqlCommand SQLCOMMAND = new SqlCommand("Select * from Kategoriler ", conn_);
            //kategorileri getirme sql kodu
            SqlDataReader SQLDATAREADER = SQLCOMMAND.ExecuteReader(); Categories.DataSource =SQLDATAREADER;
            //menülerimize readerimizi yükleyerek veri tabanında bulunan kategoriye  
            Categories.DataBind();  conn_.Close();
        }

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
            List_Categories_On_Menu();
            SEpettekiUrunleriGetir();

        }
        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            Session.Contents.Remove("basket");
            sup.Text = "0";
            //sepet temizlenir
            Response.Redirect(Page.Request.Url.ToString(), true);
            //Response.Redirect("homepage.aspx");
            
        }

        protected void Bring_Member()
        {
            DbConnection DBBAGLANTI = new DbConnection();
            SqlConnection sqlConnection = DBBAGLANTI.ConnectDatabase();
            SqlCommand SQLCOMMAND = new SqlCommand("Select * from Kullanicilar where KullaniciID='"+ kullaniciId + "' ", sqlConnection);

            SqlDataReader SQLDATAREADER = SQLCOMMAND.ExecuteReader();//readerimiz komutumuzu okudu
            if (SQLDATAREADER.Read()) {  Adsoyad.Text =SQLDATAREADER["KullaniciAdSoyad"].ToString();//giriş yapan üyenin bilgileri getilrili.
            }
            sqlConnection.Close();//baglantımızı kapattık cikisbutton.Visible = true;
        }

        
    }
}