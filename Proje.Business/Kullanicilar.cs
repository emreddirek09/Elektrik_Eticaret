using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
    public class Kullanicilar
    {
        Proje.DataAcces.bdelekti_E_TicaretEntities ent = new DataAcces.bdelekti_E_TicaretEntities();
        public Proje.DataAcces.Kullanicilar GirisYapanKullanici(int idd)
        {
            
            var sonuc = ent.Kullanicilar.Where(p => p.KullaniciId == idd);
            return sonuc.FirstOrDefault();
        }

        public void VeriGüncelle(int idd, string isim, string mail,string telefon, string adres)
        {
            var güncelle = ent.Kullanicilar.First(a => a.KullaniciId == idd);
            güncelle.KullaniciAdSoyad = isim;
            güncelle.KullaniciMail = mail;
            güncelle.KullanıcıTelefon = telefon;
            güncelle.KullaniciAdres = adres;
            ent.SaveChanges();

        }
        public void SifreGüncelle(int idd, string sifre)
        {
            var güncelle = ent.Kullanicilar.First(a => a.KullaniciId == idd);
            güncelle.KullaniciSifre = sifre;
            ent.SaveChanges();

        }
        public Proje.DataAcces.Kullanicilar VeriCek(int idd)
        {
            var sonuc = ent.Kullanicilar.Where(p => p.KullaniciId == idd);
            return sonuc.FirstOrDefault();
        }
    }
}
