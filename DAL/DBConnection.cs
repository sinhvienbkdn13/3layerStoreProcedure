using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnection
    {
       public static SqlConnection Connection()
        {
            string stringconect = "Data Source=Tommy;Initial Catalog=QLSV;Integrated Security=True";
            SqlConnection connect = new SqlConnection(stringconect);
            return connect;
        }
    }
}
