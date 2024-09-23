using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace STMS
{
    internal class SqlExecute
    {
        MySqlConnection connection;
        MySqlCommand command;
        string connstr = "server=127.0.0.1;database=test;username=root;password=2326;";
        //增删改
        public int AddDeleteAndModify(string sql)
        {
            int a = 0;
            using (connection = new MySqlConnection(connstr))
            {
                
                using (command = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    a=command.ExecuteNonQuery();
                }
                
            }
         return a;
        }
        //查询
        public MySqlDataReader Query(string sql)
        {
            MySqlDataReader mySqlDataReader;
            connection = new MySqlConnection(connstr);

            command = new MySqlCommand(sql, connection);

            connection.Open();
            mySqlDataReader = command.ExecuteReader();
            //connection.Close();
            return mySqlDataReader;
        }
        public void Close()
        {
            connection.Close();
        }
        public int OnlyQuery(string sql)
        {
            using (MySqlConnection connection = new MySqlConnection(connstr))
            {

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    
                }

            }
            return 0;
        }
    }
}
