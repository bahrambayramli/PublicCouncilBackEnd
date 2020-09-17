using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd
{
    public class Helper
    {
        public static string SetName(string fileExtension)
        {
            string fileName = Guid.NewGuid().ToString().Replace("-", "") +
                                                DateTime.Now.Day.ToString() +
                                                DateTime.Now.Month.ToString() +
                                                DateTime.Now.Year.ToString() +
                                                DateTime.Now.Minute.ToString() +
                                                DateTime.Now.Second.ToString() +
                                                DateTime.Now.Millisecond + fileExtension;
            return fileName;
        }

        public static string MakeSerial()
        {
            string srl = DateTime.Now.Day.ToString() +
                                                 DateTime.Now.Month.ToString() +
                                                 DateTime.Now.Year.ToString() +
                                                 DateTime.Now.Minute.ToString() +
                                                 DateTime.Now.Second.ToString() +
                                                 DateTime.Now.Millisecond;
            return srl;
        }

        public string GetDate()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("SELECT FORMAT (SYSDATETIME() ,'dd/MM/yyyy HH:mm' ) as DataTime"));
            return SQL.SELECT(adapter).Rows[0]["DataTime"].ToString();
        }
    }
}