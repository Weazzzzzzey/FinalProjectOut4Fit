using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Out4FitBeta.DataBase
{
    public class DataBaseConnection
    {
        //insert, select, delete, update
        protected string connectionDuom;
        protected string sqlEil;
        protected MySqlConnection connection;
        protected MySqlCommand cmd;
        protected MySqlDataAdapter adap;

        public DataBaseConnection()
        {
            connectionDuom = "Server=localhost;Database=out4fit;Uid=root;Pwd=";
            connection = new MySqlConnection(connectionDuom);
        }
    }
}