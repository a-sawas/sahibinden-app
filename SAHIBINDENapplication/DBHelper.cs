using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace SAHIBINDENapplication
{
    public static class DBHelper
    {
        private const string ConnStr =
            "Host=localhost;Port=5432;Username=postgres;Password=YOUR_PASSWORD_HERE;Database=sahibinden";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnStr);
        }
    }

}
