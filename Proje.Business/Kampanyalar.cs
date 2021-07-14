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

        Proje.DataAcces.Kampanyalar kampanyalarEnt = new DataAcces.Kampanyalar();
        Proje.DataAcces.bdelekti_ETicaretEntities ent = new DataAcces.bdelekti_ETicaretEntities();

        public string KampanyaEkle(string veri, string a)
        {
            kampanyalarEnt.KampanyaAd = veri;
            kampanyalarEnt.KampanyaBanner = a;
            ent.Kampanyalar.Add(kampanyalarEnt);
            ent.SaveChanges();
            return "1";
        }
        public Proje.DataAcces.Kampanyalar KategoriCek(int idd)
        {
            var sonuc = ent.Kampanyalar.Where(p => p.KampanyaId == idd);
            return sonuc.FirstOrDefault();
        }
        public List<Proje.DataAcces.Kampanyalar> Listele()
        {
            var sonuc = ent.Kampanyalar.ToList();
            return sonuc;
        }

        

        public List<Proje.DataAcces.Urunler> KampanyaliUrünListele()
        {

            var serv = (from Urn in ent.Urunler
                         join kamp in ent.Kampanyalar 
                         on Urn.UrünKampanyaId equals kamp.KampanyaId 
                        where Urn.UrünKampanyaId == kamp.KampanyaId
                         select Urn).ToList();

            return serv;
        }
    }
}
