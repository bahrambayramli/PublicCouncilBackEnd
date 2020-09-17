using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
namespace PublicCouncilBackEnd
{
    public class SQL
    {
        static string conntext = ConfigurationManager.ConnectionStrings["pc"].ToString();
        //ONLY FOR SELECT FROM DATABASE (GetData)
        public static DataTable SELECT(SqlDataAdapter adapter)
        {
            SqlConnection connection = new SqlConnection(conntext);

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                adapter.SelectCommand.Connection = connection;
                adapter.Fill(dataTable);
                connection.Close();

            }
            catch (Exception ex)
            {
               // Log.LogCreator(@"C:\inetpub\qhtaz\Logs\logs.txt",ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dataTable;

        }


        //ONLY FOR INSERT UPDATE AND DELETE QUERIES ( InsertData,UpdateData,DeleteData)
        public static void COMMAND(SqlCommand s)
        {

            SqlConnection conn = new SqlConnection(conntext);


            try
            {
                conn.Open();
                s.Connection = conn;
                s.ExecuteNonQuery();
                conn.Close();
            }

            catch (Exception ex)
            {
         

                Debug.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }

        }
    }
}