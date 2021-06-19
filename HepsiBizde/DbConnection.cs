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
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ToString());
            conn.Open();
            return conn;
        }
    }
}