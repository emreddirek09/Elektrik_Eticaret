using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
    public class Kullanicilar
    {
        public Proje.DataAcces.Kullanicilar GirisYapanKullanici(int idd)
        {
            Proje.DataAcces.bdelekti_E_TicaretEntities ent = new DataAcces.bdelekti_E_TicaretEntities();
            var sonuc = ent.Kullanicilar.Where(p => p.KullaniciId == idd);
            return sonuc.FirstOrDefault();
        }
    }
}
