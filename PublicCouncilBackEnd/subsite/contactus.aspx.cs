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
    public partial class WebForm8 : System.Web.UI.Page
    {
        private void GetUserInfo(string USER_PCDOMAIN)
        {
            SqlDataAdapter getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT  USER_MOBILE,
                                                                                   PC_TELEPHONE,
                                                                                   PC_EMAIL,
                                                                                   PC_WEBADDRESS
                                                                           FROM  PC_USERS 
                                                                           WHERE 
                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
            getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;

            DataTable dt = SQL.SELECT(getSerial);

            subMob.Text = dt.Rows[0]["USER_MOBILE"].ToString();
            subTel.Text = dt.Rows[0]["PC_TELEPHONE"].ToString();
            subEmail.Text = dt.Rows[0]["PC_EMAIL"].ToString();
            subEmail.Text = dt.Rows[0]["PC_WEBADDRESS"].ToString();
            dt = null;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Convert.ToString(Page.RouteData.Values["language"]).ToLower())
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

            GetUserInfo(Session["pcsubsite"] as string);
        }
    }
}