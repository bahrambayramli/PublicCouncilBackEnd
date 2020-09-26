using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicCouncilBackEnd
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private void GetNavigations(string lang)
        {
            switch (lang)
            {
                case "az":
                    {
                        NAV_AZ.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_AZ.DataBind();
                        break;
                    }
                case "en":
                    {
                        NAV_EN.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_EN.DataBind();
                        break;
                    }
                case "ru":
                    {
                        NAV_RU.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_RU.DataBind();
                        break;
                    }
                default:
                    {
                        NAV_AZ.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_AZ.DataBind();
                        break;
                    }
            }
        }
       

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtLogo = new DataTable();
            dtLogo = SQLFUNC.GetLogo("1", false, true);

            LogoMobile.DataSource = dtLogo;
            LogoMobile.DataBind();

            LogoMobile2.DataSource = dtLogo;
            LogoMobile2.DataBind();

            LogoDesktop.DataSource = dtLogo;
            LogoDesktop.DataBind();

            GetNavigations(Page.RouteData.Values["language"] as string);

        }
    }
}