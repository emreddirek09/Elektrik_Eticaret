using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            denemediv1.Visible = false;
            denemediv2.Visible = false;
            denemediv3.Visible = false;
            
        }
        Proje.Business.Kullanicilar kullanicilarNesne = new Proje.Business.Kullanicilar();
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(Session["userid"].ToString());
                var veri = kullanicilarNesne.GirisYapanKullanici(id);
                txt_isim.Value = veri.KullaniciAdSoyad;
                txt_mail.Value = veri.KullaniciMail;
                txt_telefon.Value = veri.KullanıcıTelefon;
                txt_adres.Value = veri.KullaniciAdres;
                denemediv1.Visible = true;
            }
            catch (Exception)
            {

                Response.Redirect("Odeme.aspx");
            }
            
        }
        protected void BilgileriGüncelle_Click(object sender, EventArgs e)
        {
            kullanicilarNesne.VeriGüncelle(Convert.ToInt32(Session["userid"].ToString()), txt_isim.Value, txt_mail.Value, txt_telefon.Value, txt_adres.Value);
            Label1.Text = "Güncelleme Başarılı";
            denemediv1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            denemediv2.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
             denemediv3.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("userid");
            Response.Redirect("Default.aspx", true);
            Label1.Text = "";
            Label2.Text = "";
        }

        protected void SifreGüncele_Click(object sender, EventArgs e)
        {
            var veri = kullanicilarNesne.VeriCek(Convert.ToInt32(Session["userid"].ToString()));
            var sifre = veri.KullaniciSifre;
            if (sifre == txt_mevcutSifre.Value)
            {
                if (txt_yeniSifre.Value == txt_yeniSifreOnay.Value)
                {
                    kullanicilarNesne.SifreGüncelle(Convert.ToInt32(Session["userid"].ToString()), txt_yeniSifre.Value);
                    Label2.Text = "Şifre Değişikliği başarılı.";
                    denemediv3.Visible = true;
                }
                else
                {
                    Label2.Text ="Şifre Onaylanamadı.";
                    denemediv3.Visible = true;
                }
            }
            else
            {
                Label2.Text = "Mevcut şifre yanlış. Lütfen tekrar kontrol ediniz.";
                denemediv3.Visible = true;
            }
        }
    }
}