using System.Data;
using System.Data.SqlClient;

namespace Project
{
    class DBConnection
    {
        string strcon = "Data source=DESKTOP-V2EDS8D; initial catalog=dbMinimartBCSP6E; integrated security=true";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(strcon);
        }
    }
}
