using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd.subsite
{
    public partial class WebForm9 : System.Web.UI.Page
    {

        private void GetUserInfo(string LANG, string USER_PCDOMAIN)
        {
            SqlDataAdapter getSerial;
            DataTable dt;
            switch (LANG)
            {
                case "az":
                    {
                        getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT PC_NAME, PC_ABOUT_AZ  FROM  PC_USERS 
                                                                           WHERE 
                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
                        getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;

                        dt = SQL.SELECT(getSerial);
                        aboususInfo.Text = dt.Rows[0]["PC_ABOUT_AZ"].ToString();
                        break;
                    }
                case "en":
                    {
                        getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT PC_NAME, PC_ABOUT_EN  FROM  PC_USERS 
                                                                           WHERE 
                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
                        getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;

                        dt = SQL.SELECT(getSerial);
                        aboususInfo.Text = dt.Rows[0]["PC_ABOUT_EN"].ToString();
                        break;
                    }
                default:
                    {
                        getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT PC_NAME, PC_ABOUT_AZ  FROM  PC_USERS 
                                                                           WHERE 
                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
                        getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;

                        dt = SQL.SELECT(getSerial);
                        aboususInfo.Text = dt.Rows[0]["PC_ABOUT_AZ"].ToString();
                        break;
                    }
            }

            dt = null;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
     

            GetUserInfo(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Page.RouteData.Values["publiccouncil"] as string);
        }
    }
}