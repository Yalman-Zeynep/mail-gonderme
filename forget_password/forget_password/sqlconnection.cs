using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace forget_password
{
    internal class sqlbaglantisi{
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=ZYNPYLMN\\MSSQLSERVER01;Initial Catalog=persons;Integrated Security=True;TrustServerCertificate=True");
            baglanti.Open();
            return baglanti;
        }
    }
}
