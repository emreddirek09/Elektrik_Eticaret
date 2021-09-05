using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HepsiBizde
{
    public class DbConnection
    {
        public SqlConnection ConnectDatabase()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=89.252.181.210\MSSQLSERVER2019; Initial Catalog=bdelekti_E_Ticaret; User ID=bdelekti_TekDers; Password=91Fokh2#");
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
            conn.Open();
            return conn;
        }
    }
}