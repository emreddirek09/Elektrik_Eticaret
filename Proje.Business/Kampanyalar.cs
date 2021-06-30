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
            Proje.DataAcces.bdelekti_ETicaretEntities ent = new DataAcces.bdelekti_ETicaretEntities();
            var sonuc = ent.Kampanyalar.Where(p => p.KampanyaId == idd);
            return sonuc.FirstOrDefault();
        }
        public List<Proje.DataAcces.Kampanyalar> Listele()
        {
            Proje.DataAcces.bdelekti_ETicaretEntities ent = new DataAcces.bdelekti_ETicaretEntities();
            var sonuc = ent.Kampanyalar.ToList();
            return sonuc;
        }
    }
}
