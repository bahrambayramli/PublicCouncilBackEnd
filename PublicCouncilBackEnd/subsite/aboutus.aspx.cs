using System;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.subsite
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)
        private void GetUserInfo(string LANG, string USER_PCDOMAIN)
        {
            SqlDataAdapter getSerial;
            DataTable DT;
            switch (LANG)
            {
                case "az":
                    {
                        getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT  
                                                                                PC_NAME, 
                                                                                PC_ABOUT_AZ AS PC_ABOUT

                                                                        FROM    PC_USERS 

                                                                        WHERE 
                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
                        break;
                    }
                case "en":
                    {
                        getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT  
                                                                                PC_NAME, 
                                                                                PC_ABOUT_EN AS PC_ABOUT

                                                                        FROM    PC_USERS 

                                                                        WHERE 
                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
                        break;
                    }
                default:
                    {
                        getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT  
                                                                                PC_NAME, 
                                                                                PC_ABOUT_AZ AS PC_ABOUT

                                                                        FROM    PC_USERS 

                                                                        WHERE 
                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
                        break;
                    }
            }

            getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value                = false;
            getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value                = true;
            getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value      = USER_PCDOMAIN;

            DT = SQL.SELECT(getSerial);
            aboususInfo.Text = DT.Rows[0]["PC_ABOUT"].ToString();

        }
        #endregion

        protected private void RunAboutUs(string LANG, string PC_NAME)
        {
            try
            {
                GetUserInfo(LANG, PC_NAME);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >>aboutus.aspx page >> GetUserInfo method, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RunAboutUs(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Page.RouteData.Values["publiccouncil"] as string);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >>aboutus.aspx page >> RunAboutUs method, Log:{ex.Message}");
            }

        }

    }
}