using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WCFBookApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            FillDatabase();
        }

        public static void FillDatabase()
        {
            string ConnectionString=@"Data Source=CHETANBADHE-PC\SQLEXPRESS;Initial Catalog=Book_DB;Persist Security Info=True;User ID=sa;Password=sa@123";
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd;
            for(int i = 0; i< 10010; i++){
                cmd = new SqlCommand("InsertBook", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name","name"+i.ToString());       
                cmd.Parameters.AddWithValue("@description ", "description"+i.ToString());     
                cmd.Parameters.AddWithValue("@datePublished ",DateTime.Now);     
                cmd.ExecuteNonQuery();                     //executing the sqlcommand
                
            }

            conn.Close();
        }
    }
}
