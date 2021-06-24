using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            All_Orders_Customers_List();
            //ürünleri ve toplam gelir fonksiyonlarımızı çağırdık
            CalculateTotalIncome();
        }

        protected void All_Orders_Customers_List()
        {
            DbConnection Vtbaglanti = new DbConnection(); SqlConnection CONN = Vtbaglanti.ConnectDatabase();
            SqlCommand COMMAND = new SqlCommand("Select * from Siparisler inner join Kullanicilar on Kullanicilar.KullaniciId = Siparisler.SiparisMusteriId Where Siparisler.OnayDurumu = 1 ", CONN); SqlDataReader reader = COMMAND.ExecuteReader();
            //İNNER JOİN ile kullanıcı ve sipariş birleştirilmesi yaptık
            OrdersRepeater.DataSource = reader;
            OrdersRepeater.DataBind();//repeaterımıza yükledik
            CONN.Close();
        }

        protected void CalculateTotalIncome()
        {
            DbConnection baglanti = new DbConnection(); SqlConnection sqlConnection = baglanti.ConnectDatabase();
            SqlCommand komut = new SqlCommand("Select sum(Siparisler.SiparisFiyat) as totalmoney from Siparisler Where OnayDurumu = 1", sqlConnection);
            //sql aggregate fonksiyonu ile toplam veriler hesaplanmıştır.
            SqlDataReader reader = komut.ExecuteReader();
            //datareaderı çalıştırdık
            if (reader.Read())
            {
                //if (Income.Text =="")
                //{
                //    Response.Redirect("YönetimPaneli.aspx");
                //}
                //else
                //{
                    //sqlden dönen totalmoney ile labelde gösterdik. toplam gelir
                    Income.Text = Math.Round(Convert.ToDecimal(reader["totalmoney"]), 2).ToString();
                }
                
            //}
            sqlConnection.Close();
        }
        //
    }
}