using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    class DataB
    {
        MySqlConnection connection = new MySqlConnection("server = remotemysql.com; port = 3306; Username = ed5dW7gcoL; Password = 0Gm5En5jkl; database = ed5dW7gcoL; charset = utf8");
               
        public void openConn()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }        
        public void closeConn()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConn()
        {
            return connection;
        }
    }
}
