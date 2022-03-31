using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Mk.DBConnector;

namespace BusinessLogic
{
    public static class Connection
    {
        public static Base Db;

        static Connection()
        {
            
            DBAdapter adapter = new DBAdapter(DatabaseType.MySql, Instance.NewInstance, "localhost", 3306, "promanager", "root", "", "logfile.log");

            adapter.Adapter.LogFile = true;

            Connection.Db = adapter.Adapter;
        }
    }
}
