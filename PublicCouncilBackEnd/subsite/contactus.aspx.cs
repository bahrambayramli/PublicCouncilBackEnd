using System;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.subsite
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        #region(HELPER FUNCTIONS)
        private void ChangeLanguage(string LANG)
        {
            switch (LANG)
            {
                case "az":
                    {
                        pageName.Text = "Əlaqə";
                        break;
                    }
                case "en":
                    {
                        pageName.Text = "Contact us";
                        break;
                    }
                default:
                    {
                        pageName.Text = "Əlaqə";
                        break;
                    }
            }
        }
        #endregion

        #region(SQL FUNCTIONS)
        private void GetUserInfo(string USER_PCDOMAIN)
        {
            SqlDataAdapter getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT  USER_MOBILE          ,
                                                                                   PC_TELEPHONE         ,
                                                                                   PC_EMAIL             ,
                                                                                   PC_WEBADDRESS
                                                                           FROM  PC_USERS 
                                                                           WHERE 
                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));

            getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value            = false;
            getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value            = true;
            getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value  = USER_PCDOMAIN;

            DataTable dt = SQL.SELECT(getSerial);

            subMob.Text     = $"<i class='fas fa-mobile-alt mr-2'></i>{dt.Rows[0]["USER_MOBILE"].ToString()}";
            subTel.Text     = $"<i class='fas fa-phone-square-alt mr-2'></i>{dt.Rows[0]["PC_TELEPHONE"].ToString()}";
            subEmail.Text   = $"<i class='fas fa-envelope mr-2'></i>{dt.Rows[0]["PC_EMAIL"].ToString()}";
            subEmail.Text   = $"<i class='fas fa-globe-europe mr-2'></i><a target='_blank' href='{dt.Rows[0]["PC_WEBADDRESS"].ToString()}'>{dt.Rows[0]["PC_WEBADDRESS"].ToString()}</a>";
           

        }
        #endregion

        protected private void RunContactUs(string LANG, string PC_NAME)
        {
            try
            {
                ChangeLanguage(LANG);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> contactus.aspx page >> ChangeLanguage, Log:{ex.Message}");
            }

            try
            {
                GetUserInfo(PC_NAME);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> contactus.aspx page >> ChangeLanguage, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RunContactUs(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower());
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> contactus.aspx page >> RunContactUs, Log:{ex.Message}");
            }
        }
    }
}