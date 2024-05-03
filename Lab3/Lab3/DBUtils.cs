using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Lab3
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "commercial_veterinary_hospital";
            string username = "Heavenly";
            string password = "PasswordBd";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}