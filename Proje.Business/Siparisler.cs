using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
    public class Siparisler
    {
        public string Urünler { get; set; }
        Proje.DataAcces.bdelekti_E_TicaretEntities1 ent = new DataAcces.bdelekti_E_TicaretEntities1();

        
        public List<Proje.DataAcces.Siparisler> Listele(int MüsID)
        {
            var sonuc = ent.Siparisler.Where(p => p.SiparisMusteriId == MüsID && p.OnayDurumu == true);
            //var sonuc = ent.Siparisler.ToList();
            return sonuc.ToList();
        }
    }
}
