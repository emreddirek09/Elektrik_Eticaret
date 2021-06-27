using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
    public class Kategoriler
    {

        Proje.DataAcces.bdelekti_ETicaretEntities ent = new DataAcces.bdelekti_ETicaretEntities();

        public Proje.DataAcces.Kategoriler KategoriCek(int idd)
        {
            var sonuc = ent.Kategoriler.Where(p => p.KategoriId == idd);
            return sonuc.FirstOrDefault();
        }

        public List<Proje.DataAcces.Kategoriler> Listele()
        {
            var sonuc = ent.Kategoriler.ToList();
            return sonuc;
        }
    }
}
