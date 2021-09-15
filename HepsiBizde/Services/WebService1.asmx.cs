using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HepsiBizde.Services
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Proje.DataAcces.Urunler> SearchFonksiyon(string text)
        {
            Proje.DataAcces.bdelekti_E_TicaretEntities1 ent = new Proje.DataAcces.bdelekti_E_TicaretEntities1();

            var serv = (from Urn in ent.Urunler
                        where Urn.UrunAd.Contains(text.Trim()) || Urn.UrunAciklama.Contains(text.Trim())
                        select Urn).ToList();

            return serv;
        }
    }
}
