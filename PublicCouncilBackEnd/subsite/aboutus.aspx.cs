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

        private void GetUserInfo(string USER_PCDOMAIN)
        {
            SqlDataAdapter getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT PC_NAME, PC_ABOUT  FROM  PC_USERS 
                                                                           WHERE 
                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
            getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;

            DataTable dt = SQL.SELECT(getSerial);

            aboususInfo.Text = dt.Rows[0]["PC_ABOUT"].ToString();
            //pcName.Text = dt.Rows[0]["PC_NAME"].ToString();
            dt = null;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Convert.ToString(Page.RouteData.Values["language"]).ToLower())
            {
                case "az":
                    {
                        pageName.Text = "Haqqımızda";
                        break;
                    }
                case "en":
                    {
                        pageName.Text = "About Us";
                        break;
                    }
                default:
                    {
                        pageName.Text = "Haqqımızda";
                        break;
                    }
            }

            GetUserInfo(Session["pcsubsite"] as string);
        }
    }
}