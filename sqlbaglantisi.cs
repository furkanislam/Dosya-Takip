using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DosyaTakip
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=ISLAMOGLU\\SERVER;Initial Catalog=dbDosyaTakip;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
