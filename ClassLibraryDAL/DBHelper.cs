using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Qmatic; Integrated Security=true");
            return con;
        }   
        
    }
}
