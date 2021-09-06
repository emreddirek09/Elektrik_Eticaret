using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
     public class Kampanyalar
    { 
        string KampanyaAd { get; set; }

        Proje.DataAcces.Kampanya kampanya = new DataAcces.Kampanya();
        Proje.DataAcces.bdelekti_E_TicaretEntities1 ent = new DataAcces.bdelekti_E_TicaretEntities1();

        public string KampanyaEkle(string veri, string a)
        {
            kampanya.KampanyaAd = veri;
            kampanya.KampanyaBanner = a;
            ent.Kampanya.Add(kampanya);
            ent.SaveChanges();
            return "1";
        }
        public Proje.DataAcces.Kampanya KategoriCek(int idd)
        {
            var sonuc = ent.Kampanya.Where(p => p.KampanyaId == idd);
            return sonuc.FirstOrDefault();
        }
       
        public List<Proje.DataAcces.Kampanya> Listele()
        {
            var sonuc = ent.Kampanya.ToList();
            return sonuc;
        }

        public List<Proje.DataAcces.Urunler> KampanyaliUrünListele()
        {

            var serv = (from Urn in ent.Urunler
                         join kamp in ent.Kampanya
                         on Urn.UrunKampanyaId equals kamp.KampanyaId 
                         where Urn.UrunKampanyaId == kamp.KampanyaId
                         select Urn).ToList();

            return serv;
        }
    }
}
