using System.Configuration;
using MySql.Data.MySqlClient;

namespace MemberApi.Data
{
    public class DbConnection
    {
        public static string ConnectionString = "Server=127.0.0.1;Port=3306;Database=memberapi;Uid=root;Pwd=root;";
    }


}

