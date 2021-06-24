using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HepsiBizde
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private string productId;

        protected void Page_Load(object sender, EventArgs e)
        {
            DbConnection Vtbaglanti = new DbConnection(); 
            SqlConnection CONN = Vtbaglanti.ConnectDatabase();
            SqlCommand COMMAND = new SqlCommand("Select * from Siparisler inner join Kullanicilar on Kullanicilar.KullaniciId = Siparisler.SiparisMusteriId Where Siparisler.OnayDurumu = 0 ", CONN); 
            SqlDataReader reader = COMMAND.ExecuteReader();           
            OrdersRepeater.DataSource = reader;
            OrdersRepeater.DataBind();//repeaterımıza yükledik
            CONN.Close();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LinkButton myButton = (LinkButton)sender;
            productId = myButton.CommandArgument;
            DbConnection ConnectDatabaseti = new DbConnection();
            SqlConnection conn = ConnectDatabaseti.ConnectDatabase();
            SqlCommand sqlkomutumuz = new SqlCommand("Update Siparisler SET OnayDurumu = @onay where SiparisId = @id ", conn);
            sqlkomutumuz.Parameters.AddWithValue("@id", productId);
            sqlkomutumuz.Parameters.AddWithValue("@onay", "True");
            sqlkomutumuz.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("SiparisOnay.aspx");
        }
    }
}