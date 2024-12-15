using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismRoute
{
    internal class DataBase
    {
        public static string strConnection =
            "server=127.0.0.1;" +
            "port=3306;" +
            "user id=root;" +
            "password=;" +
            "database=TourismRoute";

        public static string Users =
            "SELECT * FROM users";



        public static string Logining
            (string login, string password)
        {
            return $"SELECT id FROM users " +
                $"WHERE login = '{login}'" +
                $"AND password = '{password}'";
        }

        public static string CheckLog
            (string login)
        {
            return $"SELECT id FROM users " +
             $"WHERE login = '{login}';";
        }

        public static string Registration
           (string login, string password)
        {
            return "INSERT INTO users (login, password) " +
                $"VALUE ('{login}', '{password}');";
        }
        public static string Route
            (string Name, string Lenght)
        {
            return "INSERT INTO routes (Name , Lenght)" +
                $" VALUE ('{Name}', '{Lenght}');";
        }
    }
}
