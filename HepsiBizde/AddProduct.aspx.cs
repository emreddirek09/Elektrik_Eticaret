using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static string productId;
        private int? a = null ;
        private int b ;
        Proje.Business.Kampanyalar kampanyalarNesne = new Proje.Business.Kampanyalar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KampanyaCek();
                ShowAllDatas();
                KampanyaListele();
            }
        }

        protected void MarkaKayit_Click(object sender, EventArgs e)
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("Insert into Markalar (MarkaAdi) VALUES(@MarkaAdi) ", conn);
            komut.Parameters.AddWithValue("@MarkaAdi", BrandName.Value);
            //sql parametre gönderilerek eklenmiştir.
            komut.ExecuteNonQuery();
            CategoryName.Value = "";
            MarkalariGetir();
            conn.Close();
        }

        protected void MarkalariGetir()
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            //veritgabanımızda bulunan markalar listelendi ve repeatere yüklendi
            SqlCommand komut = new SqlCommand("Select * from Markalar ", conn);

            SqlDataReader reader = komut.ExecuteReader();
            Repeater1.DataSource = reader;
            Repeater1.DataBind();
            conn.Close();
        }
        protected void ListMarkaDrop()
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            //baglanti nesnemiz oluşturuldu
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            //Bağlatımız acıldı


            SqlCommand komut = new SqlCommand("Select * from Markalar ", conn);
            //markalar çekildi select komutuyla
            SqlDataReader reader = komut.ExecuteReader();
            BrandDropdown.DataSource = reader;
            BrandDropdown.DataBind();

            conn.Close();
        }

        protected void GET_URUNLER_LISTE()
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("select * from Urunler join Markalar on Markalar.MarkaId = Urunler.UrunMarkaId join Kategoriler on Kategoriler.KategoriId = Urunler.UrunKategoriId ", conn);
            //sql inner join bişle tablolarımız bağlandı

            SqlDataReader reader = komut.ExecuteReader();
            //datareaderimiz komudumuzu okudu
            productRepeater.DataSource = reader;
            //repeatewrimiza datasource olarak atandı
            productRepeater.DataBind();
            conn.Close();
        }

        protected void UrunKaydedildi_Click(object sender, EventArgs e)
        {
            //Convert.ToDouble(discountedproductprice.Text) Convert.ToInt32(DropDownListKampanya.SelectedValue)
            
            b = Convert.ToInt32(productprice.Text);
            string text = discountedproductprice.Text;
           
            

            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();            
            SqlCommand sqlkomudumuz = new SqlCommand("Insert into Urunler (UrunAd,UrunAciklama,UrunFiyat,UrunKategoriId,UrunMarkaId,UrünKampanyaId,UrünIndirimFiyat,UrunResim) VALUES('"
                + productname.Text + "','"
                + productdesc.Text + "','" 
                + Convert.ToDouble(productprice.Text) + "','"
                + Convert.ToInt32(CategoryDropdown.SelectedItem.Value) + "','"
                + Convert.ToInt32(BrandDropdown.SelectedItem.Value) + "',@KampanyaId,@UrünIndirimFiyat,@UrunResim)", conn);

            if (DropDownListKampanya.SelectedValue == "-1")
            {
                sqlkomudumuz.Parameters.AddWithValue("@KampanyaId", -1);
            }
            else
            {
                sqlkomudumuz.Parameters.AddWithValue("@KampanyaId", Convert.ToInt32(DropDownListKampanya.SelectedValue));
            }



            if (text == "")
            {
                sqlkomudumuz.Parameters.AddWithValue("@UrünIndirimFiyat", "");
            } 
            else
            {
                sqlkomudumuz.Parameters.AddWithValue("@UrünIndirimFiyat", Convert.ToInt32(discountedproductprice.Text));
            }

            if (FileUpload1.HasFile)
            {
            FileUpload1.SaveAs(Server.MapPath("~/dosyalar/") + FileUpload1.FileName);
            sqlkomudumuz.Parameters.AddWithValue("@UrunResim", "dosyalar/" + FileUpload1.FileName);
                    
            }
            else
            {
                sqlkomudumuz.Parameters.AddWithValue("@UrunResim", "https://st3.depositphotos.com/23594922/31822/v/600/depositphotos_318221368-stock-illustration-missing-picture-page-for-website.jpg");
            }

            sqlkomudumuz.ExecuteNonQuery();

            //komut çalıştırıldı ve veritbaanına uygulandı

            CategoryName.Value = "";
            conn.Close();

            ShowAllDatas();


        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            //markalar delete
            LinkButton MYBUTTON = (LinkButton)sender;

            //link button senderimiz bize kategoriId tutmuştur
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection baglanti = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("Delete from Markalar where MarkaId = '"+ MYBUTTON.CommandArgument + "'", baglanti);
            //komutumuza parametre gönderme
            komut.ExecuteNonQuery();
            //kayıt işleminden sonra verilerin listelenmesi
            ShowAllDatas();
            Response.Redirect("Addproduct.aspx");
        }

        protected void Unnamed_Click2(object sender, EventArgs e)
        {
            //kategori silme
            LinkButton LinkButton = (LinkButton)sender;
            //link button senderimiz bize kategoriId tutmuştur
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("Delete from Kategoriler where KategoriId = '"+ LinkButton.CommandArgument + "' ", conn);
            //veritabanında bulunan kategori Linkbuttonda bulunan commandArgument attributunde bulunan Id ile silinmiştir.
            komut.ExecuteNonQuery();
            ShowAllDatas();
            Response.Redirect("Addproduct.aspx");
        }

        protected void Unnamed_Click3(object sender, EventArgs e)
        {
            LinkButton LinkButton = (LinkButton)sender;

            //link button senderimiz bize UrunId tutmuştur
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("Delete from Urunler where UrunId = @URUNID ", conn);
            komut.Parameters.AddWithValue("@URUNID", LinkButton.CommandArgument);
            //veritabanında bulunan kategori sql parametre ile Linkbuttonda bulunan commandArgument attributunde bulunan Id ile silinmiştir.
            komut.ExecuteNonQuery();
            ShowAllDatas();
            Response.Redirect("Addproduct.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            LinkButton myButton = (LinkButton)sender;
            productId = myButton.CommandArgument;

            savebutton.Visible = false;
            updatebutton.Visible = true;

            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();





            SqlCommand komut = new SqlCommand("Select * from Urunler where UrunId = @id ", conn);
            komut.Parameters.AddWithValue("@id", myButton.CommandArgument);



            SqlDataReader okuyucu = komut.ExecuteReader();
            if (okuyucu.Read())
            {
                productdesc.Text = okuyucu["UrunAciklama"].ToString();
                productprice.Text = okuyucu["UrunFiyat"].ToString();
                productname.Text = okuyucu["UrunAd"].ToString();
            }

        }

        protected void ShowAllDatas()
        {
            ListCategories(); // kategori list
            MarkalariGetir(); // marka list
            ListCategoriesDrop(); // kategori dropdownlist
            ListMarkaDrop(); //marka dropdown list
            GET_URUNLER_LISTE(); // ürünlerin repeaterda listelenmesi
        }

        protected void KategoriKayit_Click(object sender, EventArgs e)
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("Insert into Kategoriler (KategoriAd) VALUES('" + CategoryName.Value + "') ", conn);
            komut.ExecuteNonQuery();
            CategoryName.Value = "";
            ListCategories();
            conn.Close();
        }

        protected void ListCategories()
        {
            DbConnection DbConnection = new DbConnection();
            SqlConnection conn = DbConnection.ConnectDatabase();
            SqlCommand komut = new SqlCommand("Select * from Kategoriler ", conn);
            SqlDataReader reader = komut.ExecuteReader();
            Categories.DataSource = reader;
            Categories.DataBind();
            conn.Close();
        }

        protected void ListCategoriesDrop()
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("Select * from Kategoriler ", conn);

            SqlDataReader reader = komut.ExecuteReader();

            CategoryDropdown.DataSource = reader;
            CategoryDropdown.DataBind();
            conn.Close();
        }

        protected void Unnamed_Click5(object sender, EventArgs e)
        {
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            SqlCommand sqlkomutumuz = new SqlCommand("Update Urunler SET UrunAd = @UrunAd, UrunKategoriId=@UrunKategoriId, UrunResim=@UrunResim, UrunMarkaId=@UrunMarkaId, UrunAciklama = @UrunAciklama, UrunFiyat = @UrunFiyat where UrunId = @id ", conn);
            sqlkomutumuz.Parameters.AddWithValue("@id", productId);
            sqlkomutumuz.Parameters.AddWithValue("@UrunAd", productname.Text);
            sqlkomutumuz.Parameters.AddWithValue("@UrunAciklama", productdesc.Text);
            sqlkomutumuz.Parameters.AddWithValue("@UrunKategoriId", CategoryDropdown.SelectedItem.Value);
            sqlkomutumuz.Parameters.AddWithValue("@UrunMarkaId", BrandDropdown.SelectedItem.Value);
            sqlkomutumuz.Parameters.AddWithValue("@UrunFiyat", Convert.ToDouble(productprice.Text));
            //parametreler ile ürün kaydı
            if (FileUpload1.HasFile)
            {
                //if (FileUpload1.PostedFile.ContentLength < 1024000)
                //{
                    //fileuploadımızda bulunan resmin klasörde kaydedilmesi
                    FileUpload1.SaveAs(Server.MapPath("~/dosyalar/") + FileUpload1.FileName);
                    sqlkomutumuz.Parameters.AddWithValue("@UrunResim", "dosyalar/" + FileUpload1.FileName);
                //}
                //else
                //{
                //    //eger resim 10mbden büuük ise random resim atanması
                //    sqlkomutumuz.Parameters.AddWithValue("@UrunResim", "https://st3.depositphotos.com/23594922/31822/v/600/depositphotos_318221368-stock-illustration-missing-picture-page-for-website.jpg");
                //}
            }
            else
            {
                //fileupload boş ise random resim atanması
                sqlkomutumuz.Parameters.AddWithValue("@UrunResim", "https://st3.depositphotos.com/23594922/31822/v/600/depositphotos_318221368-stock-illustration-missing-picture-page-for-website.jpg");
            }



            sqlkomutumuz.ExecuteNonQuery();
            conn.Close();// açık connectionun kapanması
            Response.Redirect("Addproduct.aspx");
        }

        protected void AddKampanya_Click(object sender, EventArgs e)
        {
            string a;

            if (KampanyaBanner.HasFile)
            {
                //fileuploadımız dosyaya sahipse 
                //if (KampanyaBanner.PostedFile.ContentLength < 102400)
                //{//ve dosya 10 mbden küçükse 
                    KampanyaBanner.SaveAs(Server.MapPath("~/dosyalar/") + KampanyaBanner.FileName);
                    a= "dosyalar/" + KampanyaBanner.FileName;
                    //resim klasöre kaydedilir resminismi ise veritabanına yazılır
                //}
                //else
                //{
                //    //resim 10mb den büyük ise default resim atanır
                //    a = "https://st3.depositphotos.com/23594922/31822/v/600/depositphotos_318221368-stock-illustration-missing-picture-page-for-website.jpg";
                //}
            }
            else
            {
                //resim yok ise default resim atanır
                a = "https://st3.depositphotos.com/23594922/31822/v/600/depositphotos_318221368-stock-illustration-missing-picture-page-for-website.jpg";
            }
            kampanyalarNesne.KampanyaEkle(KampanyaAdi.Value,a);
            KampanyaAdi.Value = "";

        }

        public void KampanyaCek()
        {
            foreach (var item in kampanyalarNesne.Listele())
            {
                var i = item.KampanyaId;
                string KatAdi = kampanyalarNesne.KategoriCek(i).KampanyaAd;
                int Katid = kampanyalarNesne.KategoriCek(i).KampanyaId;
                DropDownListKampanya.Items.Add(new ListItem(KatAdi, Katid.ToString()));
            }
        }

        public void KampanyaListele()
        {
            var liste = kampanyalarNesne.Listele();
            Repeater2Kampanya.DataSource = liste;
            Repeater2Kampanya.DataBind();
        }
    }
}