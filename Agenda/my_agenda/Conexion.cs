using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace my_agenda
{
    class Conexion
    {
        public static SQLiteConnection Conectar()
        {
           
            SQLiteConnection cn = new SQLiteConnection("Data Source = D:/my_agenda/my_agenda/bin/Debug/agenda2.db");
            return cn;
        }
    }
}
