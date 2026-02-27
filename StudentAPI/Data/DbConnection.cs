using System.Configuration;
using MySql.Data.MySqlClient;

namespace StudentAPI.Data
{
    public class DbConnection
    {
        public static string ConnectionString = "Server=localhost;Port=3306;Database=survey;Uid=root;Pwd=kashyap@0928;";
            
    }
}
